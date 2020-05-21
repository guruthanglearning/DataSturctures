namespace WindowsFormsApplication3
{
    partial class Tries
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
            this.btn_Implement_Trie_Prefix_Tree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Implement_Trie_Prefix_Tree
            // 
            this.btn_Implement_Trie_Prefix_Tree.Location = new System.Drawing.Point(12, 12);
            this.btn_Implement_Trie_Prefix_Tree.Name = "btn_Implement_Trie_Prefix_Tree";
            this.btn_Implement_Trie_Prefix_Tree.Size = new System.Drawing.Size(197, 30);
            this.btn_Implement_Trie_Prefix_Tree.TabIndex = 0;
            this.btn_Implement_Trie_Prefix_Tree.Text = "Implement Trie (Prefix Tree)";
            this.btn_Implement_Trie_Prefix_Tree.UseVisualStyleBackColor = true;
            this.btn_Implement_Trie_Prefix_Tree.Click += new System.EventHandler(this.btn_Implement_Trie_Prefix_Tree_Click);
            // 
            // Trie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Implement_Trie_Prefix_Tree);
            this.Name = "Trie";
            this.Text = "Trie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implement_Trie_Prefix_Tree;
    }
}