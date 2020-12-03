
namespace Client.View
{
    partial class Bid501
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
            this.bidButton = new System.Windows.Forms.Button();
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxInput = new System.Windows.Forms.TextBox();
            this.uxBids = new System.Windows.Forms.Label();
            this.uxMinBid = new System.Windows.Forms.Label();
            this.uxStatusLabel = new System.Windows.Forms.Label();
            this.uxRemainingTime = new System.Windows.Forms.Label();
            this.uxProductName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bidButton
            // 
            this.bidButton.Location = new System.Drawing.Point(60, 348);
            this.bidButton.Name = "bidButton";
            this.bidButton.Size = new System.Drawing.Size(148, 65);
            this.bidButton.TabIndex = 0;
            this.bidButton.Text = "Place Bid";
            this.bidButton.UseVisualStyleBackColor = true;
            this.bidButton.Click += new System.EventHandler(this.bidButton_Click);
            // 
            // uxListBox
            // 
            this.uxListBox.AllowDrop = true;
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.ItemHeight = 16;
            this.uxListBox.Location = new System.Drawing.Point(492, 122);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(147, 228);
            this.uxListBox.TabIndex = 1;
            this.uxListBox.SelectedIndexChanged += new System.EventHandler(this.uxListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Products";
            // 
            // uxInput
            // 
            this.uxInput.Location = new System.Drawing.Point(60, 253);
            this.uxInput.Name = "uxInput";
            this.uxInput.Size = new System.Drawing.Size(100, 22);
            this.uxInput.TabIndex = 4;
            // 
            // uxBids
            // 
            this.uxBids.Location = new System.Drawing.Point(177, 253);
            this.uxBids.Name = "uxBids";
            this.uxBids.Size = new System.Drawing.Size(103, 25);
            this.uxBids.TabIndex = 5;
            this.uxBids.Text = "(0 bids)";
            // 
            // uxMinBid
            // 
            this.uxMinBid.Location = new System.Drawing.Point(57, 304);
            this.uxMinBid.Name = "uxMinBid";
            this.uxMinBid.Size = new System.Drawing.Size(151, 25);
            this.uxMinBid.TabIndex = 6;
            this.uxMinBid.Text = "Minimum bid $";
            // 
            // uxStatusLabel
            // 
            this.uxStatusLabel.Location = new System.Drawing.Point(48, 201);
            this.uxStatusLabel.Name = "uxStatusLabel";
            this.uxStatusLabel.Size = new System.Drawing.Size(74, 25);
            this.uxStatusLabel.TabIndex = 7;
            this.uxStatusLabel.Text = "Status: ";
            // 
            // uxRemainingTime
            // 
            this.uxRemainingTime.Location = new System.Drawing.Point(48, 160);
            this.uxRemainingTime.Name = "uxRemainingTime";
            this.uxRemainingTime.Size = new System.Drawing.Size(196, 25);
            this.uxRemainingTime.TabIndex = 8;
            this.uxRemainingTime.Text = "min left";
            // 
            // uxProductName
            // 
            this.uxProductName.Location = new System.Drawing.Point(48, 135);
            this.uxProductName.Name = "uxProductName";
            this.uxProductName.Size = new System.Drawing.Size(425, 25);
            this.uxProductName.TabIndex = 9;
            this.uxProductName.Text = "Product Name";
            // 
            // Bid501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this.uxProductName);
            this.Controls.Add(this.uxRemainingTime);
            this.Controls.Add(this.uxStatusLabel);
            this.Controls.Add(this.uxMinBid);
            this.Controls.Add(this.uxBids);
            this.Controls.Add(this.uxInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxListBox);
            this.Controls.Add(this.bidButton);
            this.Name = "Bid501";
            this.Text = "Bid501";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bidButton;
        private System.Windows.Forms.ListBox uxListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxInput;
        private System.Windows.Forms.Label uxBids;
        private System.Windows.Forms.Label uxMinBid;
        private System.Windows.Forms.Label uxStatusLabel;
        private System.Windows.Forms.Label uxRemainingTime;
        private System.Windows.Forms.Label uxProductName;
    }
}

