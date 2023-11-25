namespace Stokageapp.Forms
{
    partial class FormAddItem
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
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelAddN = new System.Windows.Forms.Label();
            this.labelAddQ = new System.Windows.Forms.Label();
            this.buttonAdditemtostock = new System.Windows.Forms.Button();
            this.listBoxEntrepot = new System.Windows.Forms.ComboBox();
            this.labelAddE = new System.Windows.Forms.Label();
            this.listBoxTypes = new System.Windows.Forms.ComboBox();
            this.labelAddT = new System.Windows.Forms.Label();
            this.listViewobjets = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(43, 159);
            this.textBoxItemName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(157, 20);
            this.textBoxItemName.TabIndex = 1;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(44, 264);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(156, 20);
            this.textBoxQuantity.TabIndex = 2;
            // 
            // labelAddN
            // 
            this.labelAddN.AutoSize = true;
            this.labelAddN.ForeColor = System.Drawing.Color.Black;
            this.labelAddN.Location = new System.Drawing.Point(41, 144);
            this.labelAddN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddN.Name = "labelAddN";
            this.labelAddN.Size = new System.Drawing.Size(74, 13);
            this.labelAddN.TabIndex = 3;
            this.labelAddN.Text = "Nom de l\'objet";
            // 
            // labelAddQ
            // 
            this.labelAddQ.AutoSize = true;
            this.labelAddQ.ForeColor = System.Drawing.Color.Black;
            this.labelAddQ.Location = new System.Drawing.Point(41, 249);
            this.labelAddQ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddQ.Name = "labelAddQ";
            this.labelAddQ.Size = new System.Drawing.Size(53, 13);
            this.labelAddQ.TabIndex = 4;
            this.labelAddQ.Text = "Quantitée";
            // 
            // buttonAdditemtostock
            // 
            this.buttonAdditemtostock.FlatAppearance.BorderSize = 0;
            this.buttonAdditemtostock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdditemtostock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAdditemtostock.Location = new System.Drawing.Point(44, 296);
            this.buttonAdditemtostock.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdditemtostock.Name = "buttonAdditemtostock";
            this.buttonAdditemtostock.Size = new System.Drawing.Size(98, 38);
            this.buttonAdditemtostock.TabIndex = 5;
            this.buttonAdditemtostock.Text = "Ajouter l\'objet";
            this.buttonAdditemtostock.UseVisualStyleBackColor = true;
            this.buttonAdditemtostock.Click += new System.EventHandler(this.buttonAdditemtostock_Click);
            // 
            // listBoxEntrepot
            // 
            this.listBoxEntrepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBoxEntrepot.FormattingEnabled = true;
            this.listBoxEntrepot.Location = new System.Drawing.Point(44, 108);
            this.listBoxEntrepot.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxEntrepot.Name = "listBoxEntrepot";
            this.listBoxEntrepot.Size = new System.Drawing.Size(156, 21);
            this.listBoxEntrepot.TabIndex = 15;
            // 
            // labelAddE
            // 
            this.labelAddE.AutoSize = true;
            this.labelAddE.ForeColor = System.Drawing.Color.Black;
            this.labelAddE.Location = new System.Drawing.Point(40, 93);
            this.labelAddE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddE.Name = "labelAddE";
            this.labelAddE.Size = new System.Drawing.Size(106, 13);
            this.labelAddE.TabIndex = 7;
            this.labelAddE.Text = "Sélectioner l\'entrepot";
            // 
            // listBoxTypes
            // 
            this.listBoxTypes.FormattingEnabled = true;
            this.listBoxTypes.Location = new System.Drawing.Point(43, 210);
            this.listBoxTypes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTypes.Name = "listBoxTypes";
            this.listBoxTypes.Size = new System.Drawing.Size(157, 21);
            this.listBoxTypes.TabIndex = 8;
            // 
            // labelAddT
            // 
            this.labelAddT.AutoSize = true;
            this.labelAddT.ForeColor = System.Drawing.Color.Black;
            this.labelAddT.Location = new System.Drawing.Point(40, 195);
            this.labelAddT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddT.Name = "labelAddT";
            this.labelAddT.Size = new System.Drawing.Size(145, 13);
            this.labelAddT.TabIndex = 9;
            this.labelAddT.Text = "Sélectionner le type de l\'objet";
            // 
            // listViewobjets
            // 
            this.listViewobjets.HideSelection = false;
            this.listViewobjets.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listViewobjets.Location = new System.Drawing.Point(334, 25);
            this.listViewobjets.Margin = new System.Windows.Forms.Padding(2);
            this.listViewobjets.Name = "listViewobjets";
            this.listViewobjets.Size = new System.Drawing.Size(230, 385);
            this.listViewobjets.TabIndex = 10;
            this.listViewobjets.UseCompatibleStateImageBehavior = false;
            // 
            // FormAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(585, 444);
            this.Controls.Add(this.listViewobjets);
            this.Controls.Add(this.listBoxTypes);
            this.Controls.Add(this.listBoxEntrepot);
            this.Controls.Add(this.buttonAdditemtostock);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.labelAddN);
            this.Controls.Add(this.labelAddQ);
            this.Controls.Add(this.labelAddE);
            this.Controls.Add(this.labelAddT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAddItem";
            this.Text = "Ajout d\'objet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelAddN;
        private System.Windows.Forms.Label labelAddQ;
        private System.Windows.Forms.Button buttonAdditemtostock;
        private System.Windows.Forms.ComboBox listBoxEntrepot;
        private System.Windows.Forms.Label labelAddE;
        private System.Windows.Forms.ComboBox listBoxTypes;
        private System.Windows.Forms.Label labelAddT;
        private System.Windows.Forms.ListView listViewobjets;
    }
}