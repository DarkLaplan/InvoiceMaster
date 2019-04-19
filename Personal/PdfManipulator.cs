using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTextSharp.text.pdf.parser;

namespace InvoicerTemporary
{
    public class PdfManipulator
    {
        private const int FirstTablePosition = 760;
        private const int SecondTablePosition = 600;
        private const int FirstColumnPosition = 60;
        private const int SecondColumnPosition = 320;
        private const float BorderThickness = 1.5f;

        public void ReadPdf()
        {
            var pdfReader = new PdfReader(@"C:\Users\michal.lansky\source\repos\InvoicerTemporary\InvoicerTemporary\bin\Debug\Faktura1.pdf");

            for (int i = 0; i < pdfReader.NumberOfPages; i++)
            {
                var locationTextExtractionStrategy = new LocationTextExtractionStrategy();

                string textFromPage = PdfTextExtractor.GetTextFromPage(pdfReader, i + 1, locationTextExtractionStrategy);

                textFromPage = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textFromPage)));

                //Do Something with the text
            }
        }

        public void CreatePdf()
        {
            var fileStream = new FileStream("Faktura1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var doc = new Document();
            var writer = PdfWriter.GetInstance(doc, fileStream);
            doc.Open();
            doc.Add(new Paragraph("Faktura."));
            AddTables(doc, writer);
            doc.Close();
        }

        /// <summary>
        /// Sets pdf properties to file.
        /// </summary>
        private void PdfProperties(Document doc)
        {
            doc.AddTitle("");
            doc.AddSubject("");
            doc.AddKeywords("");
            doc.AddCreationDate();
            doc.AddAuthor("");
        }

        private void AddTables(Document doc, PdfWriter writer)
        {
            var czechLanguage = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250);
            var table = new PdfPTable(1);
            table.TotalWidth = 216f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 0;
            var cell = new PdfPCell(new Phrase("Dodavatel."))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table.AddCell(cell);

            AddRow(table, new List<string>
            {
                "Zednické práce Miroslav Lánský",
                "Kozákovská 516",
                "513 01 Semily",
                "IČO: 612 21 589",
                "DIČ: CZ-7011 25/3436",
                "Peněžní ústav: KB Semily",
                "Číslo účtu: 19-1254770237/0100"
            });

            table.WriteSelectedRows(0, -1, FirstColumnPosition, FirstTablePosition, writer.DirectContent);

            var table2 = new PdfPTable(1);
            table2.TotalWidth = 216f;
            table2.LockedWidth = true;
            table2.HorizontalAlignment = 2;
            var cell2 = new PdfPCell(new Phrase("Odběratel"))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table2.AddCell(cell2);
            AddRow(table2, new List<string>
            {
                " ",
                " ",
                " ",
                " ",
                " ",
                "IČO:",
                "DIČ:"
            });
            table2.WriteSelectedRows(0, -1, SecondColumnPosition, FirstTablePosition, writer.DirectContent);

            var table3 = new PdfPTable(1);
            table3.TotalWidth = 216f;
            table3.LockedWidth = true;
            table3.HorizontalAlignment = 2;
            var cell3 = new PdfPCell(new Phrase("Platební podmínky"))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table3.AddCell(cell3);
            AddRow(table3, new List<string>
            {
                $"Den splatnosti: {DateTime.Now}",
                "Způsob úhrady:",
                "Datum vystavení:",
                "Datum uskut. zdan. plnění:"
            });
            table3.WriteSelectedRows(0, -1, SecondColumnPosition, SecondTablePosition, writer.DirectContent);

            var table4 = new PdfPTable(1);
            table4.TotalWidth = 476f;
            table4.LockedWidth = true;
            table4.HorizontalAlignment = 2;
            var cell4 = new PdfPCell(new Phrase("Odběratel"))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table4.AddCell(cell4);
            AddRow(table4, new List<string>
            {
                " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "dadad"

            });

            table4.WriteSelectedRows(0, -1, FirstColumnPosition, 500, writer.DirectContent);

            var table5 = new PdfPTable(3);
            table5.TotalWidth = 216f;
            table5.LockedWidth = true;
            table5.HorizontalAlignment = 0;
            var cell5 = new PdfPCell(new Phrase("Dodavatel."))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table5.AddCell(cell5);

            AddRow(table5, new List<string>
            {
                " ",
            });

            table5.WriteSelectedRows(0, -1, FirstColumnPosition, FirstTablePosition, writer.DirectContent);

            var table6 = new PdfPTable(1);
            table6.TotalWidth = 216f;
            table6.LockedWidth = true;
            table6.HorizontalAlignment = 0;
            var cell6 = new PdfPCell(new Phrase("Celkem k úhradě.", czechLanguage))
            {
                HorizontalAlignment = 1,
                MinimumHeight = 20,
                BorderWidthLeft = BorderThickness,
                BorderWidthRight = BorderThickness,
                BorderWidthTop = BorderThickness,
                BorderWidthBottom = BorderThickness
            };
            table6.AddCell(cell6);

            AddRow(table6, new List<string>
            {
                "20 000 Kč",
            }, 18);

            table6.WriteSelectedRows(0, -1, SecondColumnPosition, 200, writer.DirectContent);
        }


        private void AddRow(PdfPTable table, List<string> rows, int fontSize = 12)
        {
            if (rows == null) return;
            var czechLanguage = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, fontSize);
            for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                var rowCell = new PdfPCell(new Phrase(rows[rowIndex], czechLanguage))
                {
                    BorderWidthLeft = BorderThickness,
                    BorderWidthRight = BorderThickness,
                    BorderWidthTop = 0
                };

                if (rowIndex != rows.Count - 1)
                {
                    rowCell.BorderWidthBottom = 0;
                }
                else
                {
                    rowCell.BorderWidthBottom = BorderThickness;
                }

                table.AddCell(rowCell);
            }
        }
    }
}
