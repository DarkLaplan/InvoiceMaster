using System;

namespace InvoiceMaster
{
    public class PdfManipulator
    {
        public PdfManipulator(string path)
        {
            PathToFile = path;
        }

        string PathToFile { get; set; }

        public void CreateNewFile()
        {
            throw new NotImplementedException();
        }
    }
}
