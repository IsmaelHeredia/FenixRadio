namespace FenixRadio
{
    partial class FormEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtCategories = new Telerik.WinControls.UI.RadTextBox();
            this.txtLink = new Telerik.WinControls.UI.RadTextBox();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.lblCategories = new Telerik.WinControls.UI.RadLabel();
            this.lblLink = new Telerik.WinControls.UI.RadLabel();
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(102, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtCategories);
            this.radGroupBox1.Controls.Add(this.txtLink);
            this.radGroupBox1.Controls.Add(this.txtName);
            this.radGroupBox1.Controls.Add(this.lblCategories);
            this.radGroupBox1.Controls.Add(this.lblLink);
            this.radGroupBox1.Controls.Add(this.lblName);
            this.radGroupBox1.HeaderText = "Enter data";
            this.radGroupBox1.Location = new System.Drawing.Point(21, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(268, 149);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Enter data";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtCategories
            // 
            this.txtCategories.Location = new System.Drawing.Point(98, 107);
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.Size = new System.Drawing.Size(151, 20);
            this.txtCategories.TabIndex = 6;
            this.txtCategories.ThemeName = "TelerikMetro";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(98, 71);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(151, 20);
            this.txtLink.TabIndex = 5;
            this.txtLink.ThemeName = "TelerikMetro";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 4;
            this.txtName.ThemeName = "TelerikMetro";
            // 
            // lblCategories
            // 
            this.lblCategories.Location = new System.Drawing.Point(28, 107);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(68, 18);
            this.lblCategories.TabIndex = 2;
            this.lblCategories.Text = "Categories : ";
            this.lblCategories.ThemeName = "TelerikMetro";
            // 
            // lblLink
            // 
            this.lblLink.Location = new System.Drawing.Point(27, 71);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(35, 18);
            this.lblLink.TabIndex = 1;
            this.lblLink.Text = "Link : ";
            this.lblLink.ThemeName = "TelerikMetro";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(27, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name : ";
            this.lblName.ThemeName = "TelerikMetro";
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 226);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormEdit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Edit station";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtCategories;
        private Telerik.WinControls.UI.RadTextBox txtLink;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel lblCategories;
        private Telerik.WinControls.UI.RadLabel lblLink;
        private Telerik.WinControls.UI.RadLabel lblName;
    }
}
