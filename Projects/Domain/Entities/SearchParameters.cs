using System;

namespace CargoManager.Domain.Entities
{
    public class SearchParameters
    {
        public FromTo<float?> Price { get; set; }
        public FromTo<float?> Volume { get; set; }
        public FromTo<float?> Weight { get; set; }
        public LocationArea OriginArea { get; set; }
        public LocationArea DestinationArea { get; set; }
        public FromTo<DateTime?> Departure { get; set; }
        public FromTo<DateTime?> Arrival { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public SortableFields SortBy { get; set; }
    }
}
