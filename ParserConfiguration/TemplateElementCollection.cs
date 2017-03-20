namespace ParserConfiguration
{
    using System.Configuration;

    [ConfigurationCollection(typeof(TemplateElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class TemplateElementCollection : ConfigurationElementCollection
    {
        #region Constructors
        static TemplateElementCollection()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        public TemplateElementCollection()
        {
        }
        #endregion

        #region Fields
        private static ConfigurationPropertyCollection m_properties;
        #endregion

        #region Properties
        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        #endregion

        #region Indexers
        public TemplateElement this[int index]
        {
            get { return (TemplateElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public TemplateElement this[string name]
        {
            get { return (TemplateElement)base.BaseGet(name); }
        }
        #endregion

        #region Overrides
        protected override ConfigurationElement CreateNewElement()
        {
            return new TemplateElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as TemplateElement).Name;
        }
        #endregion
    }
}
