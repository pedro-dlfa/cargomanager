using System;
using System.Configuration;

namespace CargoManager.Common.Configuration
{
    public class ConfigurationLoader
    {
        /// <summary>
        /// Loads a configuration section with a specific name.
        /// </summary>
        /// <typeparam name="TSection">The type of the section.</typeparam>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns>
        /// Configuration section
        /// </returns>
        /// <exception cref="System.ArgumentException">Value cannot be null or whitespace.;sectionName</exception>
        public TSection LoadConfigurationSection<TSection>(string sectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", "sectionName");
            }

            TSection section = (TSection)ConfigurationManager.GetSection(sectionName);
            return section;
        }
    }
}