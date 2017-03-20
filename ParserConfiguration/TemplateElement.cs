namespace ParserConfiguration
{
    using System.Configuration;

    public class TemplateElement : ConfigurationElement
    {
        #region Static Fields
        private static ConfigurationProperty _propName;
        private static ConfigurationProperty _propType;
        private static ConfigurationProperty _propAccount;
        private static ConfigurationProperty _propAmount;
        private static ConfigurationProperty _propAvailable;
        private static ConfigurationProperty _propPayee;
        private static ConfigurationProperty _propDate;
        private static ConfigurationProperty _propTime;

        private static ConfigurationPropertyCollection _properties;
        #endregion

        #region Constructors

        static TemplateElement()
        {
            // Predefine properties here
            _propName = new ConfigurationProperty(
               "Name",
               typeof(string),
               null,
               ConfigurationPropertyOptions.IsRequired
           );

            _propType = new ConfigurationProperty(
                "Type",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            _propAccount = new ConfigurationProperty(
                "Account",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
            );

            _propAmount = new ConfigurationProperty(
                "Amount",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
            );

            _propAvailable = new ConfigurationProperty(
               "Available",
               typeof(string),
               null,
               ConfigurationPropertyOptions.None
           );

            _propPayee = new ConfigurationProperty(
               "Payee",
               typeof(string),
               null,
               ConfigurationPropertyOptions.None
           );

            _propDate = new ConfigurationProperty(
               "Date",
               typeof(string),
               null,
               ConfigurationPropertyOptions.None
           );

            _propTime = new ConfigurationProperty(
               "Time",
               typeof(string),
               null,
               ConfigurationPropertyOptions.None
           );

            _properties = new ConfigurationPropertyCollection();

            _properties.Add(_propName);
            _properties.Add(_propAccount);
            _properties.Add(_propAmount);
            _properties.Add(_propAvailable);
            _properties.Add(_propDate);
            _properties.Add(_propPayee);
            _properties.Add(_propTime);
            _properties.Add(_propType);
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

        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get
            {
                return ((string)(base["Name"]));
            }
            set
            {
                base["Name"] = value;
            }
        }

        [ConfigurationProperty("Type", IsRequired = true)]
        public string Type
        {
            get
            {
                return ((string)(base["Type"]));
            }
            set
            {
                base["Type"] = value;
            }
        }

        [ConfigurationProperty("Account")]
        public string Account
        {
            get
            {
                return ((string)(base["Account"]));
            }
            set
            {
                base["Account"] = value;
            }
        }

       [ConfigurationProperty("Amount")]
        public string Amount
        {
            get
            {
                return ((string)(base["Amount"]));
            }
            set
            {
                base["Amount"] = value;
            }
        }

      [ConfigurationProperty("Available")]
        public string Available
        {
            get
            {
                return ((string)(base["Available"]));
            }
            set
            {
                base["Available"] = value;
            }
        }

       [ConfigurationProperty("Payee")]
        public string Payee
        {
            get
            {
                return ((string)(base["Payee"]));
            }
            set
            {
                base["Payee"] = value;
            }
        }

      [ConfigurationProperty("Date")]
       public string Date
        {
            get
            {
                return ((string)(base["Date"]));
            }
            set
            {
                base["Date"] = value;
            }
        }

       [ConfigurationProperty("Time")]
        public string Time
        {
            get
            {
                return ((string)(base["Time"]));
            }
            set
            {
                base["Time"] = value;
            }
        }

        #endregion Property
        
    }
}
