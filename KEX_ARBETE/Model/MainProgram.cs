using KEX_ARBETE;
using KEX_ARBETE.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using KEX_ARBETE.IOClasses;
using KEX_ARBETE.OtherForms;




namespace WindowsFormsApp1.Model
{
    [Serializable]
    public class MainProgram
    {   
        public int ProductStartingRow { get; set; }
        public int ExtraStartingRow { get; set; }
        public string Password { get; set; }
        public string Directory { get; set; }

        public List<Type> types;
        public List<Product> unassignedProducts;
        public List<UnassignedExtra> unassignedExtras;

        public MainProgram()
        {
            this.ProductStartingRow = 7;
            this.ExtraStartingRow = 7;
            this.Password = "1234";
            this.Directory = "";
            this.types = new List<Type>();
            this.unassignedProducts = new List<Product>();
            this.unassignedExtras = new List<UnassignedExtra>();
        }

        public void InitilizeData()
        {
            types.Add(new Type("CPAP"));
            types.Add(new Type("Bilevel"));
            types.Add(new Type("Ventilatorer"));
            types.Add(new Type("Inhalatorer"));
            types.Add(new Type("Syrgaskoncentratorer"));
            types.Add(new Type("Pulsoximeter"));
            types.Add(new Type("Kompressionpump"));
            types.Add(new Type("Slemsugar"));
            types.Add(new Type("Andningsballonger"));
            types.Add(new Type("Andningsmuskeltränare"));
            types.Add(new Type("Nutritionspumpar"));
            types.Add(new Type("Infusionspumpar"));
            types.Add(new Type("Blod koag. mätare"));
            types.Add(new Type("Apnélarm"));
            types.Add(new Type("TENS"));
            types.Add(new Type("EP-larm"));
            types.Add(new Type("Övrigt"));
        }
  
        public void AddType(Type typeToAdd)
        {
            this.types.Add(typeToAdd);
        }

        public void RemoveTypeByIndex(int index)
        {
            this.types.RemoveAt(index);
        }

        /// <summary>
        /// Retrieves the types.
        /// </summary>
        /// <returns>The types.</returns>
        public List<Type> GetTypes()
        {
            return types;
        }

        /// <summary>
        /// Retrieves a specific type based on the position in the type list.
        /// </summary>
        /// <param name="index">The index that specifies the position of the wanted type in the list.</param>
        /// <returns>The type that is on the position given by index in the type list.</returns>
        public Type GetTypeByIndex(int index)
        {
            return types[index];
        }

    

        public List<Product> GetUnassignedProducts()
        {
            return unassignedProducts;
        }

        public List<UnassignedExtra> GetUnassignedExtras()
        {
            return this.unassignedExtras;
        }

        public void RemoveProductByName(string name)
        {
            foreach (Product product in unassignedProducts)
            {
                if (product.Artikelbenämning == name)
                {
                    unassignedProducts.Remove(product);
                    return;
                }
            }
        }

        public void RemoveUnassignedExtraByName(string name)
        {
            foreach (UnassignedExtra unassignedExtra in unassignedExtras)
            {
                if (unassignedExtra.Artikelbenämning == name)
                {
                    unassignedExtras.Remove(unassignedExtra);
                    return;
                }
            }
        }
    }
}
