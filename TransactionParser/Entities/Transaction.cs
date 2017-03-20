using ParserConfiguration;

namespace TransactionParser.Entities
{
    using System;

    public class Transaction
    {
        #region Fields

        private readonly String _rawLine;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="rawLine">The raw lines.</param>
        public Transaction(String rawLine)
        {
            this._rawLine = rawLine;
        }

        #endregion Constructors

        #region Properties

        #endregion Properties

        #region Public

        /// <summary>
        /// Determines whether the specified line is transaction.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public static Boolean IsTransaction(String line, TemplateElement template)
        {
            return line.Contains(template.Type);
        }

        /// <summary>
        /// Tries the parse transaction.
        /// </summary>
        /// <param name="line">The lines.</param>
        /// <param name="templates">The templates.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        public static Boolean TryParseTransaction(String line, TemplateElementCollection templates, out Transaction transaction)
        {
            foreach (TemplateElement template in templates)
            {
                if (Transaction.IsTransaction(line, template))
                {
                    Console.WriteLine("Found temple: {0}", template.Type);
                    transaction = new Transaction(line);
                    return true;
                }

            }
            transaction = null;
            return false;
        }

        #endregion Public


    }
}
