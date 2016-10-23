using CargoManager.DataAccess.Contracts.Configuration;
using CargoManager.DataAccess.Contracts.Repositories;
using CargoManager.Domain.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CargoManager.DataAccess.Repositories
{
    public class CargoEsRepository : ICargoEsRepository
    {
        private IElasticClient client;

        public CargoEsRepository(ICargoEsRepositoryConfigSection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.client = GetElasticClient(config);
        }

        private IElasticClient GetElasticClient(ICargoEsRepositoryConfigSection config)
        {
            return new ElasticClient(
                new ConnectionSettings(new Uri(config.ServerUrl))
                    .DefaultIndex(config.DefaultIndex)
                    .DisableDirectStreaming()
                    .OnRequestCompleted(details =>
                    {
                        if (config.EnableTraceMode)
                        {
                            Debug.WriteLine("### ES REQEUST ###");
                            if (details.RequestBodyInBytes != null) Debug.WriteLine(Encoding.UTF8.GetString(details.RequestBodyInBytes));
                            Debug.WriteLine("### ES RESPONSE ###");
                            if (details.ResponseBodyInBytes != null) Debug.WriteLine(Encoding.UTF8.GetString(details.ResponseBodyInBytes));
                        }
                    })
                    .PrettyJson()
            );
        }

        public bool IngestCargos(IEnumerable<Cargo> cargoList, out IEnumerable<Cargo> failures)
        {
            failures = new List<Cargo>();

            IBulkResponse response = client.Bulk(b => b.IndexMany(cargoList, (op, c) => op.Document(c)));

            if (response.Errors)
            {
                failures = response.Items
                    .Select((Item, Index) => new { Item, Index })
                    .Where(e => !e.Item.IsValid)
                    .Select(e => cargoList.ElementAt(e.Index));
            }

            return !response.Errors;
        }


        public IEnumerable<Cargo> SearchCargos(SearchParameters parameters)
        {
            var filters = new List<QueryContainer>();

            if (parameters.Price != null 
                && (parameters.Price.From != null || parameters.Price.To != null))
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .Range(
                            r => r.Field(f2 => f2.Price)
                                  .GreaterThanOrEquals(parameters.Price.From)
                                  .LessThanOrEquals(parameters.Price.To)
                            )
                    );
            }
            if (parameters.Volume != null
                && (parameters.Volume.From != null || parameters.Volume.To != null))
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .Range(
                            r => r.Field(f2 => f2.Load.Volume)
                                  .GreaterThanOrEquals(parameters.Volume.From)
                                  .LessThanOrEquals(parameters.Volume.To)
                            )
                    );
            }
            if (parameters.Weight != null
                && (parameters.Weight.From != null || parameters.Weight.To != null))
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .Range(
                            r => r.Field(f2 => f2.Load.Weight)
                                  .GreaterThanOrEquals(parameters.Weight.From)
                                  .LessThanOrEquals(parameters.Weight.To)
                            )
                    );
            }
            if (parameters.Departure != null
                && (parameters.Departure.From != null || parameters.Departure.To != null))
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .DateRange(
                            r => r.Field(f2 => f2.Departure)
                                  .GreaterThanOrEquals(parameters.Departure.From)
                                  .LessThanOrEquals(parameters.Departure.To)
                            )
                    );
            }
            if (parameters.Arrival != null
                && (parameters.Arrival.From != null || parameters.Arrival.To != null))
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .DateRange(
                            r => r.Field(f2 => f2.Arrival)
                                  .GreaterThanOrEquals(parameters.Arrival.From)
                                  .LessThanOrEquals(parameters.Arrival.To)
                            )
                    );
            }
            if (parameters.OriginArea != null)
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .GeoDistance(
                            r => r.Field(f2 => f2.From.Location)
                                  .Location(parameters.OriginArea.Location.Lat, parameters.OriginArea.Location.Lon)
                                  .Distance(Distance.Kilometers(parameters.OriginArea.MaxDistance))
                            )
                    );
            }
            if (parameters.DestinationArea != null)
            {
                filters.Add(
                    new QueryContainerDescriptor<Cargo>()
                        .GeoDistance(
                            r => r.Field(f2 => f2.From.Location)
                                  .Location(parameters.DestinationArea.Location.Lat, parameters.DestinationArea.Location.Lon)
                                  .Distance(Distance.Kilometers(parameters.DestinationArea.MaxDistance))
                        )
                    );
            }

            Func<SortDescriptor<Cargo>, IPromise<IList<ISort>>> sortSelector = null;
            switch (parameters.SortBy)
            {
                case SortableFields.Departure:
                    sortSelector = s => s.Ascending(c => c.Departure);
                    break;
                case SortableFields.Price:
                    sortSelector = s => s.Descending(c => c.Price);
                    break;
            }

            ISearchResponse<Cargo> response = client.Search<Cargo>(
                s => 
                    s.From(parameters.Offset.GetValueOrDefault())
                    .Size(parameters.Limit.GetValueOrDefault())
                    .Query(
                        q => q.Bool(
                            b => b.Filter(filters.ToArray())
                            )
                        )
                    .Sort(sortSelector)
                    );

            return response.Hits.Select(h => h.Source);
        }
    }
}
