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
            this.btn_Stream_of_Characters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Implement_Trie_Prefix_Tree
            // 
            this.btn_Implement_Trie_Prefix_Tree.Location = new System.Drawing.Point(9, 10);
            this.btn_Implement_Trie_Prefix_Tree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Implement_Trie_Prefix_Tree.Name = "btn_Implement_Trie_Prefix_Tree";
            this.btn_Implement_Trie_Prefix_Tree.Size = new System.Drawing.Size(148, 24);
            this.btn_Implement_Trie_Prefix_Tree.TabIndex = 0;
            this.btn_Implement_Trie_Prefix_Tree.Text = "Implement Trie (Prefix Tree)";
            this.btn_Implement_Trie_Prefix_Tree.UseVisualStyleBackColor = true;
            this.btn_Implement_Trie_Prefix_Tree.Click += new System.EventHandler(this.btn_Implement_Trie_Prefix_Tree_Click);
            // 
            // btn_Stream_of_Characters
            // 
            this.btn_Stream_of_Characters.Location = new System.Drawing.Point(9, 39);
            this.btn_Stream_of_Characters.Name = "btn_Stream_of_Characters";
            this.btn_Stream_of_Characters.Size = new System.Drawing.Size(148, 32);
            this.btn_Stream_of_Characters.TabIndex = 1;
            this.btn_Stream_of_Characters.Text = "Stream of Characters";
            this.btn_Stream_of_Characters.UseVisualStyleBackColor = true;
            this.btn_Stream_of_Characters.Click += new System.EventHandler(this.btn_Stream_of_Characters_Click);
            // 
            // Tries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_Stream_of_Characters);
            this.Controls.Add(this.btn_Implement_Trie_Prefix_Tree);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Tries";
            this.Text = "Trie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implement_Trie_Prefix_Tree;
        private System.Windows.Forms.Button btn_Stream_of_Characters;
    }
}