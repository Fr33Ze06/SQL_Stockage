namespace Stokageapp.Forms
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.buttonCloseChildForm = new System.Windows.Forms.Button();
            this.labelAcceuil = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(108)))), ((int)(((byte)(13)))));
            this.panelMenu.Controls.Add(this.buttonList);
            this.panelMenu.Controls.Add(this.buttonDel);
            this.panelMenu.Controls.Add(this.buttonAdd);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 647);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonList
            // 
            this.buttonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonList.FlatAppearance.BorderSize = 0;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonList.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonList.Image = global::Stokageapp.Properties.Resources.pngfind_com_minecraft_icons_png_6370904;
            this.buttonList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonList.Location = new System.Drawing.Point(0, 220);
            this.buttonList.Name = "buttonList";
            this.buttonList.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.buttonList.Size = new System.Drawing.Size(220, 60);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = " Afficher liste";
            this.buttonList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDel.FlatAppearance.BorderSize = 0;
            this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDel.Image = global::Stokageapp.Properties.Resources.@__bdd;
            this.buttonDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDel.Location = new System.Drawing.Point(0, 160);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.buttonDel.Size = new System.Drawing.Size(220, 60);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = " Supprimer un objet";
            this.buttonDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdd.Image = global::Stokageapp.Properties.Resources.bdd___Copie;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(0, 100);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(220, 60);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = " Ajouter un objet";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(75)))), ((int)(((byte)(2)))));
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLogo.Image = global::Stokageapp.Properties.Resources.packages;
            this.pictureBoxLogo.Location = new System.Drawing.Point(87, 27);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(175)))), ((int)(((byte)(22)))));
            this.panelTitleBar.Controls.Add(this.buttonCloseChildForm);
            this.panelTitleBar.Controls.Add(this.labelAcceuil);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(780, 100);
            this.panelTitleBar.TabIndex = 1;
            // 
            // buttonCloseChildForm
            // 
            this.buttonCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCloseChildForm.FlatAppearance.BorderSize = 0;
            this.buttonCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseChildForm.Image = global::Stokageapp.Properties.Resources.white_x_icon;
            this.buttonCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.buttonCloseChildForm.Name = "buttonCloseChildForm";
            this.buttonCloseChildForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCloseChildForm.Size = new System.Drawing.Size(50, 100);
            this.buttonCloseChildForm.TabIndex = 1;
            this.buttonCloseChildForm.UseVisualStyleBackColor = true;
            this.buttonCloseChildForm.Click += new System.EventHandler(this.buttonCloseChildForm_Click);
            // 
            // labelAcceuil
            // 
            this.labelAcceuil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAcceuil.AutoSize = true;
            this.labelAcceuil.Font = new System.Drawing.Font("Onyx", 25F);
            this.labelAcceuil.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelAcceuil.Location = new System.Drawing.Point(343, 27);
            this.labelAcceuil.Name = "labelAcceuil";
            this.labelAcceuil.Size = new System.Drawing.Size(89, 47);
            this.labelAcceuil.TabIndex = 0;
            this.labelAcceuil.Text = "Acceuil";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 100);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(780, 547);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // Menu
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1000, 647);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Stock Manager";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label labelAcceuil;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button buttonCloseChildForm;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}