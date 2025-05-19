using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    /// <summary>
    /// The UserControl that shows all the accessories for a given product.
    /// </summary>
    public partial class ViewAccessoriesUserControl : UserControl, IMenu
    {
        private string directory;

        private Product product;
        private AddAccessoryForm addAccessoryForm;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images;
        private List<Button> buttons;

        public event EventHandler EnterAccessoryInfoViewEventHandler;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor for the ViewAccessoriesUserControl
        /// </summary>
        public ViewAccessoriesUserControl()
        {
            InitializeComponent();
            this.directory = "";
            this.CurrentTheme = new Theme();
            this.product = new Product();
            this.images = new List<PictureBox>();
            this.buttons = new List<Button>();
        }

        // ------------------------- Implemented from IMenu -------------------------

        public Boolean IsShown { get; set; }

        public Boolean WasLastShown { get; set; }

        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        public void ShowUserControl()
        {
            this.Show();
        }

        public void HideUserControl()
        {
            this.Hide();
        }

        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är tillbehörmenyn. Denna visar alla tillbehör för det huvudhjälpmedel du valt." +
                "Klickar du på ett specifikt tillbehör kommer information visas för det tillbehöret." +
                "Du kan även lägga till nya tillbehör.", "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        // ------------------------- Methods -------------------------

        /// <summary>
        /// Sets the current product of which the accessories should be viewed.
        /// </summary>
        /// <param name="currentType">The product that contains the accessories that should be viewed.</param>
        public void SetProduct(Product currentProduct)
        {
            this.product = currentProduct;
            this.titleLabel.Text = "Tillbehörsmenyn för huvudhjälpmedlet " + product.Artikelbenämning;
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        /// <summary>
        /// Clears the controls and dispose of all images.
        /// </summary>
        public void ClearControls()
        {
            while (tableLayoutPanel1.Controls.Count > 0)
            {
                tableLayoutPanel1.Controls[0].Dispose();
            }

            tableLayoutPanel1.RowCount = 1;

            for (int i = 0; i < images.Count; i++)
            {
                images[i].Dispose();
            }

            images.Clear();
            buttons.Clear();
        }

        /// <summary>
        /// Opens AddAccessoryForm
        /// </summary>     
        public void AddAccessory()
        {
            this.addAccessoryForm = new AddAccessoryForm(product, CurrentTheme);
            var result = addAccessoryForm.ShowDialog();
            if (result == DialogResult.OK)
                AddButton();
        }
      
        /// <summary>
        /// Sets the path to the directory that contains the images.
        /// </summary>
        /// <param name="folderDirectory">The directory to the images.</param>
        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;
        }

        /// <summary>
        /// Creates all necessary buttons and images that is needed.
        /// </summary>
        private void InitializeButtons()
        {
            int i = 0;
            int j = 0;

            while (i < product.GetAccessories().Count)
            {
                PictureBox newPictureBox = new PictureBox();
                Button newButton = new Button();
                Panel newPanel = new Panel();

                string pictureBoxName = string.Concat("pictureBox", (i + 1).ToString());
                string buttonName = string.Concat("button", (i + 1).ToString());
                string panelName = string.Concat("panel", (i + 1).ToString());

                newPanel.Controls.Add(newPictureBox);
                newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                newPictureBox.Dock = DockStyle.Fill;
                newPictureBox.Name = pictureBoxName;

                newPanel.Controls.Add(newButton);
                newButton.Dock = DockStyle.Bottom;
                newButton.Text = product.GetAccessoryByIndex(i).Artikelbenämning;
                newButton.Font = new Font("Microsoft Sans Serif", 12);
                newButton.Name = buttonName;
                newButton.Width = 223;
                newButton.Height = 61;

                images.Add(newPictureBox);
                buttons.Add(newButton);

                buttons[i].Click += new System.EventHandler(this.OnAccessoryButtonClick);

                string accessoryName = product.GetAccessoryByIndex(i).Artikelbenämning;
                string accessoryPictureDirectory = directory + "\\" + accessoryName;

                if (newPictureBox.Image != null)
                    newPictureBox.Image.Dispose();
                else
                    newPictureBox.Image = null;

                try
                {
                    if (Directory.Exists(accessoryPictureDirectory))
                    {
                        string[] tempArray = Directory.GetFiles(accessoryPictureDirectory);
                        fileEntries = tempArray.ToList<string>();
                        string imageLocation = fileEntries[0];

                        Image img;

                        using (var bmpTemp = new Bitmap(imageLocation))
                        {
                            img = new Bitmap(bmpTemp);
                        }

                        newPictureBox.Image = img;
                    }
                }
                catch (Exception) { }

                if (((i % 4) == 0) && i != 0)
                {
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
                    tableLayoutPanel1.Controls.Add(newPanel, 0, tableLayoutPanel1.RowCount - 1);
                    newPanel.Dock = DockStyle.Fill;
                    j = 1;
                }
                else
                {
                    tableLayoutPanel1.Controls.Add(newPanel, j, tableLayoutPanel1.RowCount - 1);
                    newPanel.Dock = DockStyle.Fill;
                    j++;
                }
                i++;
            }
            ;
            ApplyThemeToUserControl();
        }

        /// <summary>
        /// Adds a button to the list of buttons, then loads the UserControl again.
        /// </summary>
        private void AddButton()
        {
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        // ------------------------- EventHandlers -------------------------

        private void OnAccessoryButtonClick(object sender, EventArgs e)
        {
            EnterAccessoryInfoViewEventHandler?.Invoke(sender, e);
        }
    }
}
