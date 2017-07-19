namespace WindowsFormsApplication3
{
    partial class DesignPatterns
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
            this.singleton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleton
            // 
            this.singleton.Location = new System.Drawing.Point(19, 30);
            this.singleton.Name = "singleton";
            this.singleton.Size = new System.Drawing.Size(182, 35);
            this.singleton.TabIndex = 0;
            this.singleton.Text = "SingleTon";
            this.singleton.UseVisualStyleBackColor = true;
            this.singleton.Click += new System.EventHandler(this.singleton_Click);
            // 
            // DesignPatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 551);
            this.Controls.Add(this.singleton);
            this.Name = "DesignPatterns";
            this.Text = "DesignPatterns";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button singleton;
    }
}