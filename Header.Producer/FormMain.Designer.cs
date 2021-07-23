
namespace Header.Producer
{
    partial class FormMain
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
            this.buttonCustomerDeleted = new System.Windows.Forms.Button();
            this.buttonCustomerUpdated = new System.Windows.Forms.Button();
            this.buttonCustomerCreated = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOrderPlaced = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCustomerDeleted
            // 
            this.buttonCustomerDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomerDeleted.Location = new System.Drawing.Point(9, 230);
            this.buttonCustomerDeleted.Name = "buttonCustomerDeleted";
            this.buttonCustomerDeleted.Size = new System.Drawing.Size(316, 29);
            this.buttonCustomerDeleted.TabIndex = 11;
            this.buttonCustomerDeleted.Tag = "Customer.Deleted";
            this.buttonCustomerDeleted.Text = "Customer.Deleted";
            this.buttonCustomerDeleted.UseVisualStyleBackColor = true;
            // 
            // buttonCustomerUpdated
            // 
            this.buttonCustomerUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomerUpdated.Location = new System.Drawing.Point(9, 199);
            this.buttonCustomerUpdated.Name = "buttonCustomerUpdated";
            this.buttonCustomerUpdated.Size = new System.Drawing.Size(316, 29);
            this.buttonCustomerUpdated.TabIndex = 10;
            this.buttonCustomerUpdated.Tag = "Customer.Updated";
            this.buttonCustomerUpdated.Text = "Customer.Updated";
            this.buttonCustomerUpdated.UseVisualStyleBackColor = true;
            // 
            // buttonCustomerCreated
            // 
            this.buttonCustomerCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomerCreated.Location = new System.Drawing.Point(9, 168);
            this.buttonCustomerCreated.Name = "buttonCustomerCreated";
            this.buttonCustomerCreated.Size = new System.Drawing.Size(316, 29);
            this.buttonCustomerCreated.TabIndex = 9;
            this.buttonCustomerCreated.Tag = "Customer.Created";
            this.buttonCustomerCreated.Text = "Customer.Created";
            this.buttonCustomerCreated.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type your message here:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.Black;
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.ForeColor = System.Drawing.Color.Lime;
            this.textBoxMessage.Location = new System.Drawing.Point(10, 87);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(315, 75);
            this.textBoxMessage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Exchange.Topic Header";
            // 
            // buttonOrderPlaced
            // 
            this.buttonOrderPlaced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrderPlaced.Location = new System.Drawing.Point(10, 262);
            this.buttonOrderPlaced.Name = "buttonOrderPlaced";
            this.buttonOrderPlaced.Size = new System.Drawing.Size(316, 29);
            this.buttonOrderPlaced.TabIndex = 12;
            this.buttonOrderPlaced.Tag = "Order.Placed";
            this.buttonOrderPlaced.Text = "Order.Placed";
            this.buttonOrderPlaced.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 312);
            this.Controls.Add(this.buttonOrderPlaced);
            this.Controls.Add(this.buttonCustomerDeleted);
            this.Controls.Add(this.buttonCustomerUpdated);
            this.Controls.Add(this.buttonCustomerCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange.Topic Header";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCustomerDeleted;
        private System.Windows.Forms.Button buttonCustomerUpdated;
        private System.Windows.Forms.Button buttonCustomerCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOrderPlaced;
    }
}

