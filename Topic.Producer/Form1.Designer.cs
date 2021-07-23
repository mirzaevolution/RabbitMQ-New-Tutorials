
namespace Topic.Producer
{
    partial class formExchangeTopicProducer
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
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogCustomerCreated = new System.Windows.Forms.Button();
            this.buttonLogsCustomerUpdated = new System.Windows.Forms.Button();
            this.buttonLogsOrderAnyCompleted = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exchange.Topic Producer";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(12, 87);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(315, 75);
            this.textBoxMessage.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type your message here:";
            // 
            // buttonLogCustomerCreated
            // 
            this.buttonLogCustomerCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogCustomerCreated.Location = new System.Drawing.Point(11, 168);
            this.buttonLogCustomerCreated.Name = "buttonLogCustomerCreated";
            this.buttonLogCustomerCreated.Size = new System.Drawing.Size(316, 29);
            this.buttonLogCustomerCreated.TabIndex = 3;
            this.buttonLogCustomerCreated.Tag = "logs.customer.created";
            this.buttonLogCustomerCreated.Text = "logs.customer.created";
            this.buttonLogCustomerCreated.UseVisualStyleBackColor = true;
            // 
            // buttonLogsCustomerUpdated
            // 
            this.buttonLogsCustomerUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogsCustomerUpdated.Location = new System.Drawing.Point(11, 199);
            this.buttonLogsCustomerUpdated.Name = "buttonLogsCustomerUpdated";
            this.buttonLogsCustomerUpdated.Size = new System.Drawing.Size(316, 29);
            this.buttonLogsCustomerUpdated.TabIndex = 4;
            this.buttonLogsCustomerUpdated.Tag = "logs.customer.updated";
            this.buttonLogsCustomerUpdated.Text = "logs.customer.updated";
            this.buttonLogsCustomerUpdated.UseVisualStyleBackColor = true;
            // 
            // buttonLogsOrderAnyCompleted
            // 
            this.buttonLogsOrderAnyCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogsOrderAnyCompleted.Location = new System.Drawing.Point(11, 230);
            this.buttonLogsOrderAnyCompleted.Name = "buttonLogsOrderAnyCompleted";
            this.buttonLogsOrderAnyCompleted.Size = new System.Drawing.Size(316, 29);
            this.buttonLogsOrderAnyCompleted.TabIndex = 5;
            this.buttonLogsOrderAnyCompleted.Tag = "logs.order.*.completed";
            this.buttonLogsOrderAnyCompleted.Text = "logs.order.*.completed";
            this.buttonLogsOrderAnyCompleted.UseVisualStyleBackColor = true;
            // 
            // formExchangeTopicProducer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 279);
            this.Controls.Add(this.buttonLogsOrderAnyCompleted);
            this.Controls.Add(this.buttonLogsCustomerUpdated);
            this.Controls.Add(this.buttonLogCustomerCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formExchangeTopicProducer";
            this.Text = "Exchange.Topic Producer";
            this.Load += new System.EventHandler(this.formExchangeTopicProducer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogCustomerCreated;
        private System.Windows.Forms.Button buttonLogsCustomerUpdated;
        private System.Windows.Forms.Button buttonLogsOrderAnyCompleted;
    }
}

