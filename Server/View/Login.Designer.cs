
namespace Server.View
{
    partial class Login
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
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.uxUsernameBox = new System.Windows.Forms.TextBox();
            this.uxPasswordBox = new System.Windows.Forms.TextBox();
            this.uxUsernameLabel = new System.Windows.Forms.Label();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(160, 165);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(97, 49);
            this.uxLoginButton.TabIndex = 0;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            // 
            // uxUsernameBox
            // 
            this.uxUsernameBox.Location = new System.Drawing.Point(160, 49);
            this.uxUsernameBox.Name = "uxUsernameBox";
            this.uxUsernameBox.Size = new System.Drawing.Size(167, 20);
            this.uxUsernameBox.TabIndex = 1;
            // 
            // uxPasswordBox
            // 
            this.uxPasswordBox.Location = new System.Drawing.Point(160, 97);
            this.uxPasswordBox.Name = "uxPasswordBox";
            this.uxPasswordBox.Size = new System.Drawing.Size(167, 20);
            this.uxPasswordBox.TabIndex = 2;
            // 
            // uxUsernameLabel
            // 
            this.uxUsernameLabel.AutoSize = true;
            this.uxUsernameLabel.Location = new System.Drawing.Point(43, 52);
            this.uxUsernameLabel.Name = "uxUsernameLabel";
            this.uxUsernameLabel.Size = new System.Drawing.Size(60, 13);
            this.uxUsernameLabel.TabIndex = 3;
            this.uxUsernameLabel.Text = "User Name";
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Location = new System.Drawing.Point(43, 100);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.uxPasswordLabel.TabIndex = 4;
            this.uxPasswordLabel.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 238);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxUsernameLabel);
            this.Controls.Add(this.uxPasswordBox);
            this.Controls.Add(this.uxUsernameBox);
            this.Controls.Add(this.uxLoginButton);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxLoginButton;
        private System.Windows.Forms.TextBox uxUsernameBox;
        private System.Windows.Forms.TextBox uxPasswordBox;
        private System.Windows.Forms.Label uxUsernameLabel;
        private System.Windows.Forms.Label uxPasswordLabel;
    }
}