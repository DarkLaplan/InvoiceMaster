using System.IO;
using System.Text;
using System.Xml.Linq;
using InvoicerTemporary.Properties;

namespace InvoicerTemporary.Parser
{
    public class InvoiceParser
    {
        public void ParseInvoiceStructure(string path)
        {
            var newPath = File.ReadAllText(path, Encoding.Default)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty);
            var document = XDocument.Parse(newPath);
            var root = document.Root;
            var name = root?.Attribute(Resources.Xml_Attribute_Name);
            var address = root?.Attribute(Resources.Xml_Attribute_Address);
            var city = root?.Attribute(Resources.Xml_Attribute_City);
            var postNumber = root?.Attribute(Resources.Xml_Attribute_PostNumber);
            var ico = root?.Attribute(Resources.Xml_Attribute_ICO);
            var dic = root?.Attribute(Resources.Xml_Attribute_DIC);
            var bankAccountNumber = root?.Attribute(Resources.Xml_Attribute_BankAccountNumber);
            var bankName = root?.Attribute(Resources.Xml_Attribute_BankName);
        }
    }
}
