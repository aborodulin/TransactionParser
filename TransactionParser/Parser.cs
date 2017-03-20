using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ParserConfiguration;
using TransactionParser.Entities;

namespace TransactionParser
{
    internal class Parser
    {
        public const String Version = "0.2";
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Parser(TemplateSection configuration)
        {
            this.Configuration = configuration;
        }

        #region Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public TemplateSection Configuration { get; private set; }

        #endregion Properties

        #region Public

        /// <summary>
        /// Parses the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="transactions">The transactions.</param>
        /// <returns></returns>
        public Boolean TryParse(String filePath, out List<Transaction> transactions)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            transactions = new List<Transaction>();

            IEnumerable<String> lines = this.ReadLines(filePath);
            Int32 allCount = lines.Count();

            Console.WriteLine("Read:{0} all lines", allCount);

            for (Int32 i = 0; i < allCount; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine("Processing:{0} line, {1}", i, (i / allCount).ToString("F"));
                }

                Int32 getNumberLines = i + this.Configuration.MessageLines > allCount ? allCount - i : this.Configuration.MessageLines;

                if (i > allCount)
                {
                    break;
                }

                try
                {
                    String message = String.Join("", lines.Skip(i).Take(getNumberLines)).Replace("\r\n", "").Replace("\n", "").Replace("  ", " ").Replace("  ", "");

                    Transaction transaction;

                    if (Transaction.TryParseTransaction(message, this.Configuration.Templates, out transaction))
                    {
                        transactions.Add(transaction);
                        i += this.Configuration.MessageLines;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Error on parsing line:");
                    //Console.WriteLine("---{0}", message);
                }
            }

            return true;
        }

        #endregion Public

        #region Private

        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private IEnumerable<String> ReadLines(String filePath)
        {
            Encoding encoding = String.IsNullOrEmpty(this.Configuration.InputCodePage) ? Encoding.ASCII : Encoding.GetEncoding(Configuration.InputCodePage);
            return File.ReadLines(filePath, encoding);
        }

        #endregion Private



    }
}
