namespace WindowsFormsApplication3
{
    partial class Arrays
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
            this.button1 = new System.Windows.Forms.Button();
            this.Remove_duplicate_element_in_array = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(409, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Merge Two sorted Arrays with out 3rd Array (no duplicate)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Remove_duplicate_element_in_array
            // 
            this.Remove_duplicate_element_in_array.Location = new System.Drawing.Point(2, 69);
            this.Remove_duplicate_element_in_array.Name = "Remove_duplicate_element_in_array";
            this.Remove_duplicate_element_in_array.Size = new System.Drawing.Size(409, 22);
            this.Remove_duplicate_element_in_array.TabIndex = 1;
            this.Remove_duplicate_element_in_array.Text = "Remove duplicate element in an sorted array";
            this.Remove_duplicate_element_in_array.UseVisualStyleBackColor = true;
            this.Remove_duplicate_element_in_array.Click += new System.EventHandler(this.Remove_duplicate_element_in_sorted_array_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(409, 22);
            this.button2.TabIndex = 2;
            this.button2.Text = "Merge Two sorted Arrays with out 3rd Array With duplicate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Merge_Two_sorted_Arrays_with_out_3rd_Array_With_duplicate);
            // 
            // Arrays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 502);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Remove_duplicate_element_in_array);
            this.Controls.Add(this.button1);
            this.Name = "Arrays";
            this.Text = "Arrays";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Remove_duplicate_element_in_array;
        private System.Windows.Forms.Button button2;
    }
}