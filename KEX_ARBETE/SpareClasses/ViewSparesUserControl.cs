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
    public partial class ViewSparesUserControl : UserControl, IMenu
    {
        private string directory;

        private AddSpareForm addSpareForm;
        private Product product;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images;
        private List<Button> buttons;

        public Boolean IsShown { get; set; }
        public Boolean WasLastShown { get; set; }
        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        

        public event EventHandler EnterSpareInfoViewEventHandler;

        public ViewSparesUserControl()
        {
            InitializeComponent();
            this.directory = "";
            this.product = new Product();
            this.images = new List<PictureBox>();
            this.buttons = new List<Button>();
        }

        /// <summary>
        /// Hides the current user control.
        /// </summary>
        public void HideUserControl()
        {
            this.Hide();
        }

        /// <summary>
        /// Shows the current user control.
        /// </summary>
        public void ShowUserControl()
        {
            this.Show();
        }

        /// <summary>
        /// Shows how to navigate the current page.
        /// </summary>
        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är reservdelsmenyn. Denna visar alla reservdelar för det huvudhjälpmedel du valt." +
                "Klickar du på en specifik reservdel kommer information visas för den reservdelen." +
                "Du kan även lägga till nya reservdelar.", "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        /// <summary>
        /// Sets the current type to the type that was entered when using the main menu.
        /// </summary>
        /// <param name="currentType">The type that should be viewed.</param>
        public void SetProduct(Product currentProduct)
        {
            this.product = currentProduct;
            this.titleLabel.Text = "Reservdelsmeny för huvudhjälpmedlet " + product.Artikelbenämning;
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;

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
        /// Opens AddSpareForm to add a spare.
        /// </summary>
        ///       
        public void AddSpare()
        {
            this.addSpareForm = new AddSpareForm(product, CurrentTheme);
            var result = addSpareForm.ShowDialog();
            if (result == DialogResult.OK)
                AddButton();
        }

        /// <summary>
        /// Sets the title of the form.
        /// </summary>
        /// <param name="choosenEvent">The current type of the enum EventChooser that dictates what the title should be.</param>
        public void SetTitle(EventChooser choosenEvent)
        {
            if (choosenEvent == EventChooser.Assigning)
            {
                titleLabel.Text = "Navigera till den artikel/reservdel du vill tilldela";
            }
            else if (choosenEvent == EventChooser.Adding)
            {
                titleLabel.Text = "Navigera till det tillbehör/reservdel du vill lägga till";

            }
            else if (choosenEvent == EventChooser.Normal)
            {
                titleLabel.Text = "Produktmeny";

            }
        }

        /// <summary>
        /// Initializes all the graphical components that is required for the current type, as well as load model data into the graphics.
        /// </summary>
        private void InitializeButtons()
        {
            int i = 0;
            int j = 0;

            while (i < product.GetSpares().Count)
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
                newButton.Text = product.GetSpareByIndex(i).Artikelbenämning;
                newButton.Font = new Font("Microsoft Sans Serif", 12);
                newButton.Name = buttonName;
                newButton.Width = 223;
                newButton.Height = 61;

                images.Add(newPictureBox);
                buttons.Add(newButton);

                buttons[i].Click += new System.EventHandler(this.OnSpareButtonClick);

                string spareName = product.GetSpareByIndex(i).Artikelbenämning;
                string sparePictureDirectory = directory + "\\" + spareName;

                if (newPictureBox.Image != null)
                    newPictureBox.Image.Dispose();
                else
                    newPictureBox.Image = null;

                try
                {
                    if (Directory.Exists(sparePictureDirectory))
                    {
                        string[] tempArray = Directory.GetFiles(sparePictureDirectory);
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
        }

        /// <summary>
        /// Adds a button to the control if the user decides to add a spare.
        /// </summary>
        private void AddButton()
        {
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        // EventHandlers

        private void OnSpareButtonClick(object sender, EventArgs e)
        {
            EnterSpareInfoViewEventHandler?.Invoke(sender, e);
        }
    }
}
