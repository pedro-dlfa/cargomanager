namespace CargoManager.DataAccess.Contracts.Configuration
{
    public interface ICargoEsRepositoryConfigSection
    {
        string ServerUrl { get; set; }
        string DefaultIndex { get; set; }
        bool EnableTraceMode { get; set; }
    }
}