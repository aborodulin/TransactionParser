using System.Configuration;
using ParserConfiguration;

namespace TransactionParser
{
    using System;
    using System.Collections.Generic;
    using TransactionParser.Entities;

    public class Program
    {
        static void Main(String[] args)
        {
            if (args == null || args.Length <= 0)
            {
                ShowHelp();
                return;
            }

            if (args[0] == "/?" || args[0] == "?" || args[0] == "man")
            {
                ShowHelp();
                return;
            }

            //args[0] = @"C:\My\test_cutoff.mbox";

            TemplateSection section = ConfigurationManager.GetSection("TemplateGroup/TemplateSection") as TemplateSection;
            Parser parser = new Parser(section);

            List<Transaction> transactions;
            if (parser.TryParse(args[0], out transactions))
            {
                Console.WriteLine("Count transactions:{0}", transactions.Count);
            }

            Console.ReadLine();
        }

        static void ShowHelp()
        {
            //TODO
            Console.WriteLine("How it works.");
        }
    }
}
