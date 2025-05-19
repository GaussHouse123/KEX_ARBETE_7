using KEX_ARBETE.ColorsEnum;
using KEX_ARBETE.IOClasses;
using KEX_ARBETE.Model;
using KEX_ARBETE.OtherForms;
using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    public enum EventChooser
    {
        Normal,
        Assigning,
        Adding
    }

    public partial class MainForm : Form
    {
        private int currentTypeIndex;
        private int currentProductIndex;
        private int currentAccessoryIndex;
        private int currentSpareIndex;

        private int tempCurrentTypeIndex2 = -1;
        private int tempCurrentProductIndex2 = -1;
        private int tempCurrentAccessoryIndex2 = -1;
        private int tempCurrentSpareIndex2 = -1;

        private string password;

        private Boolean isAddingSpare;
        private Boolean confirmStage;
        private Boolean isUsingMultiple;

        private EventChooser currentEvent = EventChooser.Normal;

        private MainProgram mainProgram;
        private Theme currentTheme;
        private AdminForm adminForm;
        private InfoForm infoForm;
        private ChooseWhichUnassignedToViewForm chooseWhichUnassignedToViewForm;
        private ChangePasswordForm changePasswordForm;

        private IAssignable currentUnassignable;

        private List<IMenu> userControls;
        private List<IAssignable> unassignablesCopy;
        private List<IAssignable> selectedUnassignables;


        public MainForm()
        {
            this.currentTypeIndex = -1;
            this.currentProductIndex = -1;
            this.currentAccessoryIndex = -1;
            this.currentSpareIndex = -1;

            this.mainProgram = new MainProgram();
            mainProgram.InitilizeData();

            this.password = mainProgram.Password;

            this.currentTheme = ThemeManager.Themes["Light"];

            this.unassignablesCopy = new List<IAssignable>();
            this.selectedUnassignables = new List<IAssignable>();

            InitializeComponent();
            LoadUserControls();

            LoadEventHandlers();
            ApplyTheme("Light");

            LoadMainMenu();
        }


        /// <summary>
        /// Puts all User Controls in a list.
        /// </summary>
        private void LoadUserControls()
        {
            userControls = new List<IMenu>
            {
                mainMenuUserControl, viewProductsUserControl, viewProductInfoUserControl,
                viewAccessoriesUserControl, viewAccessoryInfoUserControl,
                viewSparesUserControl, viewSpareInfoUserControl, viewUnassignedItemsUserControl, viewUnassignedItemInfoUserControl
            };
        }

        /// <summary>
        /// Subscribes to all eventhandlers that are relevant for the program.
        /// </summary>
        private void LoadEventHandlers()
        {
            menuBarUserControl.GoHomeEventHandler += new EventHandler(OnHomeButtonClick);
            menuBarUserControl.LogInEventHandler += new EventHandler(OnLogInButtonClick);
            menuBarUserControl.LogOutEventHandler += new EventHandler(OnLogOutButtonClick);
            menuBarUserControl.ChangePasswordEventHandler += new EventHandler(OnChangePasswordButtonClick);
            menuBarUserControl.ApplyLightThemeEventHandler += new EventHandler(OnLightModeButtonClick);
            menuBarUserControl.ApplyDarkThemeEventHandler += new EventHandler(OnDarkModeButtonClick);
            menuBarUserControl.ApplyRetroThemeEventHandler += new EventHandler(OnRetroModeButtonClick);

            menuBarUserControl.GoBackEventHandler += new EventHandler(OnBackButtonClick);
            menuBarUserControl.ViewProgramInfoEventHandler += new EventHandler(OnProgramInfoButtonClick);
            menuBarUserControl.SearchEventHandler += new KeyEventHandler(OnSearchEnterKeyPress);
            menuBarUserControl.ViewAttentionToolTipTextEventHandler += new EventHandler(OnAttentionSignMouseHover);
            menuBarUserControl.SetPicturesDirectoryEventHandler += new EventHandler(OnSetPicturesDirectory);
            menuBarUserControl.LoadExcelDataEventHandler += new EventHandler(OnLoadExcelData);
            menuBarUserControl.SaveDataEventHandler += new EventHandler(OnSaveData);
            menuBarUserControl.LoadDataEventHandler += new EventHandler(OnLoadData);
            menuBarUserControl.AssignMultipleEventHandler += new EventHandler(OnAssignItemButtonClick);
            

            mainMenuUserControl.EnterProductViewEventHandler += new EventHandler(OnEnterTypeClick);


            viewProductInfoUserControl.UpdateProductsEventHandler += new EventHandler(OnUpdateItems);
            viewAccessoryInfoUserControl.UpdateAccessoriesEventHandler += new EventHandler(OnUpdateItems);
            viewSpareInfoUserControl.UpdateSparesEventHandler += new EventHandler(OnUpdateItems);
            viewUnassignedItemInfoUserControl.UpdateItemEventHandler += new EventHandler(OnUpdateItems);

            menuBarUserControl.AddItemEventHandler += new EventHandler(OnAddItemButtonClick);

            viewProductsUserControl.EnterProductInfoViewEventHandler += new EventHandler(OnEnterItemInfoButtonClick);
            viewAccessoriesUserControl.EnterAccessoryInfoViewEventHandler += new EventHandler(OnEnterItemInfoButtonClick);
            viewSparesUserControl.EnterSpareInfoViewEventHandler += new EventHandler(OnEnterItemInfoButtonClick);
            viewUnassignedItemsUserControl.AddAccessoryToProductEventHandler += new EventHandler(OnEnterItemInfoButtonClick);

            viewProductInfoUserControl.DeleteProductEventHandler += new EventHandler(OnDeleteItemButtonClick);
            viewAccessoryInfoUserControl.DeleteAccessoryEventHandler += new EventHandler(OnDeleteItemButtonClick);
            viewSpareInfoUserControl.DeleteSpareEventHandler += new EventHandler(OnDeleteItemButtonClick);
            viewUnassignedItemInfoUserControl.DeleteItemEventHandler += new EventHandler(OnDeleteItemButtonClick);

            viewProductInfoUserControl.ShowAccessoryInfoEventHandler += new EventHandler(OnEnterAccessoryInfoComboBoxClick);
            viewProductInfoUserControl.ShowSpareInfoEventHandler += new EventHandler(OnEnterSpareInfoComboBoxClick);

            viewProductInfoUserControl.ShowAccessoriesViewEventHandler += new EventHandler(OnEnterViewAccessoriesButtonClick);
            viewProductInfoUserControl.ShowSparesViewEventHandler += new EventHandler(OnEnterViewSparesButtonClick);

            viewUnassignedItemsUserControl.EnterProductInfoViewEventHandler += new MouseEventHandler(OnEnterItemInfoButtonClick);

            mainMenuUserControl.AssignProductEventHandler += new EventHandler(OnAssigningItem);
            viewUnassignedItemInfoUserControl.OnAssignToItemButtonClickEventHandler += new EventHandler(OnAssignItemButtonClick);

            viewProductsUserControl.AssignProductEventHandler += new EventHandler(OnAssigningItem);

            // --------- 
            viewProductInfoUserControl.AddExistingAccessoryEventHandler += new EventHandler(OnAddExistingAccessory);
            viewProductInfoUserControl.AddUnassignedAccessoryEventHandler += new EventHandler(OnAddUnassignedAccessory);
            viewProductInfoUserControl.AddExistingSpareEventHandler += new EventHandler(OnAddExistingSpare);
            viewProductInfoUserControl.AddUnassigneSpareEventHandler += new EventHandler(OnAddUnassignedSpare);


            menuBarUserControl.PageInfoEventHandler += new EventHandler(OnPageInfoButtonClick);
            menuBarUserControl.CancelActivityEventHandler += new EventHandler(OnCancelActivityButtonClick);
     
            viewUnassignedItemInfoUserControl.AssignItemEventHandler += new EventHandler(OnAssignItemButtonClick);
        }

        // ------------------- Load Menus -------------------

        /// <summary>
        /// Loads up the main menu when the applications starts. This includes changing properties in all other menus.
        /// </summary>
        private void LoadMainMenu()
        {

            if (currentEvent == EventChooser.Normal)
            {
                currentTypeIndex = -1;
                currentProductIndex = -1;
                currentAccessoryIndex = -1;
                currentSpareIndex = -1;

                SetMenuBarItemsVisibility(true, true, false, true, false);        
            }
            else
            {
                tempCurrentTypeIndex2 = -1;
                tempCurrentProductIndex2 = -1;
                tempCurrentAccessoryIndex2 = -1;
                tempCurrentSpareIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            mainMenuUserControl.SetPicturesDirectory(mainProgram.Directory);

            mainMenuUserControl.SetTypes(mainProgram);
            mainMenuUserControl.SetEvents(confirmStage);

            if(currentEvent != EventChooser.Normal)
            {
                mainMenuUserControl.SetLastButton(false);
                mainMenuUserControl.SetButtonEdit(false);
            }
            else
            {
                mainMenuUserControl.UpdateAdminFeatures();

                //mainMenuUserControl.SetLastButton(true);
                //mainMenuUserControl.SetButtonEdit(true);
            }

            HideUserControls(userControls.IndexOf(mainMenuUserControl));
            SetVisabilityToFalse(userControls.IndexOf(mainMenuUserControl));
        }

        /// <summary>
        /// Loads up the menu to view all product for one type. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentType">The current type in which to view products in.</param>
        private void LoadViewProductsMenu(WindowsFormsApp1.Model.Type currentType)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentProductIndex = -1;
                currentAccessoryIndex = -1;
                currentSpareIndex = -1;

                SetMenuBarItemsVisibility(true, true, false, false, false);
            }
            else
            {
                tempCurrentProductIndex2 = -1;
                tempCurrentAccessoryIndex2 = -1;
                tempCurrentSpareIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewProductsUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewProductsUserControl.SetType(currentType, currentTheme);
            viewProductsUserControl.SetEvents(currentEvent);

            HideUserControls(userControls.IndexOf(viewProductsUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewProductsUserControl));         
        }

        /// <summary>
        /// Loads up the menu to view the info for one product. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentProduct">The current product that the user wants to see info on.</param>
        private void LoadViewProductInfoMenu(Product currentProduct)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentAccessoryIndex = -1;
                currentSpareIndex = -1;

                SetMenuBarItemsVisibility(false, true, false, false, false);
            }
            else
            {
                tempCurrentAccessoryIndex2 = -1;
                tempCurrentSpareIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewProductInfoUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewProductInfoUserControl.SetProduct(currentProduct);

            HideUserControls(userControls.IndexOf(viewProductInfoUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewProductInfoUserControl));
        }

        /// <summary>
        /// Loads up the menu to view all accessories for one product. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentProduct"> The current product to view all accessories to.</param>
        private void LoadViewAccessoriesMenu(Product currentProduct)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentAccessoryIndex = -1;
                currentSpareIndex = -1;

                SetMenuBarItemsVisibility(true, true, false, false, false);
            }
            else
            {
                tempCurrentAccessoryIndex2 = -1;
                tempCurrentSpareIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewAccessoriesUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewAccessoriesUserControl.SetProduct(currentProduct);

            HideUserControls(userControls.IndexOf(viewAccessoriesUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewAccessoriesUserControl));
        }

        /// <summary>
        /// Loads up the menu to view the info for one accessory. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentAccessory">The current accessory that the user wants to see info on.</param>
        private void LoadViewAccessoryInfoMenu(Accessory currentAccessory)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentSpareIndex = -1;
                SetMenuBarItemsVisibility(false, true, false, false, false);
            }
            else
            {
                tempCurrentSpareIndex2 = -1;
                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewAccessoryInfoUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewAccessoryInfoUserControl.SetAccessory(currentAccessory);

            HideUserControls(userControls.IndexOf(viewAccessoryInfoUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewAccessoryInfoUserControl));
        }

        /// <summary>
        /// Loads up the menu to view all spares for one product. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentProduct">The current product to view all spares to.</param>
        private void LoadViewSparesMenu(Product currentProduct)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentAccessoryIndex = -1;
                currentSpareIndex = -1;

                SetMenuBarItemsVisibility(true, true, false, false, false);
            }
            else
            {
                tempCurrentAccessoryIndex2 = -1;
                tempCurrentSpareIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewSparesUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewSparesUserControl.SetProduct(currentProduct);

            HideUserControls(userControls.IndexOf(viewSparesUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewSparesUserControl));
        }

        /// <summary>
        /// Loads up the menu to view the info for one spare. This includes changing properties in all other menus.
        /// </summary>
        /// <param name="currentSpare">The current spare that the user wants to see info on.</param>
        private void LoadViewSpareInfoMenu(Spare currentSpare)
        {
            if (currentEvent == EventChooser.Normal)
            {
                currentAccessoryIndex = -1;

                SetMenuBarItemsVisibility(false, true, false, false, false);
            }
            else
            {
                tempCurrentAccessoryIndex2 = -1;

                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewSpareInfoUserControl.SetPicturesDirectory(mainProgram.Directory);
            viewSpareInfoUserControl.SetSpare(currentSpare);

            HideUserControls(userControls.IndexOf(viewSpareInfoUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewSpareInfoUserControl));
        }

        private void LoadViewUnassignedItemsMenu(List<IAssignable> unassignableList)
        {
            selectedUnassignables.Clear();
            if (currentEvent == EventChooser.Normal)
            {
                SetMenuBarItemsVisibility(false, true, false, false, true);
            }
            else
            {
                SetMenuBarItemsVisibility(false, true, true, false, true);
            }

            viewUnassignedItemsUserControl.SetUnassigned(unassignableList);

            HideUserControls(userControls.IndexOf(viewUnassignedItemsUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewUnassignedItemsUserControl));
        }

        private void LoadViewUnassignedProductInfoMenu(IAssignable anUnassignable)
        {
            selectedUnassignables.Clear();
            if (currentEvent == EventChooser.Normal)
            {
                SetMenuBarItemsVisibility(false, true, false, false, false);
            }
            else
            {
                SetMenuBarItemsVisibility(false, true, true, false, false);
            }

            viewUnassignedItemInfoUserControl.SetProduct(anUnassignable);

            HideUserControls(userControls.IndexOf(viewUnassignedItemInfoUserControl));
            SetVisabilityToFalse(userControls.IndexOf(viewUnassignedItemInfoUserControl));
        }

        // ------------------- Miscellaneous -------------------

        /// <summary>
        /// Hides all User Controls except the one on the position index in userControls, which will be shown.
        /// </summary>
        /// <param name="index">The position of the User Control that should be shown.</param>
        private void HideUserControls(int index)
        {
            for (int i = 0; i < index; i++)
                userControls[i].HideUserControl();
            for (int i = index + 1; i < userControls.Count; i++)
                userControls[i].HideUserControl();

            userControls[index].ShowUserControl();
        }

        /// <summary>
        /// Sets the visability of all User Controls to false (both isShown and wasLastShown).
        /// </summary>
        /// <param name="index">The position of the User Control that should be set to true on IsShown.</param>
        private void SetVisabilityToFalse(int index)
        {
            for (int i = 0; i < userControls.Count; i++)
            {
                userControls[i].IsShown = false;
                userControls[i].WasLastShown = false;
            }
            userControls[index].IsShown = true;
        }

        /// <summary>
        /// Enables the logout and change password buttons on the menu bar and disables the login button.
        /// Happens when user does have admin access.
        /// </summary>
        private void EnableAdminFeatures()
        {
            menuBarUserControl.EnableAdminFeatures();
        }

        /// <summary>
        /// Enables the login button on the admin setting on the menu bar, and disables the logout and change password buttons. 
        /// Happens when user does not have admin access.
        /// </summary>
        private void DisableAdminFeatures()
        {
            menuBarUserControl.DisableAdminFeatures();
        }

        /// <summary>
        /// Sets admin the status of the admin access to either true or false. All classes that has a member that indicates admin access should be changed to the same value.
        /// </summary>
        /// <param name="access"> Indicating what the admin status should be set to. If true, enable admin access. If false, disable.</param>
        public void SetAdminAccess(Boolean access)
        {
            for (int i = 0; i < userControls.Count; i++)
                userControls[i].HasAdminAccess = access;

            adminForm.setAdminAccess(access);
            viewProductInfoUserControl.UpdateAdminFeatures();
            viewAccessoryInfoUserControl.UpdateAdminFeatures();
            viewSpareInfoUserControl.UpdateAdminFeatures();
            viewUnassignedItemInfoUserControl.UpdateAdminFeatures();

            if(currentEvent == EventChooser.Normal)
            {
                mainMenuUserControl.UpdateAdminFeatures();
            }
        }

        /// <summary>
        /// Applies a given theme on the current form.
        /// </summary>
        /// <param name="themeName"> The name of the theme that is desired.</param>
        private void ApplyTheme(string themeName)
        {
            if (!ThemeManager.Themes.ContainsKey(themeName)) return;

            currentTheme = ThemeManager.Themes[themeName];

            this.BackColor = currentTheme.BackgroundColor;
            this.ForeColor = currentTheme.ForegroundColor;

            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, currentTheme);
            }

            foreach (IMenu userControl in userControls)
            {
                userControl.CurrentTheme = currentTheme;
                userControl.ApplyThemeToUserControl();        
            }
            

            // Apply ToolStrip Colors
            ToolStrip toolStrip1 = menuBarUserControl.GetToolStrip();
            toolStrip1.BackColor = currentTheme.ToolStripBackColor;
            toolStrip1.ForeColor = currentTheme.ToolStripForeColor;

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.ForeColor = currentTheme.ToolStripForeColor;
            }

            //Apply custom dropdown menu renderer
            toolStrip1.Renderer = new ToolStripColor(currentTheme.ToolStripBackColor, currentTheme.ToolStripForeColor);
        }

        private void ApplyThemeToControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, currentTheme);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void SetMenuBarItemsVisibility(Boolean addButtonState, Boolean infoButtonState, Boolean cancelButtonState, Boolean excelButtonState, Boolean selectMultipleButtonState)
        {
            menuBarUserControl.SetAddButtonVisibility(addButtonState);
            menuBarUserControl.SetInfoButtonVisibility(infoButtonState);
            menuBarUserControl.SetAttentionVisibility(cancelButtonState);
            menuBarUserControl.SetExcelButtonVisibility(excelButtonState);
            menuBarUserControl.SetSelectMultipleButtonVisibility(selectMultipleButtonState);
        }

        /// <summary>
        /// Checks if the selected unassignabled are all of the same type, or if there are no selected items.
        /// </summary>
        /// <returns>True if at least one item is selected and all selected items are of the same type, otherwise false.</returns>
        private Boolean CheckIfValid()
        {
            if (selectedUnassignables.Count > 1)
            {
                for (int i = 0; i < selectedUnassignables.Count - 1; i++)
                {
                    if ((selectedUnassignables[i] is UnassignedExtra && selectedUnassignables[i + 1] is Product) || (selectedUnassignables[i] is Product && selectedUnassignables[i + 1] is UnassignedExtra))
                    {
                        MessageBox.Show("Du kan inte samtidigt tilldela ett huvudhjälpmedel och ett tillbehör eller reservdel! Vänligen testa igen.", "Varning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            else if (selectedUnassignables.Count == 1)
                return true;
            else
                return false;
        }

        // ------------------- EventHandlers -------------------

        /// <summary>
        /// Finds which type from mainMenuUserControl that was pressed and loads the scene with all products for that type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterTypeClick(object sender, EventArgs e)
        {    
            Button typeButton = (Button)sender;
            string typeName = typeButton.Text;
            int typeIndex = 0;

            foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
            {
                if (type.Name == typeName)
                {
                    typeIndex = mainProgram.GetTypes().IndexOf(type);
                }
            }

            if (currentEvent == EventChooser.Normal)
                currentTypeIndex = typeIndex;
            else
                tempCurrentTypeIndex2 = typeIndex;



            if (typeIndex == mainProgram.GetTypes().Count - 1)
            {
                this.chooseWhichUnassignedToViewForm = new ChooseWhichUnassignedToViewForm(currentTheme);
                var result = chooseWhichUnassignedToViewForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<IAssignable> currentUnassignables = new List<IAssignable>();
                    if (chooseWhichUnassignedToViewForm.GetAllCheckBox().Checked || (chooseWhichUnassignedToViewForm.GetProductCheckBox().Checked && chooseWhichUnassignedToViewForm.GetAccessoryAndSpareCheckBox().Checked))
                    {
                        currentUnassignables.AddRange(mainProgram.GetUnassignedProducts());
                        currentUnassignables.AddRange(mainProgram.GetUnassignedExtras());
                        unassignablesCopy = currentUnassignables;
                        LoadViewUnassignedItemsMenu(unassignablesCopy);
                    }
                    else if (chooseWhichUnassignedToViewForm.GetProductCheckBox().Checked)
                    {
                        currentUnassignables.AddRange(mainProgram.GetUnassignedProducts());
                        unassignablesCopy = currentUnassignables;
                        LoadViewUnassignedItemsMenu(currentUnassignables);
                    }
                    else if (chooseWhichUnassignedToViewForm.GetAccessoryAndSpareCheckBox().Checked)
                    {
                        currentUnassignables.AddRange(mainProgram.GetUnassignedExtras());
                        unassignablesCopy = currentUnassignables;
                        LoadViewUnassignedItemsMenu(currentUnassignables);
                    }
                    mainMenuUserControl.WasLastShown = true;
                }
            }
            else
            {
                WindowsFormsApp1.Model.Type currentType = mainProgram.GetTypeByIndex(typeIndex);
                LoadViewProductsMenu(currentType);
                mainMenuUserControl.WasLastShown = true;
            }

        }

        /// <summary>
        /// When the users enter the info view of an accessory from the combo box in the product info view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterAccessoryInfoComboBoxClick(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            currentAccessoryIndex = comboBox.SelectedIndex;

            Accessory currentAccessory = mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetAccessoryByIndex(currentAccessoryIndex);

            LoadViewAccessoryInfoMenu(currentAccessory);
            viewProductInfoUserControl.WasLastShown = true;
        }

        /// <summary>
        /// When the users enter the info view of an spare from the combo box in the product info view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterSpareInfoComboBoxClick(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            currentSpareIndex = comboBox.SelectedIndex;

            Spare currentSpare = mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetSpareByIndex(currentSpareIndex);

            LoadViewSpareInfoMenu(currentSpare);
            viewProductInfoUserControl.WasLastShown = true;
        }

        /// <summary>
        /// Loads the view to see all accessories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterViewAccessoriesButtonClick(object sender, EventArgs e)
        {
            LoadViewAccessoriesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
            viewProductInfoUserControl.WasLastShown = true;
        }

        /// <summary>
        /// Loads the view to see all spares.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterViewSparesButtonClick(object sender, EventArgs e)
        {
            LoadViewSparesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
            viewProductInfoUserControl.WasLastShown = true;
        }

        /// <summary>
        /// Calls on the control that opens the view of a specific item. The item depends on what view is currently active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterItemInfoButtonClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            Button itemButton = (Button)sender;
            string itemText = itemButton.Text;



            if (currentEvent == EventChooser.Normal)
            {
                if (viewProductsUserControl.IsShown)
                {
                    foreach (Product product in mainProgram.GetTypeByIndex(currentTypeIndex).GetProducts())
                    {
                        if (product.Artikelbenämning == itemText)
                        {
                            currentProductIndex = mainProgram.GetTypeByIndex(currentTypeIndex).GetProducts().IndexOf(product);
                            LoadViewProductInfoMenu(product);
                            viewProductsUserControl.WasLastShown = true;
                            break;
                        }
                    }
                }
                else if (viewAccessoriesUserControl.IsShown)
                {
                    foreach (Accessory accessory in mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetAccessories())
                    {
                        if (accessory.Artikelbenämning == itemText)
                        {
                            currentAccessoryIndex = mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetAccessories().IndexOf(accessory);
                            LoadViewAccessoryInfoMenu(accessory);
                            viewAccessoriesUserControl.WasLastShown = true;
                            break;
                        }
                    }
                }
                else if (viewSparesUserControl.IsShown)
                {
                    foreach (Spare spare in mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetSpares())
                    {
                        if (spare.Artikelbenämning == itemText)
                        {
                            currentSpareIndex = mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetSpares().IndexOf(spare);
                            LoadViewSpareInfoMenu(spare);
                            viewSparesUserControl.WasLastShown = true;
                            break;
                        }
                    }
                }
                else if (viewUnassignedItemsUserControl.IsShown)
                {
                    foreach (IAssignable item in unassignablesCopy)
                    {
                        if (item.Artikelbenämning == itemText)
                        {
                            if(me.Button == MouseButtons.Left)
                            {
                                currentUnassignable = item;
                                LoadViewUnassignedProductInfoMenu(item);
                                viewUnassignedItemsUserControl.WasLastShown = true;
                                break;
                            }
                            else if(me.Button == MouseButtons.Right)
                            {

                                if (itemButton.BackColor == ColorsClass.SelectedButtonColor)
                                {
                                    //itemButton.BackColor = currentButtonColor;
                                    itemButton.BackColor = currentTheme.ButtonBackColor;
                                    itemButton.ForeColor = currentTheme.ButtonForeColor;
                                    viewUnassignedItemsUserControl.SetRedButtons(itemButton, false);
                                    selectedUnassignables.Remove(item);

                                    break;
                                }
                                else
                                {

                                    itemButton.BackColor = ColorsClass.SelectedButtonColor;
                                    selectedUnassignables.Add(item);
                                    viewUnassignedItemsUserControl.SetRedButtons(itemButton, true);
                                    break;
                                }                                
                            }
                        }
                    }
                    if (selectedUnassignables.Count == 0)
                    {
                        isUsingMultiple = false;
                    }
                    else
                    {
                        isUsingMultiple = true;
                    }
                }
            }
            else if (currentEvent == EventChooser.Adding)
            {
                if (viewProductsUserControl.IsShown)
                {
                    foreach (Product product in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts())
                    {
                        if (product.Artikelbenämning == itemText)
                        {
                            if (!isAddingSpare)
                            {
                                tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                LoadViewAccessoriesMenu(product);
                                viewProductsUserControl.WasLastShown = true;
                                break;
                            }
                            else
                            {
                                tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                LoadViewSparesMenu(product);
                                viewProductsUserControl.WasLastShown = true;
                                break;
                            }
                        }
                    }
                }
                else if (viewAccessoriesUserControl.IsShown)
                {
                    foreach (Accessory accessory in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetAccessories())
                    {
                        if (accessory.Artikelbenämning == itemText)
                        {
                            tempCurrentAccessoryIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetAccessories().IndexOf(accessory);
                            break;
                        }
                    }
                    Accessory currentAccessory = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetAccessoryByIndex(tempCurrentAccessoryIndex2);
                    Accessory accessoryToAdd = new Accessory(currentAccessory.Huvudlager, currentAccessory.Leverantör, currentAccessory.Artikelbenämning, currentAccessory.LeverantörArtikelNr, true);

                    DialogResult result = MessageBox.Show("Vill du lägga till tillbehöret: " + accessoryToAdd.Artikelbenämning + " till produkten: " + mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).Artikelbenämning + "?", "Bekräfta tilldelning av tillbehör:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).AddAccessory(accessoryToAdd);
                        MessageBox.Show("Tilldelning lyckad! Går tillbaka till produkt-info sidan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                        viewProductsUserControl.WasLastShown = true;
                        currentEvent = EventChooser.Normal;
                    }
                }


                else if (viewSparesUserControl.IsShown)
                {
                    for (int i = 0; i < mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetSpares().Count; i++)
                        if (mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetSpareByIndex(i).Artikelbenämning == itemText)
                        {
                            tempCurrentSpareIndex2 = i;
                            break;
                        }

                    Spare currentSpare = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetSpareByIndex(tempCurrentSpareIndex2);
                    Spare spareToAdd = new Spare(currentSpare.Huvudlager, currentSpare.Leverantör, currentSpare.Artikelbenämning, currentSpare.LeverantörArtikelNr, true);

                    DialogResult result = MessageBox.Show("Vill du lägga till reservdelen: " + spareToAdd.Artikelbenämning + " till produkten: " + mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).Artikelbenämning + "?", "Bekräfta tilldelning av reservdel:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).AddSpare(spareToAdd);
                        MessageBox.Show("Tilldelning lyckad! Går tillbaka till produkt-info sidan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                        viewProductsUserControl.WasLastShown = true;
                        currentEvent = EventChooser.Normal;
                    }
                }
                else if (viewUnassignedItemsUserControl.IsShown)
                {
                    foreach (IAssignable item in unassignablesCopy)
                    {
                        if (item.Artikelbenämning == itemText)
                        {
                            currentUnassignable = item;
                            if (!isAddingSpare) 
                            {
                                DialogResult result = MessageBox.Show("Vill du lägga till tillbehöret: " + currentUnassignable.Artikelbenämning + " till produkten: " + mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).Artikelbenämning + " ?", "Bekräfta tilldelning av tillbehör", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    Accessory accessoryToAdd = new Accessory(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                    mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).AddAccessory(accessoryToAdd);
                                    mainProgram.RemoveUnassignedExtraByName(accessoryToAdd.Artikelbenämning);
                                    currentEvent = EventChooser.Normal;
                                    LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                                    viewProductsUserControl.WasLastShown = true;
                                }
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Vill du lägga till reservdelen: " + currentUnassignable.Artikelbenämning + " till produkten: " + mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).Artikelbenämning + " ?", "Bekräfta tilldelning av reservdel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    Spare spareToAdd = new Spare(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                    mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).AddSpare(spareToAdd);
                                    mainProgram.RemoveUnassignedExtraByName(spareToAdd.Artikelbenämning);
                                    currentEvent = EventChooser.Normal;
                                    LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                                    viewProductsUserControl.WasLastShown = true;
                                }
                            }
                        }
                    }
                }
            } else if(currentEvent == EventChooser.Assigning)
            {

            }
        }

        /// <summary>
        /// Calls the form that adds the corresponding item, depending on which view is active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAddItemButtonClick(object sender, EventArgs e)
        {
            if (viewProductsUserControl.IsShown)
                viewProductsUserControl.AddProduct();
            else if (viewAccessoriesUserControl.IsShown)
                viewAccessoriesUserControl.AddAccessory();
            else if (viewSparesUserControl.IsShown)
                viewSparesUserControl.AddSpare();
            else if (mainMenuUserControl.IsShown)
                mainMenuUserControl.AddType();
        }

        /// <summary>
        /// Deletes an item, where the item depends on which view is active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteItemButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Är du säker?", "Bekräfta borttagning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (viewProductInfoUserControl.IsShown)
                {
                    mainProgram.GetTypeByIndex(currentTypeIndex).RemoveProductByIndex(currentProductIndex);
                    LoadViewProductsMenu(mainProgram.GetTypeByIndex(currentTypeIndex));
                    mainMenuUserControl.WasLastShown = true;
                }
                else if (viewAccessoryInfoUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
                {
                    mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).RemoveAccessoryByIndex(currentAccessoryIndex);
                    LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                    viewProductsUserControl.WasLastShown = true;
                }
                else if (viewAccessoryInfoUserControl.IsShown)
                {
                    mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).RemoveAccessoryByIndex(currentAccessoryIndex);
                    LoadViewAccessoriesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                    viewProductInfoUserControl.WasLastShown = true;
                }
                else if (viewSpareInfoUserControl.IsShown)
                {
                    mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).RemoveSpareByIndex(currentSpareIndex);
                    LoadViewSparesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                    viewProductInfoUserControl.WasLastShown = true;
                }
                else if (viewUnassignedItemInfoUserControl.IsShown)
                {
                    if (currentUnassignable is Product)
                    {
                        mainProgram.RemoveProductByName(currentUnassignable.Artikelbenämning);
                    }
                    else if (currentUnassignable is Accessory)
                    {
                        mainProgram.RemoveUnassignedExtraByName(currentUnassignable.Artikelbenämning);
                    }
                    unassignablesCopy.Remove(currentUnassignable);
                    LoadViewUnassignedItemsMenu(unassignablesCopy);
                    mainMenuUserControl.WasLastShown = true;
                }
            }
            else
                MessageBox.Show("Borttagning avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Refreshes a specific view, possible after a change. The view depends on which view is currently active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateItems(object sender, EventArgs e)
        {
            if (viewProductInfoUserControl.IsShown)
            {
                LoadViewProductsMenu(mainProgram.GetTypeByIndex(currentTypeIndex));
                mainMenuUserControl.WasLastShown = true;
            }
            else if (viewAccessoryInfoUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewAccessoryInfoUserControl.IsShown)
            {
                LoadViewAccessoriesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                viewProductInfoUserControl.WasLastShown = true;
            }
            else if (viewSpareInfoUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewSpareInfoUserControl.IsShown)
            {
                LoadViewSparesMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                viewProductInfoUserControl.WasLastShown = true;
            }
            else if (viewUnassignedItemInfoUserControl.IsShown)
            {
                LoadViewUnassignedItemsMenu(unassignablesCopy);
                mainMenuUserControl.WasLastShown = true;
            }
        }

        /// <summary>
        /// Loads the screen that comes before it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBackButtonClick(object sender, EventArgs e)
        {
            int typeIndex;
            int productIndex;

            if (currentEvent == EventChooser.Normal)
            {
                typeIndex = currentTypeIndex;
                productIndex = currentProductIndex;
            }
            else
            {
                typeIndex = tempCurrentTypeIndex2;
                productIndex = tempCurrentProductIndex2;
            }

            if (viewProductsUserControl.IsShown && mainMenuUserControl.WasLastShown && currentEvent == EventChooser.Normal)
            {
                LoadMainMenu();
            }
            else if (viewProductsUserControl.IsShown && mainMenuUserControl.WasLastShown && currentEvent == EventChooser.Assigning)
            {
                currentEvent = EventChooser.Assigning;
                confirmStage = false;
                LoadMainMenu();
                confirmStage = true;
            }
            else if (viewProductsUserControl.IsShown && mainMenuUserControl.WasLastShown && currentEvent == EventChooser.Adding)
            {
                LoadMainMenu();
                currentEvent = EventChooser.Adding;
            }
            else if (viewProductInfoUserControl.IsShown && viewProductsUserControl.WasLastShown)
            {
                LoadViewProductsMenu(mainProgram.GetTypeByIndex(typeIndex));
                mainMenuUserControl.WasLastShown = true;
            }

            else if (viewAccessoryInfoUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewAccessoriesUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewAccessoryInfoUserControl.IsShown && viewAccessoriesUserControl.WasLastShown)
            {
                LoadViewAccessoriesMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductInfoUserControl.WasLastShown = true;
            }

            else if (viewSpareInfoUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewSparesUserControl.IsShown && viewProductInfoUserControl.WasLastShown)
            {
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (viewSpareInfoUserControl.IsShown && viewSparesUserControl.WasLastShown)
            {
                LoadViewSparesMenu(mainProgram.GetTypeByIndex(typeIndex).GetProductByIndex(productIndex));
                viewProductInfoUserControl.WasLastShown = true;
            }
            else if (viewSparesUserControl.IsShown && viewProductsUserControl.WasLastShown)
            {
                LoadViewProductsMenu(mainProgram.GetTypeByIndex(typeIndex));
                mainMenuUserControl.WasLastShown = true;
            }

            else if (viewUnassignedItemsUserControl.IsShown && mainMenuUserControl.WasLastShown)
            {
                LoadMainMenu();
            }
            else if (viewUnassignedItemInfoUserControl.IsShown && viewUnassignedItemsUserControl.WasLastShown)
            {
                LoadViewUnassignedItemsMenu(unassignablesCopy);
                mainMenuUserControl.WasLastShown = true;
            }
            else if (viewAccessoriesUserControl.IsShown && viewProductsUserControl.WasLastShown)
            {
                LoadViewProductsMenu(mainProgram.GetTypeByIndex(typeIndex));
                mainMenuUserControl.WasLastShown = true;
            }
        }

        /// <summary>
        /// Returns to the main menu screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHomeButtonClick(object sender, EventArgs e)
        {
            currentEvent = EventChooser.Normal;
            LoadMainMenu();
            //SetAdminAccess(mainMenuUserControl.HasAdminAccess);
        }

        /// <summary>
        /// Opens the admin form in order to enter password and if successful set admin access to true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLogInButtonClick(object sender, EventArgs e)
        {
            this.adminForm = new AdminForm(currentTheme, password);

            var result = adminForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Inloggad!", "Admin Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableAdminFeatures();
                SetAdminAccess(true);
            }
        }

        /// <summary>
        /// Logs out from the admin access and thus setting all admin access properties to false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLogOutButtonClick(object sender, EventArgs e)
        {
            DisableAdminFeatures();
            SetAdminAccess(false);

            if(currentEvent == EventChooser.Adding || currentEvent == EventChooser.Assigning)
            {
                currentEvent = EventChooser.Normal;
                confirmStage = false;
                LoadMainMenu();
            }

            MessageBox.Show("Utloggad!", "Admin Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangePasswordButtonClick(object sender, EventArgs e)
        {
            this.changePasswordForm = new ChangePasswordForm(currentTheme, password);
            var result = changePasswordForm.ShowDialog();

            changePasswordForm.Show();

            if (result == DialogResult.OK)
            {
                password = changePasswordForm.GetPassword();
                changePasswordForm.Close();
                mainProgram.Password = password;
            }
            else if (result == DialogResult.Cancel)
            {
                changePasswordForm.Close();
            }
        }

        /// <summary>
        /// Applies light as the current theme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLightModeButtonClick(object sender, EventArgs e)
        {
            ApplyTheme("Light");

        }

        /// <summary>
        /// Applies dark as the current theme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDarkModeButtonClick(object sender, EventArgs e)
        {
            ApplyTheme("Dark");
        }

        /// <summary>
        /// Applies retro as the current theme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRetroModeButtonClick(object sender, EventArgs e)
        {
            ApplyTheme("Retro");
        }

        /// <summary>
        /// Shows the program info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnProgramInfoButtonClick(object sender, EventArgs e)
        {
            this.infoForm = new InfoForm(currentTheme);
            infoForm.Show();
        }

        private void OnSearchEnterKeyPress(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string searchString = textBox.Text;

            if (viewProductsUserControl.IsShown && e.KeyCode == Keys.Enter && currentEvent == EventChooser.Normal)
            {
                WindowsFormsApp1.Model.Type typeMatch = new WindowsFormsApp1.Model.Type("Matching");

                foreach (Product product in mainProgram.GetTypeByIndex(currentTypeIndex).GetProducts())
                {
                    if (product.Artikelbenämning.Contains(searchString))
                    {
                        typeMatch.AddProduct(product);
                    }
                }
                typeMatch.Name = mainProgram.GetTypeByIndex(currentTypeIndex).Name;
                LoadViewProductsMenu(typeMatch);
                mainMenuUserControl.WasLastShown = true;

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (viewUnassignedItemsUserControl.IsShown && e.KeyCode == Keys.Enter)
            {
                List<IAssignable> unassignablesMatch = new List<IAssignable>();

                foreach (IAssignable item in unassignablesCopy)
                {
                    if (item.Artikelbenämning.Contains(searchString))
                    {
                        unassignablesMatch.Add(item);
                    }
                }
                LoadViewUnassignedItemsMenu(unassignablesMatch);
                mainMenuUserControl.WasLastShown = true;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (viewAccessoriesUserControl.IsShown && e.KeyCode == Keys.Enter && currentEvent == EventChooser.Normal)
            {
                Product productMatch = new Product();

                foreach (Accessory accessory in mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetAccessories())
                {
                    if (accessory.Artikelbenämning.Contains(searchString))
                    {
                        productMatch.AddAccessory(accessory);
                    }
                }
                LoadViewAccessoriesMenu(productMatch);
            }
            else if (viewSparesUserControl.IsShown && e.KeyCode == Keys.Enter && currentEvent == EventChooser.Normal)
            {
                Product productMatch = new Product();

                foreach (Spare spare in mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex).GetSpares())
                {
                    if (spare.Artikelbenämning.Contains(searchString))
                    {
                        productMatch.AddSpare(spare);
                    }
                }
                LoadViewAccessoriesMenu(productMatch);
            }
            else if (viewAccessoriesUserControl.IsShown && e.KeyCode == Keys.Enter)
            {
                Product productMatch = new Product();

                foreach (Accessory accessory in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).GetAccessories())
                {
                    if (accessory.Artikelbenämning.Contains(searchString))
                    {
                        productMatch.AddAccessory(accessory);
                    }
                }
                LoadViewAccessoriesMenu(productMatch);
            }
        }

        private void OnAssignItemButtonClick(object sender, EventArgs e)
        {
            if(viewUnassignedItemInfoUserControl.IsShown)
            {
                if (currentUnassignable is Product)
                {
                    currentEvent = EventChooser.Assigning;
                    confirmStage = true;
                    LoadMainMenu();
                    mainMenuUserControl.SetContextMenuStrip(false);
                    confirmStage = false;

                    MessageBox.Show("Klicka på den kategori du vill lägga till huvudhjälpmedlet i:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentUnassignable is UnassignedExtra)
                {
                    currentEvent = EventChooser.Assigning;
                    confirmStage = false;
                    LoadMainMenu();
                    mainMenuUserControl.SetContextMenuStrip(false);
                    MessageBox.Show("Klicka på den kategori där huvudhjälpmedlet du ska tilldela komponenten till ligger:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(viewUnassignedItemsUserControl.IsShown)
            {
                if(CheckIfValid()) 
                {
                    if (selectedUnassignables[0] is Product)
                    {
                        currentEvent = EventChooser.Assigning;
                        confirmStage = true;
                        LoadMainMenu();
                        mainMenuUserControl.SetContextMenuStrip(false);
                        confirmStage = false;

                        if (selectedUnassignables.Count == 1)
                        {
                            MessageBox.Show("Klicka på den kategori du vill lägga till huvudhjälpmedlet i:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            currentUnassignable = selectedUnassignables[0];
                        }
                        else
                            MessageBox.Show("Klicka på den kategori du vill lägga till huvudhjälpmedlerna i:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (selectedUnassignables[0] is UnassignedExtra)
                    {
                        currentEvent = EventChooser.Assigning;
                        confirmStage = false;
                        LoadMainMenu();
                        mainMenuUserControl.SetContextMenuStrip(false);

                        if (selectedUnassignables.Count == 1)
                        {
                            MessageBox.Show("Klicka på den kategori som huvudhjälpmedlet du ska tilldela komponenten ligger i:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            currentUnassignable = selectedUnassignables[0];
                        }
                        else
                            MessageBox.Show("Klicka på den kategori som huvudhjälpmedlet du ska tilldela komponenterna ligger i:", "Välj kategori för tilldelning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }           
        }

        private void OnAssigningItem(object sender, EventArgs e)
        {
            Button itemButton = (Button)sender;
            string itemName = itemButton.Text;

            if (!isUsingMultiple || selectedUnassignables.Count == 1)
            {
                if (currentUnassignable is Product)
                {
                    DialogResult result2 = MessageBox.Show("Vill du lägga till huvudhjälpmedlet \"" + currentUnassignable.Artikelbenämning + "\" i kategorin \"" + itemName + "\"? ", "Bekräfta tilldelning av huvudhjälpmedel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result2 == DialogResult.Yes)
                    {
                        foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
                        {
                            if (type.Name == itemName)
                            {
                                tempCurrentTypeIndex2 = mainProgram.GetTypes().IndexOf(type);
                                break;
                            }
                        }
                        Product productToAdd = new Product(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                        mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).AddProduct(productToAdd);
                        MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainProgram.RemoveProductByName(productToAdd.Artikelbenämning);
                        unassignablesCopy.Remove(currentUnassignable);
                        currentEvent = EventChooser.Normal;
                        LoadViewUnassignedItemsMenu(unassignablesCopy);
                        mainMenuUserControl.WasLastShown = true;
                    }
                    else
                        MessageBox.Show("Tilldelningen avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentUnassignable is UnassignedExtra)
                {
                    AssignAsAccessoryOrSpareForm assignAsAccessoryOrSpareForm = new AssignAsAccessoryOrSpareForm(currentTheme);
                    var resultFromForm = assignAsAccessoryOrSpareForm.ShowDialog();

                    if (resultFromForm == DialogResult.OK)
                    {
                        if (assignAsAccessoryOrSpareForm.GetAccessoryCheckBox().Checked)
                        {
                            DialogResult result2 = MessageBox.Show("Vill du lägga till komponenten \"" + currentUnassignable.Artikelbenämning + "\" som ett tillbehör till huvudhjälpmedlet \"" + itemName + "\"?", "Bekräfta tilldelning av tillbehör", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result2 == DialogResult.Yes)
                            {
                                foreach (Product product in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts())
                                {
                                    if (product.Artikelbenämning == itemName)
                                    {
                                        tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                        break;
                                    }
                                }
                                Accessory accessoryToAdd = new Accessory(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).AddAccessory(accessoryToAdd);
                                MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mainProgram.RemoveUnassignedExtraByName(accessoryToAdd.Artikelbenämning);
                                unassignablesCopy.Remove(currentUnassignable);
                                currentEvent = EventChooser.Normal;
                                LoadViewUnassignedItemsMenu(unassignablesCopy);
                                mainMenuUserControl.WasLastShown = true;
                            }
                            else
                                MessageBox.Show("Tilldelningen avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult result2 = MessageBox.Show("Vill du lägga till komponenten \"" + currentUnassignable.Artikelbenämning + "\" som en reservdel till huvudhjälpmedlet \"" + itemName + "\"?", "Bekräfta tilldelning av reservdel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result2 == DialogResult.Yes)
                            {
                                foreach (Product product in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts())
                                {
                                    if (product.Artikelbenämning == itemName)
                                    {
                                        tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                        break;
                                    }
                                }
                                Spare spareToAdd = new Spare(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).AddSpare(spareToAdd);
                                MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mainProgram.RemoveUnassignedExtraByName(spareToAdd.Artikelbenämning);
                                unassignablesCopy.Remove(currentUnassignable);
                                currentEvent = EventChooser.Normal;
                                LoadViewUnassignedItemsMenu(unassignablesCopy);
                                mainMenuUserControl.WasLastShown = true;
                            }
                            else
                                MessageBox.Show("Tilldelningen avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                if (selectedUnassignables[0] is Product)
                {
                    string allProductsName = "";
                    foreach(IAssignable unassignable in selectedUnassignables)
                    {
                        allProductsName = allProductsName + "\"";
                        if (unassignable == selectedUnassignables.Last())
                            allProductsName = allProductsName + unassignable.Artikelbenämning + "\"" + ".";
                        else 
                            allProductsName = allProductsName + unassignable.Artikelbenämning + "\"" + ", ";                        
                    }

                    DialogResult result2 = MessageBox.Show("Vill du lägga till huvudhjälpmedlerna " + allProductsName + " i kategorin " + "\"" + itemName + "\"?", "Bekräfta tilldelning av huvudhjälpmedel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
                        {
                            if (type.Name == itemName)
                            {
                                tempCurrentTypeIndex2 = mainProgram.GetTypes().IndexOf(type);
                                break;
                            }
                        }
                        foreach (IAssignable unassignable in selectedUnassignables)
                        {
                            currentUnassignable = unassignable;
                            Product productToAdd = new Product(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                            mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).AddProduct(productToAdd);
                            mainProgram.RemoveProductByName(productToAdd.Artikelbenämning);
                            unassignablesCopy.Remove(currentUnassignable);
                        }
                        
                        MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);                                            
                        currentEvent = EventChooser.Normal;
                        selectedUnassignables.Clear();
                        LoadViewUnassignedItemsMenu(unassignablesCopy);
                        mainMenuUserControl.WasLastShown = true;
                    }
                    else
                        MessageBox.Show("Tilldelningen avbryten.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(selectedUnassignables[0] is UnassignedExtra)
                {
                    string allArticlesName = "";
                    foreach (IAssignable unassignable in selectedUnassignables)
                    {
                        allArticlesName = allArticlesName + "\"";
                        if (unassignable == selectedUnassignables.Last())
                            allArticlesName = allArticlesName + unassignable.Artikelbenämning + "\"" + ".";
                        else
                            allArticlesName = allArticlesName + unassignable.Artikelbenämning + "\"" + ", ";
                    }

                    AssignAsAccessoryOrSpareForm assignAsAccessoryOrSpareForm = new AssignAsAccessoryOrSpareForm(currentTheme);
                    var resultFromForm = assignAsAccessoryOrSpareForm.ShowDialog();

                    if (resultFromForm == DialogResult.OK)
                    {
                        if (assignAsAccessoryOrSpareForm.GetAccessoryCheckBox().Checked)
                        {
                            DialogResult result2 = MessageBox.Show("Vill du lägga till komponenterna " + allArticlesName + " som tillbehör till huvudhjälpmedlet " + "\"" + itemName + "\"?", "Bekräfta tilldelning av tillbehör", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result2 == DialogResult.Yes)
                            {
                                foreach (Product product in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts())
                                {
                                    if (product.Artikelbenämning == itemName)
                                    {
                                        tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                        break;
                                    }
                                }
                                foreach(IAssignable unassignable in selectedUnassignables)
                                {
                                    currentUnassignable = unassignable;
                                    Accessory accessoryToAdd = new Accessory(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                    mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).AddAccessory(accessoryToAdd);
                                    mainProgram.RemoveUnassignedExtraByName(accessoryToAdd.Artikelbenämning);
                                    unassignablesCopy.Remove(currentUnassignable);
                                }
                                MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                currentEvent = EventChooser.Normal;
                                selectedUnassignables.Clear();
                                LoadViewUnassignedItemsMenu(unassignablesCopy);
                                mainMenuUserControl.WasLastShown = true;
                            }
                            else
                                MessageBox.Show("Tilldelningen avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult result2 = MessageBox.Show("Vill du lägga till komponenterna " + allArticlesName + " som reservdelar till huvudhjälpmedlet " + "\"" + itemName + "\"?", "Bekräfta tilldelning av reservdelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result2 == DialogResult.Yes)
                            {
                                foreach (Product product in mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts())
                                {
                                    if (product.Artikelbenämning == itemName)
                                    {
                                        tempCurrentProductIndex2 = mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProducts().IndexOf(product);
                                        break;
                                    }
                                }
                                foreach (IAssignable unassignable in selectedUnassignables)
                                {
                                    currentUnassignable = unassignable;
                                    Spare spareToAdd = new Spare(currentUnassignable.Huvudlager, currentUnassignable.Leverantör, currentUnassignable.Artikelbenämning, currentUnassignable.LeverantörArtikelNr, true);
                                    mainProgram.GetTypeByIndex(tempCurrentTypeIndex2).GetProductByIndex(tempCurrentProductIndex2).AddSpare(spareToAdd);
                                    mainProgram.RemoveUnassignedExtraByName(spareToAdd.Artikelbenämning);
                                    unassignablesCopy.Remove(currentUnassignable);
                                }
                                MessageBox.Show("Tilldelningen lyckad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                currentEvent = EventChooser.Normal;
                                selectedUnassignables.Clear();
                                LoadViewUnassignedItemsMenu(unassignablesCopy);
                                mainMenuUserControl.WasLastShown = true;
                            }
                            else
                                MessageBox.Show("Tilldelningen avbröts.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void OnAddExistingAccessory(object sender, EventArgs e)
        {
            currentEvent = EventChooser.Adding;
            isAddingSpare = false;
            LoadMainMenu();
            mainMenuUserControl.SetContextMenuStrip(false);
        }

        private void OnAddUnassignedAccessory(object sender, EventArgs e)
        {
            List<IAssignable> currentUnassignables = new List<IAssignable>();

            currentUnassignables.AddRange(mainProgram.GetUnassignedExtras());
            unassignablesCopy = currentUnassignables;

            currentEvent = EventChooser.Adding;
            isAddingSpare = false;

            LoadViewUnassignedItemsMenu(currentUnassignables);
        }

        private void OnPageInfoButtonClick(object sender, EventArgs e)
        {
            foreach (IMenu userControl in userControls)
            {
                if (userControl.IsShown)
                {
                    userControl.ShowPageInfo();
                }
            }
        }

        private void OnCancelActivityButtonClick(object sender, EventArgs e)
        {
            if (currentEvent == EventChooser.Adding)
            {
                currentEvent = EventChooser.Normal;
                confirmStage = false;
                LoadViewProductInfoMenu(mainProgram.GetTypeByIndex(currentTypeIndex).GetProductByIndex(currentProductIndex));
                viewProductsUserControl.WasLastShown = true;
            }
            else if (currentEvent == EventChooser.Assigning)
            {
                currentEvent = EventChooser.Normal;
                confirmStage = false;
                LoadMainMenu();
            }
        }

        private void OnAddExistingSpare(object sender, EventArgs e)
        {
            currentEvent = EventChooser.Adding;
            isAddingSpare = true;
            LoadMainMenu();
        }

        private void OnAddUnassignedSpare(object sender, EventArgs e)
        {
            List<IAssignable> currentUnassignables = new List<IAssignable>();

            currentUnassignables.AddRange(mainProgram.GetUnassignedExtras());
            unassignablesCopy = currentUnassignables;

            currentEvent = EventChooser.Adding;
            isAddingSpare = true;

            LoadViewUnassignedItemsMenu(currentUnassignables);
        }

        private void OnAttentionSignMouseHover(object sender, EventArgs e)
        {
            string tooltipText = "";
            if (currentEvent == EventChooser.Assigning)
                tooltipText = "Nu håller du på att tilldela en artikel. Navigera dit du vill tilldela artikeln. Klicka avbryt för att avbryta tilldelning.";
            else if(currentEvent == EventChooser.Adding)
                tooltipText = "Nu håller du på att välja en artikel att lägga till. Navigera till den artikel som du vill tillägga. Klicka avbryt för att avbryta tilldelning.";

            menuBarUserControl.SetAttentionSignToolTipText(tooltipText);
        }
     
        private void OnSetPicturesDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.ShowDialog();
            string folderPath = openFolderDialog.SelectedPath;
            mainProgram.Directory = folderPath;
            LoadMainMenu();
        }

        private void OnLoadExcelData(object sender, EventArgs e)
        {
            ExcelForm excelForm = new ExcelForm(currentTheme);
            excelForm.ShowDialog();
            if(excelForm.DialogResult == DialogResult.OK)
            {
                int firstRow = excelForm.GetFirstRow();
                IOClass.LoadDataFromExcel(mainProgram, firstRow);

            }
        }

        private void OnSaveData(object sender, EventArgs e)
        {
            IOClass.SaveData(mainProgram);
        }

        private void OnLoadData(object sender, EventArgs e)
        {
            MainProgram mainProgramCopy = mainProgram;
            mainProgram = IOClass.LoadData();

            if (mainProgram != null)
                LoadMainMenu();
            else
                mainProgram = mainProgramCopy;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);

            DialogResult result = MessageBox.Show("Är du säker på att du vill avsluta programmet? Alla icke-sparade ändringar kommer att försvinna.", "Nedstängning av program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            }

        }
    }
}   