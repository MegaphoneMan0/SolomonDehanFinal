
namespace Server.View
{
    partial class uxAddProductForm
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
            this.uxProductsToAddBox = new System.Windows.Forms.ListBox();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxProductsToAddBox
            // 
            this.uxProductsToAddBox.FormattingEnabled = true;
            this.uxProductsToAddBox.Location = new System.Drawing.Point(12, 12);
            this.uxProductsToAddBox.Name = "uxProductsToAddBox";
            this.uxProductsToAddBox.Size = new System.Drawing.Size(295, 394);
            this.uxProductsToAddBox.TabIndex = 0;
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(114, 429);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(75, 23);
            this.uxAddButton.TabIndex = 1;
            this.uxAddButton.Text = "Add";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxAddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 489);
            this.Controls.Add(this.uxAddButton);
            this.Controls.Add(this.uxProductsToAddBox);
            this.Name = "uxAddProductForm";
            this.Text = "Add Product";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox uxProductsToAddBox;
        private System.Windows.Forms.Button uxAddButton;
    }
}