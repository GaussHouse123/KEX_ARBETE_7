using System;

namespace KEX_ARBETE
{
    /// <summary>
    /// An interface representing all objects that can be assigned to either a catagory or a product.
    /// </summary>
    public interface IAssignable
    {
        /// <summary>
        /// Represents an item's Huvudlager.
        /// </summary>
        string Huvudlager { get; set; }

        /// <summary>
        /// Represents an item's Leverantör.
        /// </summary>
        string Leverantör { get; set; }

        /// <summary>
        /// Represents an item's Artikelbenämning.
        /// </summary>
        string Artikelbenämning { get; set; }

        /// <summary>
        /// Represents an item's Leverantörs Artikelnummer.
        /// </summary>
        string LeverantörArtikelNr { get; set; }

        /// <summary>
        /// Represents an item's Kommenterar.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// Represents if an item is assigned to a type or a product.
        /// </summary>
        Boolean IsAssigned { get; set; }
    }
}
