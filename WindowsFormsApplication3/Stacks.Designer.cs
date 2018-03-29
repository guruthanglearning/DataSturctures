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
            this.SuspendLayout();
            // 
            // btn_Implement_Stack_as_a_queue
            // 
            this.btn_Implement_Stack_as_a_queue.Location = new System.Drawing.Point(0, 12);
            this.btn_Implement_Stack_as_a_queue.Name = "btn_Implement_Stack_as_a_queue";
            this.btn_Implement_Stack_as_a_queue.Size = new System.Drawing.Size(537, 34);
            this.btn_Implement_Stack_as_a_queue.TabIndex = 21;
            this.btn_Implement_Stack_as_a_queue.Text = "Implement Stack as a queue";
            this.btn_Implement_Stack_as_a_queue.UseVisualStyleBackColor = true;
            this.btn_Implement_Stack_as_a_queue.Click += new System.EventHandler(this.btn_Implement_Stack_as_a_queue_Click);
            // 
            // Stacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 244);
            this.Controls.Add(this.btn_Implement_Stack_as_a_queue);
            this.Name = "Stacks";
            this.Text = "Stacks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implement_Stack_as_a_queue;
    }
}