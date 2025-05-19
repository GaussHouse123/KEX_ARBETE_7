using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class PageNavigatorUserControl : UserControl
    {
        private List<Label> labels;

        public event EventHandler OnLabelClickEventHandler;
        public event EventHandler OnForwardButtonClickEventHandler;
        public event EventHandler OnBackButtonClickEventHandler;


        public PageNavigatorUserControl()
        {
            InitializeComponent();
            this.labels = new List<Label>();
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
        }

        public Label GetLabel(string labelName)
        {
            foreach (Label label in labels)
            {
                if (label.Name == labelName)
                {
                    return label;
                }
            }
            return null;
        }

        public Label GetLabelFromText(string labelText)
        {
            foreach (Label label in labels)
            {
                if (label.Text == labelText)
                {
                    return label;
                }
            }
            return null;
        }

        private void LabelClick(object sender, EventArgs e)
        {
            OnLabelClickEventHandler?.Invoke(sender, e);
        }

        public Button GetForwardButton()
        {
            return this.forwardButton;
        }

        public Button GetBackButton()
        {
            return this.backButton;
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            OnForwardButtonClickEventHandler?.Invoke(this, e);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            OnBackButtonClickEventHandler?.Invoke(this, e);
        }
    }
}
