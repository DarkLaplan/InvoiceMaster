using InvoicerTemporary.Parser;
using System;

namespace InvoicerTemporary
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new InvoiceParser();
            parser.ParseInvoiceStructure(@"C:\Users\michal.lansky\OneDrive - ComAp a.s\Desktop\MainSupplier.xml");
            Console.WriteLine(@"File was loaded.");
            Console.ReadKey();
        }
    }
}
