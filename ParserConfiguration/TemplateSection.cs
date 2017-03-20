namespace ParserConfiguration
{
    using System;
    using System.Configuration;

    public class TemplateSection : ConfigurationSection
    {
        #region Static Fields
        private static ConfigurationProperty _propTemplates;
        private static ConfigurationProperty _propInputCodePage;
        private static ConfigurationProperty _propMessageLines;

        private static ConfigurationPropertyCollection _properties;
        #endregion

        #region Constructors

        static TemplateSection()
        {
            // Predefine properties here
            _propTemplates = new ConfigurationProperty(
                "Templates",
                typeof(TemplateElementCollection),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            _propMessageLines = new ConfigurationProperty(
                "MessageLines",
                typeof(Int32),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            _propInputCodePage = new ConfigurationProperty(
                "InputCodePage",
                typeof(String),
                null,
                ConfigurationPropertyOptions.IsRequired
            );
            
            _properties = new ConfigurationPropertyCollection();
            
            _properties.Add(_propTemplates);
            _properties.Add(_propMessageLines);
            _properties.Add(_propInputCodePage);
        }

        #endregion Constructors
        
        #region Property

        /// <summary>
        /// Override the Properties collection and return our custom one.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        [ConfigurationProperty("Templates")]
        public TemplateElementCollection Templates
        {
            get
            {
                return ((TemplateElementCollection)(base["Templates"]));
            }
            set
            {
                base["Templates"] = value;
            }
        }

        [ConfigurationProperty("InputCodePage", DefaultValue = "UTF-8")]
        public String InputCodePage
        {
            get
            {
                return ((String)(base["InputCodePage"]));
            }
            set
            {
                base["InputCodePage"] = value;
            }
        }


        [ConfigurationProperty("MessageLines", DefaultValue = 5)]
        public Int32 MessageLines
        {
            get
            {
                return ((Int32)(base["MessageLines"]));
            }
            set
            {
                base["MessageLines"] = value;
            }
        }

        #endregion Property
        
    }
}
