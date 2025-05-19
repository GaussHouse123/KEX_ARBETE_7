using KEX_ARBETE;
using System;

namespace WindowsFormsApp1.Model
{
    [Serializable]
    public class Spare : IAssignable
    {
        public string Huvudlager { get; set; }
        public string Leverantör { get; set; }
        public string Artikelbenämning { get; set; }
        public string LeverantörArtikelNr { get; set; }
        public string Comment { get; set; }
        public Boolean IsAssigned { get; set; }

        public Spare(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr, string comment, Boolean isAssigned)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = comment;
            this.IsAssigned = isAssigned;
        }
        public Spare(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr, Boolean isAssigned)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = "";
            this.IsAssigned = isAssigned;
        }

        public Spare(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = "";
            this.IsAssigned = false;
        }
        public Spare()
        {
            this.Huvudlager = "";
            this.Leverantör = "";
            this.Artikelbenämning = "";
            this.LeverantörArtikelNr = "";
            this.Comment = "";
            this.IsAssigned = false;
        }
    }
}
