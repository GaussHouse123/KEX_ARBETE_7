using KEX_ARBETE.MainMenuClasses;
using KEX_ARBETE.ThemeClasses;

// Microsoft.Office.Interop.Excel;
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
    /// The UserControl that shows all the types.
    /// </summary>
    public partial class MainMenuUserControl : UserControl, IMenu
    {
        private string directory;

        private Button choosenButton;

        private MainProgram mainProgram;
        private AddTypeForm addTypeForm;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images;
        private List<Button> buttons;

        public event EventHandler EnterProductViewEventHandler;
        public event EventHandler AssignProductEventHandler;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the MainMenuUserControl.
        /// </summary>
        public MainMenuUserControl()
        {
            InitializeComponent();
            UpdateAdminFeatures();
            this.directory = "";
            this.CurrentTheme = new Theme();
            this.mainProgram = new MainProgram();
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
            DialogResult result = MessageBox.Show("Detta är huvudmenyn. Här ser du alla kategorier. Varje kategori innehåller huvudhjälpmedel." +
                "Klicka på en kategori för att se dem huvudhjälpmedel kategorin innehåller.",
                "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Sets the current program of which the user wants to view.
        /// </summary>
        /// <param name="currentMainProgram">The program the user wants to see.</param>
        public void SetTypes(MainProgram currentMainProgram)
        {
            this.mainProgram = currentMainProgram;
            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        /// <summary>
        /// Sets the availability of the right-click funktion of the types.
        /// </summary>
        /// <param name="state"></param>
        public void SetContextMenuStrip(Boolean state)
        {
            contextMenuStrip1.Enabled = state;
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
        /// Sets the availability of the right-click funktion of the types, depending on if the user has admin access or not.
        /// </summary>
        public void UpdateAdminFeatures()
        {
            if (HasAdminAccess)
            {
                contextMenuStrip1.Enabled = true;
            }
            else
            {
                contextMenuStrip1.Enabled = false;
            }
        }

        /// <summary>
        /// Opens AddTypeForm
        /// </summary>
        public void AddType()
        {
            this.addTypeForm = new AddTypeForm(mainProgram, CurrentTheme);
            var result = addTypeForm.ShowDialog();
            if (result == DialogResult.OK)
                AddButton();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void SetButtonEdit(Boolean state)
        {
            contextMenuStrip1.Visible = true;

            foreach (Button button in buttons)
            {
                button.ContextMenuStrip.Visible = state;
            }
        }

        /// <summary>
        /// Sets the availability of the "Övrigt" button.
        /// </summary>
        /// <param name="state">True enabled selecting the "Övrigt" button, whule false disables it.</param>
        public void SetLastButton(Boolean state)
        {
            buttons[buttons.Count - 1].Enabled = state;
        }

        /// <summary>
        /// Sets what event should fire when a button is pressed.
        /// </summary>
        /// <param name="confirmStage">Representing if a confirmation-window should opened when the user presses a button, often when the user is assigning a product.</param>
        public void SetEvents(Boolean confirmStage)
        {
            if (confirmStage)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    contextMenuStrip1.Visible = false;
                    buttons[i].Click -= new System.EventHandler(this.OnTypeButtonClick);
                    buttons[i].Click += new System.EventHandler(this.AssignProductEventHandler);
                }
            }
        }
        
        /// <summary>
        /// Creates all necessary buttons and images that is needed.
        /// </summary>
        private void InitializeButtons()
        {
            int i = 0;
            int j = 0;

            while (i < mainProgram.GetTypes().Count)
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
                newButton.Text = mainProgram.GetTypeByIndex(i).Name;
                newButton.Font = new Font("Microsoft Sans Serif", 12);
                newButton.Name = buttonName;
                newButton.Width = 223;
                newButton.Height = 61;

                images.Add(newPictureBox);
                buttons.Add(newButton);

                newButton.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseHover);
                newButton.ContextMenuStrip = contextMenuStrip1;
                buttons[i].Click += new System.EventHandler(this.OnTypeButtonClick);

                string typeName = mainProgram.GetTypeByIndex(i).Name;
                string typePictureDirectory = directory + "\\" + typeName;

                if (newPictureBox.Image != null)
                    newPictureBox.Image.Dispose();
                else
                    newPictureBox.Image = null;


                try
                {
                    if (Directory.Exists(typePictureDirectory))
                    {
                        string[] tempArray = Directory.GetFiles(typePictureDirectory);
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
            WindowsFormsApp1.Model.Type tempNewlyAddedType = mainProgram.GetTypeByIndex(mainProgram.GetTypes().Count - 1);
            WindowsFormsApp1.Model.Type tempType = mainProgram.GetTypeByIndex(mainProgram.GetTypes().Count - 2);

            mainProgram.RemoveTypeByIndex(mainProgram.GetTypes().Count - 1);
            mainProgram.RemoveTypeByIndex(mainProgram.GetTypes().Count - 1);
            mainProgram.AddType(tempNewlyAddedType);
            mainProgram.AddType(tempType);

            ClearControls();
            InitializeButtons();
            ApplyThemeToUserControl();
        }

        // ------------------------- EventHandlers -------------------------
      
        /// <summary>
        /// Opens the ChangeTypeNameForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeTypNameButtonClick(object sender, EventArgs e)
        {
            string oldTypeName = choosenButton.Text;
            ChangeTypeNameForm changeTypeNameForm = new ChangeTypeNameForm(mainProgram, choosenButton.Text, CurrentTheme);
            var result = changeTypeNameForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                RenameFolder(changeTypeNameForm.GetTextBoxText());
                changeTypeNameForm.Close();
                ClearControls();
                InitializeButtons();
            }
        }
        
        /// <summary>
        /// Deletes a type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteTypeItemClick(object sender, EventArgs e)
        {
            int index;
            if(choosenButton.Text != buttons[buttons.Count - 1].Text)
            {
                DialogResult result = MessageBox.Show("Är du helt säker att du vill ta bort följande kategori: " + choosenButton.Text + "? Alla huvudhjälpmedel, tillbehör och reservdelar som är tillagda inom denna kategori kommer försvinna.", "Bekräfta borttagning av kategori.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
                    {
                        if (type.Name == choosenButton.Text)
                        {
                            index = mainProgram.GetTypes().IndexOf(type);
                            mainProgram.RemoveTypeByIndex(index);
                            break;
                        }
                    }
                }

                DeleteFolder();
                ClearControls();
                InitializeButtons();
            }
            else
            {
                DialogResult result = MessageBox.Show("Du kan inte ta bort följande kategori: " + choosenButton.Text + ".","Kan ej ta bort kategori.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Renames the folder containing the images corresponding to the type that the user changed named on.
        /// </summary>
        /// <param name="newTypeName">The new name of the type, and thereby also the folder.</param>
        private void RenameFolder(string newTypeName)
        {
            string choosenTypeOldName = choosenButton.Text;
            string choosenTypeNewName = newTypeName;
            string oldFolderDirectory = directory + "\\" + choosenTypeOldName;
            string newFolderDirectory = directory + "\\" + choosenTypeNewName;

            if (Directory.Exists(oldFolderDirectory))
            {
                string[] tempArray = Directory.GetFiles(oldFolderDirectory);
                fileEntries = tempArray.ToList<string>();

                try
                {
                    if (!Directory.Exists(newFolderDirectory))
                        Directory.CreateDirectory(newFolderDirectory);
                }
                catch (Exception) { }

                int i = 1;

                if (fileEntries.Count != 0)
                {
                    foreach (string fileName in fileEntries)
                    {
                        string oldFileName = fileName;
                        string newFileName = newFolderDirectory + "\\image" + i + ".jpg";

                        File.Move(oldFileName, newFileName);
                        i++;
                    }
                }
                Directory.Delete(oldFolderDirectory);
            }
            ClearControls();
            InitializeButtons();
        }

        /// <summary>
        /// Deletes the folder containing the images corresponding to the type that the user deleted.
        /// </summary>
        private void DeleteFolder()
        {
            string choosenTypeOldName = choosenButton.Text;
            string oldFolderDirectory = directory + "\\" + choosenTypeOldName;

            if (Directory.Exists(oldFolderDirectory))
            {
                string[] tempArray = Directory.GetFiles(oldFolderDirectory);
                fileEntries = tempArray.ToList<string>();
                         
                if (fileEntries.Count != 0)
                {
                    foreach (string fileName in fileEntries)
                    {
                        File.Delete(fileName);
                    }
                }
                Directory.Delete(oldFolderDirectory);
            }
            ClearControls();
            InitializeButtons();
        }
        
        /// <summary>
        /// Saves the button that the mouse hovers on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            choosenButton = button;
        }

        private void OnTypeButtonClick(object sender, EventArgs e)
        {
            EnterProductViewEventHandler?.Invoke(sender, e);
        }

        private void OnTypeButtonClickAssigning(object sender, EventArgs e)
        {
            AssignProductEventHandler?.Invoke(sender, e);
        }
    }
}
