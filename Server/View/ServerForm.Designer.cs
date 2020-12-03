
namespace Server
{
    partial class uxServerForm
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
            this.components = new System.ComponentModel.Container();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxProductListBox = new System.Windows.Forms.ListBox();
            this.uxClientListBox = new System.Windows.Forms.ListBox();
            this.uxStopBidding = new System.Windows.Forms.Button();
            this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(327, 355);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(156, 80);
            this.uxAddButton.TabIndex = 0;
            this.uxAddButton.Text = "Add";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxProductListBox
            // 
            this.uxProductListBox.FormattingEnabled = true;
            this.uxProductListBox.Location = new System.Drawing.Point(12, 12);
            this.uxProductListBox.Name = "uxProductListBox";
            this.uxProductListBox.Size = new System.Drawing.Size(233, 329);
            this.uxProductListBox.TabIndex = 1;
            // 
            // uxClientListBox
            // 
            this.uxClientListBox.FormattingEnabled = true;
            this.uxClientListBox.Location = new System.Drawing.Point(251, 12);
            this.uxClientListBox.Name = "uxClientListBox";
            this.uxClientListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uxClientListBox.Size = new System.Drawing.Size(232, 329);
            this.uxClientListBox.TabIndex = 2;
            // 
            // uxStopBidding
            // 
            this.uxStopBidding.Location = new System.Drawing.Point(12, 355);
            this.uxStopBidding.Name = "uxStopBidding";
            this.uxStopBidding.Size = new System.Drawing.Size(156, 80);
            this.uxStopBidding.TabIndex = 3;
            this.uxStopBidding.Text = "Stop Bidding";
            this.uxStopBidding.UseVisualStyleBackColor = true;
            this.uxStopBidding.Click += new System.EventHandler(this.uxStopBidding_Click);
            // 
            // databaseBindingSource
            // 
            this.databaseBindingSource.DataSource = typeof(Server.Model.Database);
            // 
            // databaseBindingSource1
            // 
            this.databaseBindingSource1.DataSource = typeof(Server.Model.Database);
            // 
            // uxServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 447);
            this.Controls.Add(this.uxStopBidding);
            this.Controls.Add(this.uxClientListBox);
            this.Controls.Add(this.uxProductListBox);
            this.Controls.Add(this.uxAddButton);
            this.Name = "uxServerForm";
            this.Text = "ServerForm";
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxAddButton;
        private System.Windows.Forms.ListBox uxProductListBox;
        private System.Windows.Forms.ListBox uxClientListBox;
        private System.Windows.Forms.Button uxStopBidding;
        private System.Windows.Forms.BindingSource databaseBindingSource;
        private System.Windows.Forms.BindingSource databaseBindingSource1;
    }
}

