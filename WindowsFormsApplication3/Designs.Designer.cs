namespace WindowsFormsApplication3
{
    partial class Designs
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
            this.btn_Implementation_of_Timer_Class = new System.Windows.Forms.Button();
            this.btn_Implementation_of_Timer_Class_Suspend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Implementation_of_Timer_Class
            // 
            this.btn_Implementation_of_Timer_Class.Location = new System.Drawing.Point(12, 12);
            this.btn_Implementation_of_Timer_Class.Name = "btn_Implementation_of_Timer_Class";
            this.btn_Implementation_of_Timer_Class.Size = new System.Drawing.Size(397, 48);
            this.btn_Implementation_of_Timer_Class.TabIndex = 0;
            this.btn_Implementation_of_Timer_Class.Text = "Implementation of Timer Class";
            this.btn_Implementation_of_Timer_Class.UseVisualStyleBackColor = true;
            this.btn_Implementation_of_Timer_Class.Click += new System.EventHandler(this.btn_Implementation_of_Timer_Class_Click);
            // 
            // btn_Implementation_of_Timer_Class_Suspend
            // 
            this.btn_Implementation_of_Timer_Class_Suspend.Location = new System.Drawing.Point(12, 66);
            this.btn_Implementation_of_Timer_Class_Suspend.Name = "btn_Implementation_of_Timer_Class_Suspend";
            this.btn_Implementation_of_Timer_Class_Suspend.Size = new System.Drawing.Size(397, 48);
            this.btn_Implementation_of_Timer_Class_Suspend.TabIndex = 1;
            this.btn_Implementation_of_Timer_Class_Suspend.Text = "Implementation of Timer Class -Suspend";
            this.btn_Implementation_of_Timer_Class_Suspend.UseVisualStyleBackColor = true;
            this.btn_Implementation_of_Timer_Class_Suspend.Click += new System.EventHandler(this.btn_Implementation_of_Timer_Class_Suspend_Click);
            // 
            // Designs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Implementation_of_Timer_Class_Suspend);
            this.Controls.Add(this.btn_Implementation_of_Timer_Class);
            this.Name = "Designs";
            this.Text = "Designs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implementation_of_Timer_Class;
        private System.Windows.Forms.Button btn_Implementation_of_Timer_Class_Suspend;
    }
}