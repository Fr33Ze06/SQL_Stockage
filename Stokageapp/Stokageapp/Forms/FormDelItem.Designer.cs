namespace Stokageapp.Forms
{
    partial class FormDelItem
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
            this.panelDelItem = new System.Windows.Forms.Panel();
            this.buttonDelstockitem = new System.Windows.Forms.Button();
            this.listViewobjets = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxEntrepot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuantityD = new System.Windows.Forms.TextBox();
            this.textBoxItemNameD = new System.Windows.Forms.TextBox();
            this.panelDelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDelItem
            // 
            this.panelDelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelDelItem.Controls.Add(this.buttonDelstockitem);
            this.panelDelItem.Controls.Add(this.listViewobjets);
            this.panelDelItem.Controls.Add(this.label3);
            this.panelDelItem.Controls.Add(this.listBoxEntrepot);
            this.panelDelItem.Controls.Add(this.label2);
            this.panelDelItem.Controls.Add(this.label1);
            this.panelDelItem.Controls.Add(this.textBoxQuantityD);
            this.panelDelItem.Controls.Add(this.textBoxItemNameD);
            this.panelDelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDelItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelDelItem.Location = new System.Drawing.Point(0, 0);
            this.panelDelItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDelItem.Name = "panelDelItem";
            this.panelDelItem.Size = new System.Drawing.Size(572, 406);
            this.panelDelItem.TabIndex = 0;
            // 
            // buttonDelstockitem
            // 
            this.buttonDelstockitem.FlatAppearance.BorderSize = 0;
            this.buttonDelstockitem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelstockitem.Location = new System.Drawing.Point(36, 249);
            this.buttonDelstockitem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelstockitem.Name = "buttonDelstockitem";
            this.buttonDelstockitem.Size = new System.Drawing.Size(98, 39);
            this.buttonDelstockitem.TabIndex = 18;
            this.buttonDelstockitem.Text = "Supprimer l\'objet";
            this.buttonDelstockitem.UseVisualStyleBackColor = true;
            this.buttonDelstockitem.Click += new System.EventHandler(this.buttonDelstockitem_Click);
            // 
            // listViewobjets
            // 
            this.listViewobjets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewobjets.HideSelection = false;
            this.listViewobjets.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listViewobjets.Location = new System.Drawing.Point(334, 29);
            this.listViewobjets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewobjets.Name = "listViewobjets";
            this.listViewobjets.Size = new System.Drawing.Size(229, 334);
            this.listViewobjets.TabIndex = 17;
            this.listViewobjets.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sélectioner l\'entrepot";
            // 
            // listBoxEntrepot
            // 
            this.listBoxEntrepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBoxEntrepot.FormattingEnabled = true;
            this.listBoxEntrepot.Location = new System.Drawing.Point(37, 116);
            this.listBoxEntrepot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxEntrepot.Name = "listBoxEntrepot";
            this.listBoxEntrepot.Size = new System.Drawing.Size(156, 21);
            this.listBoxEntrepot.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantitée";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nom de l\'objet";
            // 
            // textBoxQuantityD
            // 
            this.textBoxQuantityD.Location = new System.Drawing.Point(36, 226);
            this.textBoxQuantityD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxQuantityD.Name = "textBoxQuantityD";
            this.textBoxQuantityD.Size = new System.Drawing.Size(156, 20);
            this.textBoxQuantityD.TabIndex = 11;
            // 
            // textBoxItemNameD
            // 
            this.textBoxItemNameD.Location = new System.Drawing.Point(36, 167);
            this.textBoxItemNameD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxItemNameD.Name = "textBoxItemNameD";
            this.textBoxItemNameD.Size = new System.Drawing.Size(157, 20);
            this.textBoxItemNameD.TabIndex = 10;
            // 
            // FormDelItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 406);
            this.Controls.Add(this.panelDelItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDelItem";
            this.Text = "Suppression d\'objet";
            this.panelDelItem.ResumeLayout(false);
            this.panelDelItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox listBoxEntrepot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuantityD;
        private System.Windows.Forms.TextBox textBoxItemNameD;
        private System.Windows.Forms.ListView listViewobjets;
        private System.Windows.Forms.Panel panelDelItem;
        private System.Windows.Forms.Button buttonDelstockitem;
    }
}