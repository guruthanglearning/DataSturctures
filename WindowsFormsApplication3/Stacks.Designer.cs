namespace WindowsFormsApplication3
{
    partial class Stacks
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
            this.btn_Implement_Stack_as_a_queue = new System.Windows.Forms.Button();
            this.btn_Min_Stack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Implement_Stack_as_a_queue
            // 
            this.btn_Implement_Stack_as_a_queue.Location = new System.Drawing.Point(-4, 10);
            this.btn_Implement_Stack_as_a_queue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Implement_Stack_as_a_queue.Name = "btn_Implement_Stack_as_a_queue";
            this.btn_Implement_Stack_as_a_queue.Size = new System.Drawing.Size(477, 27);
            this.btn_Implement_Stack_as_a_queue.TabIndex = 21;
            this.btn_Implement_Stack_as_a_queue.Text = "Implement Stack as a queue";
            this.btn_Implement_Stack_as_a_queue.UseVisualStyleBackColor = true;
            this.btn_Implement_Stack_as_a_queue.Click += new System.EventHandler(this.btn_Implement_Stack_as_a_queue_Click);
            // 
            // btn_Min_Stack
            // 
            this.btn_Min_Stack.Location = new System.Drawing.Point(-4, 42);
            this.btn_Min_Stack.Name = "btn_Min_Stack";
            this.btn_Min_Stack.Size = new System.Drawing.Size(477, 29);
            this.btn_Min_Stack.TabIndex = 22;
            this.btn_Min_Stack.Text = "Min Stack";
            this.btn_Min_Stack.UseVisualStyleBackColor = true;
            this.btn_Min_Stack.Click += new System.EventHandler(this.btn_Min_Stack_Click);
            // 
            // Stacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 195);
            this.Controls.Add(this.btn_Min_Stack);
            this.Controls.Add(this.btn_Implement_Stack_as_a_queue);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Stacks";
            this.Text = "Stacks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implement_Stack_as_a_queue;
        private System.Windows.Forms.Button btn_Min_Stack;
    }
}