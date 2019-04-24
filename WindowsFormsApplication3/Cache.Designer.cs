namespace WindowsFormsApplication3
{
    partial class Cache
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
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList = new System.Windows.Forms.Button();
            this.btn_Implement_Least_Frequently_Used_Cache = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList
            // 
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.Location = new System.Drawing.Point(12, 12);
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.Name = "btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList";
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.Size = new System.Drawing.Size(867, 37);
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.TabIndex = 1;
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.Text = "Implement Cache (Implemented Dictionary having value as LinkedList)  Least Recent" +
    "ly Used (LRU) cache";
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.UseVisualStyleBackColor = true;
            this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList.Click += new System.EventHandler(this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList_Click);
            // 
            // btn_Implement_Least_Frequently_Used_Cache
            // 
            this.btn_Implement_Least_Frequently_Used_Cache.Location = new System.Drawing.Point(12, 65);
            this.btn_Implement_Least_Frequently_Used_Cache.Name = "btn_Implement_Least_Frequently_Used_Cache";
            this.btn_Implement_Least_Frequently_Used_Cache.Size = new System.Drawing.Size(867, 39);
            this.btn_Implement_Least_Frequently_Used_Cache.TabIndex = 2;
            this.btn_Implement_Least_Frequently_Used_Cache.Text = "Implement Least Frequently Used Cache";
            this.btn_Implement_Least_Frequently_Used_Cache.UseVisualStyleBackColor = true;
            this.btn_Implement_Least_Frequently_Used_Cache.Click += new System.EventHandler(this.btn_Implement_Least_Frequently_Used_Cache_Click);
            // 
            // Cache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 576);
            this.Controls.Add(this.btn_Implement_Least_Frequently_Used_Cache);
            this.Controls.Add(this.btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList);
            this.Name = "Cache";
            this.Text = "Cache";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList;
        private System.Windows.Forms.Button btn_Implement_Least_Frequently_Used_Cache;
    }
}