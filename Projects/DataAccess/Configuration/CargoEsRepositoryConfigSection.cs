using CargoManager.DataAccess.Contracts.Configuration;
using System.Configuration;

namespace CargoManager.DataAccess.Configuration
{
    public class CargoEsRepositoryConfigSection : ConfigurationSection, ICargoEsRepositoryConfigSection
    {
        #region Constants

        private const string ServerUrlProperty = "serverUrl";
        private const string DefaultIndexProperty = "defaultIndex";
        private const string EnableTraceModeProperty = "enableTraceMode";

        #endregion

        /// <summary>
        /// Gets or sets the server URL.
        /// </summary>
        [ConfigurationProperty(ServerUrlProperty, IsRequired = true)]
        public string ServerUrl
        {
            get
            {
                return (string)this[ServerUrlProperty];
            }

            set
            {
                this[ServerUrlProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the default index.
        /// </summary>
        [ConfigurationProperty(DefaultIndexProperty, IsRequired = true)]
        public string DefaultIndex
        {
            get
            {
                return (string)this[DefaultIndexProperty];
            }

            set
            {
                this[DefaultIndexProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the enable trace mode.
        /// </summary>
        [ConfigurationProperty(EnableTraceModeProperty, IsRequired = true)]
        public bool EnableTraceMode
        {
            get
            {
                return (bool)this[EnableTraceModeProperty];
            }

            set
            {
                this[EnableTraceModeProperty] = value;
            }
        }

    }
}
