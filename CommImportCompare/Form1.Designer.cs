namespace CommImportCompare {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnLoadA = new System.Windows.Forms.Button();
            this.btnLoadB = new System.Windows.Forms.Button();
            this.lblLoadA = new System.Windows.Forms.Label();
            this.lblLoadB = new System.Windows.Forms.Label();
            this.dgvFileA = new System.Windows.Forms.DataGridView();
            this.dgvFileB = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCompare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadA
            // 
            this.btnLoadA.Location = new System.Drawing.Point(12, 12);
            this.btnLoadA.Name = "btnLoadA";
            this.btnLoadA.Size = new System.Drawing.Size(75, 23);
            this.btnLoadA.TabIndex = 0;
            this.btnLoadA.Text = "Load File A";
            this.btnLoadA.UseVisualStyleBackColor = true;
            this.btnLoadA.Click += new System.EventHandler(this.btnLoadA_Click);
            // 
            // btnLoadB
            // 
            this.btnLoadB.Location = new System.Drawing.Point(12, 41);
            this.btnLoadB.Name = "btnLoadB";
            this.btnLoadB.Size = new System.Drawing.Size(75, 23);
            this.btnLoadB.TabIndex = 1;
            this.btnLoadB.Text = "Load File B";
            this.btnLoadB.UseVisualStyleBackColor = true;
            this.btnLoadB.Click += new System.EventHandler(this.btnLoadB_Click);
            // 
            // lblLoadA
            // 
            this.lblLoadA.AutoSize = true;
            this.lblLoadA.Location = new System.Drawing.Point(93, 17);
            this.lblLoadA.Name = "lblLoadA";
            this.lblLoadA.Size = new System.Drawing.Size(60, 13);
            this.lblLoadA.TabIndex = 2;
            this.lblLoadA.Text = "Load File A";
            // 
            // lblLoadB
            // 
            this.lblLoadB.AutoSize = true;
            this.lblLoadB.Location = new System.Drawing.Point(93, 46);
            this.lblLoadB.Name = "lblLoadB";
            this.lblLoadB.Size = new System.Drawing.Size(60, 13);
            this.lblLoadB.TabIndex = 3;
            this.lblLoadB.Text = "Load File B";
            // 
            // dgvFileA
            // 
            this.dgvFileA.AllowUserToAddRows = false;
            this.dgvFileA.AllowUserToDeleteRows = false;
            this.dgvFileA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFileA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileA.Location = new System.Drawing.Point(3, 3);
            this.dgvFileA.Name = "dgvFileA";
            this.dgvFileA.ReadOnly = true;
            this.dgvFileA.RowHeadersVisible = false;
            this.dgvFileA.Size = new System.Drawing.Size(408, 572);
            this.dgvFileA.TabIndex = 4;
            // 
            // dgvFileB
            // 
            this.dgvFileB.AllowUserToAddRows = false;
            this.dgvFileB.AllowUserToDeleteRows = false;
            this.dgvFileB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFileB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileB.Location = new System.Drawing.Point(3, 3);
            this.dgvFileB.Name = "dgvFileB";
            this.dgvFileB.ReadOnly = true;
            this.dgvFileB.RowHeadersVisible = false;
            this.dgvFileB.Size = new System.Drawing.Size(402, 572);
            this.dgvFileB.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvFileA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvFileB);
            this.splitContainer1.Size = new System.Drawing.Size(820, 582);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 6;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompare.Location = new System.Drawing.Point(15, 667);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(408, 23);
            this.btnCompare.TabIndex = 7;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 702);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblLoadB);
            this.Controls.Add(this.lblLoadA);
            this.Controls.Add(this.btnLoadB);
            this.Controls.Add(this.btnLoadA);
            this.Name = "Form1";
            this.Text = "Compare Two Commission Files";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileB)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadA;
        private System.Windows.Forms.Button btnLoadB;
        private System.Windows.Forms.Label lblLoadA;
        private System.Windows.Forms.Label lblLoadB;
        private System.Windows.Forms.DataGridView dgvFileA;
        private System.Windows.Forms.DataGridView dgvFileB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCompare;
    }
}

