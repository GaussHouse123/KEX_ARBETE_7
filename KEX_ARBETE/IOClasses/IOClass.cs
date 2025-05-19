using KEX_ARBETE.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace KEX_ARBETE.IOClasses
{
    /// <summary>
    /// A class that handles the connetion between the program and foreign applications, such as Microsoft Excel.
    /// </summary>
    public static class IOClass
    {
        private const int HuvudlagerCol = 2;
        private const int LeverantörCol = 3;
        private const int ArtikelbenämningCol = 5;
        private const int LeverantörArtNrCol = 6;

        /// <summary>
        /// Loads the data saved previously in a savefile.
        /// </summary>
        /// <returns> The MainProgram that the user wants to load.</returns>
        public static MainProgram LoadData()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MAH program files (*.MAH)|*.MAH";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return null;

            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            string selectedFileName = openFileDialog1.FileName;
            string jsonData = File.ReadAllText(selectedFileName);
            MainProgram mainProgram = JsonSerializer.Deserialize<MainProgram>(jsonData, options);
            return mainProgram;
        }

        /// <summary>
        /// Saves the data stored in the program.
        /// </summary>
        /// <param name="programToSave">The program to be saved.</param>
        public static void SaveData(MainProgram programToSave)
        {
            Stream myStream;
            string filePath = "";
            string jsonString = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "MAH program files (*.MAH)|*.MAH";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (myStream = saveFileDialog1.OpenFile())
                {
                    if (myStream != null)
                    {
                        var options = new JsonSerializerOptions()
                        {
                            IncludeFields = true,
                        };

                        filePath = saveFileDialog1.FileName;
                        jsonString = JsonSerializer.Serialize(programToSave, options);
                    }
                }
                File.WriteAllText(filePath, jsonString);
                myStream.Close();
            }
        }

        /// <summary>
        /// Lets the user choose an excel-file and then loads the data from it.
        /// </summary>
        /// <param name="currentMainProgram">The program that the data from Microsoft Excel should be loaded into.</param>
        /// <param name="firstRow">The first row in the excel-file that the user wants to load.</param>
        public static void LoadDataFromExcel(MainProgram currentMainProgram, int firstRow)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                Excel._Worksheet xlWorksheet1 = xlWorkbook.Sheets[1];
                Excel.Range xlRange1 = xlWorksheet1.UsedRange;

                List<string> huvudlagers = new List<string>();
                List<string> leverantörer = new List<string>();
                List<string> artikelbenämningar = new List<string>();
                List<string> leverantörArtNrs = new List<string>();

                int productCounter = 0;
                int row = 0;

                while (xlRange1.Cells[firstRow + row, ArtikelbenämningCol] != null && xlRange1.Cells[firstRow + row, ArtikelbenämningCol].Value2 != null)
                {
                    huvudlagers.Add(xlRange1.Cells[firstRow + row, HuvudlagerCol].Value2());
                    leverantörer.Add(xlRange1.Cells[firstRow + row, LeverantörCol].Value2());
                    artikelbenämningar.Add(xlRange1.Cells[firstRow + row, ArtikelbenämningCol].Value2());
                    leverantörArtNrs.Add(xlRange1.Cells[firstRow + row, LeverantörArtNrCol].Value2());

                    productCounter++;
                    row++;
                }

                for (int i = 0; i < productCounter; i++)
                {
                    Product newProduct = new Product(huvudlagers[i], leverantörer[i], artikelbenämningar[i], leverantörArtNrs[i], false);
                    currentMainProgram.unassignedProducts.Add(newProduct);
                }

                huvudlagers.Clear();
                leverantörer.Clear();
                artikelbenämningar.Clear();
                leverantörArtNrs.Clear();

                Marshal.ReleaseComObject(xlRange1);
                Marshal.ReleaseComObject(xlWorksheet1);

                Excel._Worksheet xlWorksheet2 = xlWorkbook.Sheets[2];
                Excel.Range xlRange2 = xlWorksheet2.UsedRange;

                int extraCounter = 0;
                row = 0;

                while (xlRange2.Cells[firstRow + row, ArtikelbenämningCol] != null && xlRange2.Cells[firstRow + row, ArtikelbenämningCol].Value2 != null)
                {
                    huvudlagers.Add(xlRange2.Cells[firstRow + row, HuvudlagerCol].Value2());
                    leverantörer.Add(xlRange2.Cells[firstRow + row, LeverantörCol].Value2());
                    artikelbenämningar.Add(xlRange2.Cells[firstRow + row, ArtikelbenämningCol].Value2());
                    leverantörArtNrs.Add(xlRange2.Cells[firstRow + row, LeverantörArtNrCol].Value2());

                    extraCounter++;
                    row++;
                }

                for (int i = 0; i < extraCounter; i++)
                {
                    UnassignedExtra newExtra = new UnassignedExtra(huvudlagers[i], leverantörer[i], artikelbenämningar[i], leverantörArtNrs[i], false);
                    currentMainProgram.unassignedExtras.Add(newExtra);
                }

                Marshal.ReleaseComObject(xlRange2);
                Marshal.ReleaseComObject(xlWorksheet2);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                xlWorkbook.Close(0);
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                //currentMainProgram.ProductStartingRow = currentMainProgram.ProductStartingRow + productCounter;
                //currentMainProgram.ExtraStartingRow = currentMainProgram.ExtraStartingRow + extraCounter;

                /*

                while (xlRange1.Cells[currentMainProgram.ProductStartingRow + row, ArtikelbenämningCol] != null && xlRange1.Cells[currentMainProgram.ProductStartingRow + row, ArtikelbenämningCol].Value2 != null)
                {
                    huvudlagers.Add(xlRange1.Cells[currentMainProgram.ProductStartingRow + row, HuvudlagerCol].Value2());
                    leverantörer.Add(xlRange1.Cells[currentMainProgram.ProductStartingRow + row, LeverantörCol].Value2());
                    artikelbenämningar.Add(xlRange1.Cells[currentMainProgram.ProductStartingRow + row, ArtikelbenämningCol].Value2());
                    leverantörArtNrs.Add(xlRange1.Cells[currentMainProgram.ProductStartingRow + row, LeverantörArtNrCol].Value2());

                    productCounter++;
                    row++;
                }

                for (int i = 0; i < productCounter; i++)
                {
                    Product newProduct = new Product(huvudlagers[i], leverantörer[i], artikelbenämningar[i], leverantörArtNrs[i], false);
                    currentMainProgram.unassignedProducts.Add(newProduct);
                }

                huvudlagers.Clear();
                leverantörer.Clear();
                artikelbenämningar.Clear();
                leverantörArtNrs.Clear();

                Marshal.ReleaseComObject(xlRange1);
                Marshal.ReleaseComObject(xlWorksheet1);

                Excel._Worksheet xlWorksheet2 = xlWorkbook.Sheets[2];
                Excel.Range xlRange2 = xlWorksheet2.UsedRange;

                int extraCounter = 0;
                row = 0;

                while (xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, ArtikelbenämningCol] != null && xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, ArtikelbenämningCol].Value2 != null)
                {
                    huvudlagers.Add(xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, HuvudlagerCol].Value2());
                    leverantörer.Add(xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, LeverantörCol].Value2());
                    artikelbenämningar.Add(xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, ArtikelbenämningCol].Value2());
                    leverantörArtNrs.Add(xlRange2.Cells[currentMainProgram.ExtraStartingRow + row, LeverantörArtNrCol].Value2());

                    extraCounter++;
                    row++;
                }

                for (int i = 0; i < extraCounter; i++)
                {
                    UnassignedExtra newExtra = new UnassignedExtra(huvudlagers[i], leverantörer[i], artikelbenämningar[i], leverantörArtNrs[i], false);
                    currentMainProgram.unassignedExtras.Add(newExtra);
                }

                Marshal.ReleaseComObject(xlRange2);
                Marshal.ReleaseComObject(xlWorksheet2);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                xlWorkbook.Close(0);
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                currentMainProgram.ProductStartingRow = currentMainProgram.ProductStartingRow + productCounter;
                currentMainProgram.ExtraStartingRow = currentMainProgram.ExtraStartingRow + extraCounter;

                */
            }
        }
    }
}
