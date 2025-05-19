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
    public partial class ViewProductUserControl : UserControl, IMenu
    {
        private string directory;

        private AddProductForm addProductForm;
        private WindowsFormsApp1.Model.Type type;
        private Theme currentTheme;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images;
        private List<Button> buttons;

        public Boolean IsShown { get; set; }
        public Boolean WasLastShown { get; set; }
        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        public event EventHandler EnterProductInfoViewEventHandler;
        public event EventHandler AssignProductEventHandler;

        public ViewProductUserControl()
        {
            InitializeComponent();
            this.directory = "";
            this.type = new WindowsFormsApp1.Model.Type();
            this.images = new List<PictureBox>();
            this.currentTheme = new Theme();
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
            DialogResult result = MessageBox.Show("Detta är huvudhjälpmedelsmenyn. Här ser du alla huvudhjälpmedel som tillhör den kategori du tidigare klickat på." +
                " Om du klickar på ett huvudhjälpmedel visas information för det huvudhjälpmedlet. Tryck på lägg till om du vill lägga till ett huvudhjälpmedel." +
                " Tryck på back om du vill återgå till huvudmenyn.", "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sets the current type to the type that was entered when using the main menu.
        /// </summary>
        /// <param name="currentType">The type that should be viewed.</param>
        public void SetType(WindowsFormsApp1.Model.Type currentType, Theme theme)
        {
            this.type = currentType;
            this.currentTheme = theme;
            this.titleLabel.Text = "Huvudhjälpmedelsmenyn för kategorin " + currentType.Name;
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        /// <summary>
        /// Sets what event should fire when a button is pressed.
        /// </summary>
        /// <param name="choosenEvent">The current type of the enum EventChooser that dictates which event should fire.</param>
        public void SetEvents(EventChooser choosenEvent)
        {
            if (choosenEvent == EventChooser.Assigning)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].Click -= new System.EventHandler(this.OnProductButtonClick);
                    buttons[i].Click += new System.EventHandler(this.AssignProductEventHandler);
                }
            }

            if (choosenEvent == EventChooser.Adding)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].Click -= new System.EventHandler(OnProductButtonClick);
                    buttons[i].Click += new System.EventHandler(OnProductButtonClickWhenAddingAccessory);
                }
            }
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

        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;
        }

        /// <summary>
        /// Initializes all the graphical components that is required for the current type, as well as load model data into the graphics.
        /// </summary>
        private void InitializeButtons()
        {
            int i = 0;
            int j = 0;

            while (i < type.GetProducts().Count)
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
                newButton.Text = type.GetProductByIndex(i).Artikelbenämning;
                newButton.Font = new Font("Microsoft Sans Serif", 12);
                newButton.Name = buttonName;
                newButton.Width = 223;
                newButton.Height = 61;

                images.Add(newPictureBox);
                buttons.Add(newButton);

                buttons[i].Click += new System.EventHandler(this.OnProductButtonClick);

                string productName = type.GetProductByIndex(i).Artikelbenämning;
                string productPictureDirectory = directory + "\\" + productName;

                if (newPictureBox.Image != null)
                    newPictureBox.Image.Dispose();
                else
                    newPictureBox.Image = null;

                try
                {
                    if (Directory.Exists(productPictureDirectory))
                    {
                        string[] tempArray = Directory.GetFiles(productPictureDirectory);
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
        /// Opens the add product form and adjusts graphical components so that to match the newly added product.
        /// </summary>
        public void AddProduct()
        {
            this.addProductForm = new AddProductForm(type, CurrentTheme);
            var result = addProductForm.ShowDialog();
            if (result == DialogResult.OK)
                AddButton();
        }

        /// <summary>
        /// Adds a button to the control if the user decides to add a product.
        /// </summary>
        private void AddButton()
        {
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        // EventHandlers

        private void OnProductButtonClick(object sender, EventArgs e)
        {
            EnterProductInfoViewEventHandler?.Invoke(sender, e);
        }

        private void OnProductButtonClickAssigned(object sender, EventArgs e)
        {
            AssignProductEventHandler?.Invoke(sender, e);
        }

        private void OnProductButtonClickWhenAddingAccessory(object sender, EventArgs e)
        {
            EnterProductInfoViewEventHandler?.Invoke(sender, e);
        }
    }
}