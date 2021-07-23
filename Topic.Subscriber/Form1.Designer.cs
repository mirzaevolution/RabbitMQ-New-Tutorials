
namespace Topic.Subscriber
{
    partial class formExchangeTopicSubscribers
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxLogsCustomerCreated = new System.Windows.Forms.ListBox();
            this.listBoxLogsCustomerUpdated = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxLogsOrderAnyCompleted = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exchange.Topic Subscribers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "logs.customer.created\t";
            // 
            // listBoxLogsCustomerCreated
            // 
            this.listBoxLogsCustomerCreated.BackColor = System.Drawing.Color.Black;
            this.listBoxLogsCustomerCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLogsCustomerCreated.ForeColor = System.Drawing.Color.Lime;
            this.listBoxLogsCustomerCreated.FormattingEnabled = true;
            this.listBoxLogsCustomerCreated.ItemHeight = 16;
            this.listBoxLogsCustomerCreated.Location = new System.Drawing.Point(15, 95);
            this.listBoxLogsCustomerCreated.Name = "listBoxLogsCustomerCreated";
            this.listBoxLogsCustomerCreated.Size = new System.Drawing.Size(480, 116);
            this.listBoxLogsCustomerCreated.TabIndex = 4;
            // 
            // listBoxLogsCustomerUpdated
            // 
            this.listBoxLogsCustomerUpdated.BackColor = System.Drawing.Color.Black;
            this.listBoxLogsCustomerUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLogsCustomerUpdated.ForeColor = System.Drawing.Color.Lime;
            this.listBoxLogsCustomerUpdated.FormattingEnabled = true;
            this.listBoxLogsCustomerUpdated.ItemHeight = 16;
            this.listBoxLogsCustomerUpdated.Location = new System.Drawing.Point(17, 264);
            this.listBoxLogsCustomerUpdated.Name = "listBoxLogsCustomerUpdated";
            this.listBoxLogsCustomerUpdated.Size = new System.Drawing.Size(480, 116);
            this.listBoxLogsCustomerUpdated.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "logs.customer.updated";
            // 
            // listBoxLogsOrderAnyCompleted
            // 
            this.listBoxLogsOrderAnyCompleted.BackColor = System.Drawing.Color.Black;
            this.listBoxLogsOrderAnyCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLogsOrderAnyCompleted.ForeColor = System.Drawing.Color.Lime;
            this.listBoxLogsOrderAnyCompleted.FormattingEnabled = true;
            this.listBoxLogsOrderAnyCompleted.ItemHeight = 16;
            this.listBoxLogsOrderAnyCompleted.Location = new System.Drawing.Point(17, 438);
            this.listBoxLogsOrderAnyCompleted.Name = "listBoxLogsOrderAnyCompleted";
            this.listBoxLogsOrderAnyCompleted.Size = new System.Drawing.Size(480, 116);
            this.listBoxLogsOrderAnyCompleted.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "logs.order.*.completed";
            // 
            // formExchangeTopicSubscribers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 599);
            this.Controls.Add(this.listBoxLogsOrderAnyCompleted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxLogsCustomerUpdated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxLogsCustomerCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "formExchangeTopicSubscribers";
            this.Text = "Exchange.Topic Subscrbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxLogsCustomerCreated;
        private System.Windows.Forms.ListBox listBoxLogsCustomerUpdated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxLogsOrderAnyCompleted;
        private System.Windows.Forms.Label label4;
    }
}

