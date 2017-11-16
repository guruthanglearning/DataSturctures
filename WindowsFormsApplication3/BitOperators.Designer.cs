namespace WindowsFormsApplication3
{
    partial class BitOperators
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
            this.btnCompute_XOR_for_the_given_number = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompute_XOR_for_the_given_number
            // 
            this.btnCompute_XOR_for_the_given_number.Location = new System.Drawing.Point(12, 12);
            this.btnCompute_XOR_for_the_given_number.Name = "btnCompute_XOR_for_the_given_number";
            this.btnCompute_XOR_for_the_given_number.Size = new System.Drawing.Size(393, 42);
            this.btnCompute_XOR_for_the_given_number.TabIndex = 0;
            this.btnCompute_XOR_for_the_given_number.Text = "Compute XOR for the given number";
            this.btnCompute_XOR_for_the_given_number.UseVisualStyleBackColor = true;
            this.btnCompute_XOR_for_the_given_number.Click += new System.EventHandler(this.btnCompute_XOR_for_the_given_number_Click);
            // 
            // BitOperators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 500);
            this.Controls.Add(this.btnCompute_XOR_for_the_given_number);
            this.Name = "BitOperators";
            this.Text = "BitOperators";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCompute_XOR_for_the_given_number;
    }
}