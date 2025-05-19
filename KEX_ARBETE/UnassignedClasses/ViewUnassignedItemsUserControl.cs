using KEX_ARBETE.ColorsEnum;
using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class ViewUnassignedItemsUserControl : UserControl, IMenu
    {
        private const int NrItemsPerPage = 100;
        private const int NrBeforeUsingEndLabel = 7;
        private const int NrBeforeChangingLabels = 4;
        private const int MaxNrOfLabels = 9;

        private int CurrentPage { get; set; }
        private int NrUnassignedItems { get; set; }
        private Color InactivePageColor { get; set; }

        private List<int> indexesOfRedButtons;
        private List<PictureBox> images;
        private List<Button> buttons;
        private List<Panel> panels;
        private List<IAssignable> unassignables;

        public event EventHandler EnterProductViewEventHandler;
        public event MouseEventHandler EnterProductInfoViewEventHandler;
        public event EventHandler AddAccessoryToProductEventHandler;

        // ------------------------- Constructor -------------------------

        public ViewUnassignedItemsUserControl()
        {
            InitializeComponent();

            this.CurrentPage = 1;

            this.indexesOfRedButtons = new List<int>();
            this.images = new List<PictureBox>();
            this.buttons = new List<Button>();
            this.panels = new List<Panel>();
            this.unassignables = new List<IAssignable>();

            pageNavigatorUserControl1.OnLabelClickEventHandler += new EventHandler(OnLabelClick);
            pageNavigatorUserControl1.OnForwardButtonClickEventHandler += new EventHandler(OnForwardButtonClick);
            pageNavigatorUserControl1.OnBackButtonClickEventHandler += new EventHandler(OnBackButtonClick);
        }

        // ------------------------- Implemented from IVisible -------------------------

        public Boolean IsShown { get; set; }

        public Boolean WasLastShown { get; set; }

        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        public void HideUserControl()
        {
            this.Hide();
        }

        public void ShowUserControl()
        {
            this.Show();
        }
        
        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är menyn för icke-tilldelade produkter. Här visas alla huvudhjälpmedel som inte tilldelats någon kategori, " +
                " samt alla tillbehör och reservdelar som inte blivit tilldelade något huvudhjälpmedel.Klickar du på en produkt öppnas informationsidan för den produkten, där du kan välja att tilldela den." +
                "Du kan även högerklicka på flera produkter samtidigt och sedan klicka på Välj flera till höger för att tilldela flera produkter samtidigt.",
                "Information om sidan",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
            ResetPaginationBarTheme();
        }

        // ------------------------- Methods -------------------------

        public void SetUnassigned(List<IAssignable> currentUnassignables)
        {
            CurrentPage = 1;
            NrUnassignedItems = currentUnassignables.Count;

            unassignables = currentUnassignables;
            InactivePageColor = CurrentTheme.ButtonBackColor;

            indexesOfRedButtons.Clear();

            ConfigureButtonAvailability();
            InitializeLabels();
            InitializeButtons();
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
            panels.Clear();
        }

        public void SetRedButtons(Button selectedButton, Boolean isSelected)
        {
            int selectedIndex = buttons.IndexOf(selectedButton);
            if (isSelected)
                indexesOfRedButtons.Add(NrItemsPerPage * (CurrentPage - 1) + selectedIndex);
            else
                indexesOfRedButtons.Remove(NrItemsPerPage * (CurrentPage - 1) + selectedIndex);
        }

        private int NrPagesNeeded()
        {
            return ((NrUnassignedItems / NrItemsPerPage) + 1);
        }

        private void InitializeLabels()
        {
            int nrPagesNeeded = NrPagesNeeded();
            Label label = new Label();

            if(nrPagesNeeded <= MaxNrOfLabels)
            {
                for (int i = 1; i < MaxNrOfLabels + 1; i++)
                {
                    string labelName = "label" + i.ToString();
                    label = pageNavigatorUserControl1.GetLabel(labelName);
                    label.BackColor = InactivePageColor;

                    if (i < nrPagesNeeded + 1)
                        label.Text = i.ToString();
                    else
                        label.Text = "";

                    if (i == 1)
                        label.BackColor = ColorsClass.ActivePageColor;
                    else
                        label.BackColor = InactivePageColor;
                }
            }
            else
            {
                for (int i = 1; i < MaxNrOfLabels + 1; i++)
                {
                    string labelName = "label" + i.ToString();
                    label = pageNavigatorUserControl1.GetLabel(labelName);

                    if (i == NrBeforeUsingEndLabel + 1)
                        label.Text = "...";
                    else if (i == NrBeforeUsingEndLabel + 2)
                        label.Text = nrPagesNeeded.ToString();
                    else
                        label.Text = i.ToString();

                    if (i == 1)
                        label.BackColor = ColorsClass.ActivePageColor;
                    else
                        label.BackColor = InactivePageColor;
                }
            }
        }       

        private void InitializeButtons()
        {
            ClearControls();
            int itemIndex = NrItemsPerPage * (CurrentPage - 1);
            int itemsOnCurrentPageCounter = 0;
            int col = 0;

            if (NrUnassignedItems > NrItemsPerPage * CurrentPage)
            {
                for (int i = 0; i < NrItemsPerPage; i++)
                {
                    PictureBox newPictureBox = new PictureBox();
                    Button newButton = new Button();
                    Panel newPanel = new Panel();

                    string pictureBoxName = string.Concat("pictureBox", (itemIndex + 1).ToString());
                    string buttonName = string.Concat("button", (itemIndex + 1).ToString());
                    string panelName = string.Concat("panel", (itemIndex + 1).ToString());

                    newPanel.Controls.Add(newPictureBox);
                    newPictureBox.Name = pictureBoxName;
                    newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    newPictureBox.Dock = DockStyle.Fill;

                    if(indexesOfRedButtons.Contains(itemIndex))
                        newButton.BackColor = ColorsClass.SelectedButtonColor;

                    newPanel.Controls.Add(newButton);
                    newButton.Name = buttonName;
                    newButton.Text = unassignables[itemIndex].Artikelbenämning;
                    newButton.Font = new Font("Microsoft Sans Serif", 13);
                    newButton.Dock = DockStyle.Bottom;
                    newButton.Width = 223;
                    newButton.Height = 61;

                    images.Add(newPictureBox);
                    buttons.Add(newButton);
                    panels.Add(newPanel);

                    newButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnItemButtonClick);


                    if (((itemsOnCurrentPageCounter % 4) == 0) && itemsOnCurrentPageCounter != 0)
                    {
                        tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
                        tableLayoutPanel1.Controls.Add(newPanel, 0, tableLayoutPanel1.RowCount - 1);
                        newPanel.Dock = DockStyle.Fill;
                        col = 1;
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(newPanel, col, tableLayoutPanel1.RowCount - 1);
                        newPanel.Dock = DockStyle.Fill;
                        col++;
                    }
                    itemsOnCurrentPageCounter++;
                    itemIndex++;
                }
            }
            else
            {
                int i = 0;
                while (((NrItemsPerPage * (CurrentPage - 1) + i) < NrUnassignedItems))
                {
                    PictureBox newPictureBox = new PictureBox();
                    Button newButton = new Button();
                    Panel newPanel = new Panel();

                    string pictureBoxName = string.Concat("pictureBox", (itemIndex + 1).ToString());
                    string buttonName = string.Concat("button", (itemIndex + 1).ToString());
                    string panelName = string.Concat("panel", (itemIndex + 1).ToString());

                    newPanel.Controls.Add(newPictureBox);
                    newPictureBox.Name = pictureBoxName;
                    newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    newPictureBox.Dock = DockStyle.Fill;

                    if (indexesOfRedButtons.Contains(itemIndex))
                        newButton.BackColor = ColorsClass.SelectedButtonColor;

                    newPanel.Controls.Add(newButton);
                    newButton.Name = buttonName;
                    newButton.Text = unassignables[itemIndex].Artikelbenämning;
                    newButton.Font = new Font("Microsoft Sans Serif", 13);
                    newButton.Dock = DockStyle.Bottom;
                    newButton.Width = 223;
                    newButton.Height = 61;

                    images.Add(newPictureBox);
                    buttons.Add(newButton);
                    panels.Add(newPanel);

                    //newButton.Click += new System.EventHandler(this.OnItemButtonClick);
                    newButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnItemButtonClick);

                    if (((itemsOnCurrentPageCounter % 4) == 0) && itemsOnCurrentPageCounter != 0)
                    {
                        tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
                        tableLayoutPanel1.Controls.Add(newPanel, 0, tableLayoutPanel1.RowCount - 1);
                        newPanel.Dock = DockStyle.Fill;
                        col = 1;
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(newPanel, col, tableLayoutPanel1.RowCount - 1);
                        newPanel.Dock = DockStyle.Fill;
                        col++;
                    }
                    itemsOnCurrentPageCounter++;
                    itemIndex++;
                    i++;
                }
                ;
            }
            ApplyThemeToUserControl();
        }

        private void ResetPaginationBarTheme()
        {
            Label currentLabel = new Label();
            string labelText = CurrentPage.ToString();
            currentLabel = pageNavigatorUserControl1.GetLabelFromText(labelText);
            currentLabel.BackColor = ColorsClass.ActivePageColor;        
        }

        private void ConfigureButtonAvailability()
        {
            int nrPagesNeeded = NrPagesNeeded();
            Button forwardButton = pageNavigatorUserControl1.GetForwardButton();
            Button backButton = pageNavigatorUserControl1.GetBackButton();

            if (nrPagesNeeded > 1)
            {
                if (CurrentPage == nrPagesNeeded)
                {
                    forwardButton.Enabled = false;
                    backButton.Enabled = true;
                }                  
                else if(CurrentPage == 1)
                {
                    forwardButton.Enabled = true;
                    backButton.Enabled = false;
                }
                else
                {
                    forwardButton.Enabled = true;
                    backButton.Enabled = true;
                }              
            }
            else 
            {
                forwardButton.Enabled = false;
                backButton.Enabled = false;
            }
        }

        // ------------------------- EventHandlers -------------------------

        private void OnLabelClick(object sender, EventArgs e)
        {
            int nrPagesNeeded = NrPagesNeeded();
            Label label = (Label)sender;

            string labelNrString;
            int labelNrInt;

            if ((label.Text != "...") && (label.Text != ""))
            {
                labelNrString = label.Text;
                labelNrInt = Int32.Parse(labelNrString);

                CurrentPage = labelNrInt;

                if (nrPagesNeeded <= MaxNrOfLabels)
                {
                    for (int i = 1; i < MaxNrOfLabels + 1; i++)
                    {
                        string labelName = "label" + i.ToString();
                        label = pageNavigatorUserControl1.GetLabel(labelName);

                        if (i < nrPagesNeeded + 1)
                            label.Text = i.ToString();
                        else
                            label.Text = "";
                    }
                }
                else if (CurrentPage <= 1 + NrBeforeChangingLabels)
                {
                    for (int i = 1; i < MaxNrOfLabels + 1; i++)
                    {
                        string labelName = "label" + i.ToString();
                        label = pageNavigatorUserControl1.GetLabel(labelName);

                        switch (i)
                        {
                            case 1: label.Text = "1"; break;
                            case 2: label.Text = "2"; break;
                            case 3: label.Text = "3"; break;
                            case 4: label.Text = "4"; break;
                            case 5: label.Text = "5"; break;
                            case 6: label.Text = "6"; break;
                            case 7: label.Text = "7"; break;
                            case 8: label.Text = "..."; break;
                            case 9: label.Text = nrPagesNeeded.ToString(); break;
                            default: break;
                        }
                    }
                }
                else if((CurrentPage > (1 + NrBeforeChangingLabels)) && (CurrentPage < (nrPagesNeeded - NrBeforeChangingLabels)))
                {
                    for (int i = 1; i < MaxNrOfLabels + 1; i++)
                    {
                        string labelName = "label" + i.ToString();
                        label = pageNavigatorUserControl1.GetLabel(labelName);

                        switch (i)
                        {
                            case 1: label.Text = "1"; break;
                            case 2: label.Text = "..."; break;
                            case 3: label.Text = (CurrentPage - 2).ToString(); break;
                            case 4: label.Text = (CurrentPage - 1).ToString(); break;
                            case 5: label.Text = CurrentPage.ToString(); break;
                            case 6: label.Text = (CurrentPage + 1).ToString(); break;
                            case 7: label.Text = (CurrentPage + 2).ToString(); ; break;
                            case 8: label.Text = "..."; break;
                            case 9: label.Text = nrPagesNeeded.ToString(); break;
                            default: break;
                        }
                    }
                }
                else if(CurrentPage >= (nrPagesNeeded - NrBeforeChangingLabels))
                {
                    for (int i = 1; i < MaxNrOfLabels + 1; i++)
                    {
                        string labelName = "label" + i.ToString();
                        label = pageNavigatorUserControl1.GetLabel(labelName);

                        switch (i)
                        {
                            case 1: label.Text = "1"; break;
                            case 2: label.Text = "..."; break;
                            case 3: label.Text = (nrPagesNeeded - 6).ToString(); break;
                            case 4: label.Text = (nrPagesNeeded - 5).ToString(); break;
                            case 5: label.Text = (nrPagesNeeded - 4).ToString(); break;
                            case 6: label.Text = (nrPagesNeeded - 3).ToString(); break;
                            case 7: label.Text = (nrPagesNeeded - 2).ToString(); break;
                            case 8: label.Text = (nrPagesNeeded - 1).ToString(); break;
                            case 9: label.Text = nrPagesNeeded.ToString(); break;
                            default: break;
                        }
                    }
                }                                       
            }
            ConfigureButtonAvailability();
            InitializeButtons();
        }
        
        private void OnForwardButtonClick(object sender, EventArgs e)
        {
            int nrPagesNeeded = NrPagesNeeded();
            Label currentLabel = new Label();
            currentLabel.Name = "label" + (CurrentPage + 1).ToString();
            currentLabel.Text = (CurrentPage + 1).ToString();

            OnLabelClick(currentLabel, e);
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            int nrPagesNeeded = NrPagesNeeded();
            Label currentLabel = new Label();
            currentLabel.Name = "label" + (CurrentPage - 1).ToString();
            currentLabel.Text = (CurrentPage - 1).ToString();

            OnLabelClick(currentLabel, e);        
        }
     
        private void OnItemButtonClick(object sender, MouseEventArgs e)
        {
            EnterProductInfoViewEventHandler?.Invoke(sender, e);
        }
    }
}
