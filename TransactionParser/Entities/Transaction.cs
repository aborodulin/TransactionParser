namespace TransactionParser.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        /// <returns></returns>
        public static Boolean IsTransaction(String line)
        {
            return line.Contains(Template.Default.Type);
        }

        /// <summary>
        /// Tries the parse transaction.
        /// </summary>
        /// <param name="line">The lines.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        public static Boolean TryParseTransaction(String line, out Transaction transaction)
        {
            if (Transaction.IsTransaction(line))
            {
                transaction = new Transaction(line);
                return true;
            }

            transaction = null;
            return false;
        }

        #endregion Public


    }
}
