using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stokageapp.Forms
{
    public partial class Menu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form currentChildForm;

        public Menu()
        {
            InitializeComponent();
            random = new Random();
            buttonCloseChildForm.Visible = false;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(Themecolor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(Themecolor.ColorList.Count);
            }
            tempIndex = index;
            string color = Themecolor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelLogo.BackColor = Themecolor.ChangeColorBrightness(color, -0.3);
                    Themecolor.PrimaryColor = color;
                    Themecolor.SecondaryColor = Themecolor.ChangeColorBrightness(color, -0.3);
                    buttonCloseChildForm.Visible = true;
                }
            }
        }
        
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(217, 108, 13);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            ActivateButton(btnSender);
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelAcceuil.Text = childForm.Text;
        }   
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormAddItem(), sender);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormDelItem(), sender);
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormItems(), sender);
        }

        private void buttonCloseChildForm_Click(object sender, EventArgs e)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            labelAcceuil.Text = "Acceuil";
            panelTitleBar.BackColor = Color.FromArgb(240, 175, 22);
            panelLogo.BackColor = Color.FromArgb(201, 75, 2);
            currentChildForm = null;
            buttonCloseChildForm.Visible = false;
        }
    }
}
