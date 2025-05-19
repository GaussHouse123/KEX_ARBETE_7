using KEX_ARBETE;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Model
{
    [Serializable]
    public class Product : IAssignable
    {
        public string Huvudlager { get; set; }
        public string Leverantör { get; set; }
        public string Artikelbenämning { get; set; }
        public string LeverantörArtikelNr { get; set; }
        public string Comment { get; set; }
        public Boolean IsAssigned { get; set; }

        public List<Accessory> accessories;
        public List<Spare> spares;

        public Product(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr, string comment, Boolean isAssigned)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = comment;
            this.IsAssigned = isAssigned;

            this.accessories = new List<Accessory>();
            this.spares = new List<Spare>();
        }

        public Product(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr, Boolean isAssigned)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = "";
            this.IsAssigned = isAssigned;

            this.accessories = new List<Accessory>();
            this.spares = new List<Spare>();
        }

        public Product(string huvudlager, string leverantör, string artikelbenämning, string leverantörArtikelNr)
        {
            this.Huvudlager = huvudlager;
            this.Leverantör = leverantör;
            this.Artikelbenämning = artikelbenämning;
            this.LeverantörArtikelNr = leverantörArtikelNr;
            this.Comment = "";
            this.IsAssigned = false;

            this.accessories = new List<Accessory>();
            this.spares = new List<Spare>();
        }

        public Product()
        {
            this.Huvudlager = "";
            this.Leverantör = "";
            this.Artikelbenämning = "";
            this.LeverantörArtikelNr = "";
            this.Comment = "";
            this.IsAssigned = false;

            this.accessories = new List<Accessory>();
            this.spares = new List<Spare>();
        }

        /// <summary>
        /// Retrieves the accessory specified by the position in the accessory list.
        /// </summary>
        /// <param name="index"> The position the wanted accessory has in the accessory list.</param>
        /// <returns>The accessory at the position in the accessory list specified by the index.</returns>
        public Accessory GetAccessoryByIndex(int index)
        {
            return accessories[index];
        }

        /// <summary>
        /// Retrieves the spare specified by the position in the spare list.
        /// </summary>
        /// <param name="index"> The position the wanted spare has in the spare list.</param>
        /// <returns>The spare at the position in the spare list specified by the index.</returns>
        public Spare GetSpareByIndex(int index)
        {
            return spares[index];
        }

        /// <summary>
        /// Retrieves the list of accessories.
        /// </summary>
        /// <returns>A list of accessories that belongs to a product.</returns>
        public List<Accessory> GetAccessories()
        {
            return accessories;
        }

        /// <summary>
        /// Retrieves the list of spares.
        /// </summary>
        /// <returns>A list of spares that belongs to a product.</returns>
        public List<Spare> GetSpares()
        {
            return spares;
        }

        /// <summary>
        /// Adds an accessory to the list of accessories.
        /// </summary>
        /// <param name="accessoryToAdd"> The accessory that should be added.</param>
        public void AddAccessory(Accessory accessoryToAdd)
        {
            accessories.Add(accessoryToAdd);
        }

        /// <summary>
        /// Adds a spare to the list of spares.
        /// </summary>
        /// <param name="spareToAdd"> The spare that should be added.</param>
        public void AddSpare(Spare spareToAdd)
        {
            spares.Add(spareToAdd);
        }

        /// <summary>
        /// Removes an accessory from the list of accessories if the specified accessory exists in the list.
        /// </summary>
        /// <param name="accessoryToRemove">The accessory to remove.</param>
        /// <returns>True if the specified accessory exists in the accessory list, otherwise false.</returns>
        public Boolean RemoveAccessory(Accessory accessoryToRemove)
        {
            if (accessories.Contains(accessoryToRemove))
            {
                accessories.Remove(accessoryToRemove);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a spare from the list of spares if the specified spare exists in the list.
        /// </summary>
        /// <param name="spareToRemove">The spare to remove.</param>
        /// <returns>True if the specified spare exists in the spare list, otherwise false.</returns>
        public Boolean RemoveSpare(Spare spareToRemove)
        {
            if (spares.Contains(spareToRemove))
            {
                spares.Remove(spareToRemove);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes an accessory from the list of accessories.
        /// </summary>
        /// <param name="index">The index of the accessory in the accessory list that should be removed.</param>
        public void RemoveAccessoryByIndex(int index)
        {
            accessories.RemoveAt(index);
        }

        /// <summary>
        /// Removes a spare from the list of spares.
        /// </summary>
        /// <param name="index">The index of the spare in the spare list that should be removed.</param>
        public void RemoveSpareByIndex(int index)
        {
            spares.RemoveAt(index);
        }
    }
}
