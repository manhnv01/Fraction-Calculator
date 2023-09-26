namespace FractionCalculator
{
    partial class KQRutGon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KQRutGon));
            this.dtgvKQ = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvKQ
            // 
            this.dtgvKQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvKQ.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvKQ.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvKQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKQ.ColumnHeadersVisible = false;
            this.dtgvKQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dtgvKQ.Location = new System.Drawing.Point(13, 13);
            this.dtgvKQ.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvKQ.Name = "dtgvKQ";
            this.dtgvKQ.ReadOnly = true;
            this.dtgvKQ.RowHeadersVisible = false;
            this.dtgvKQ.RowHeadersWidth = 51;
            this.dtgvKQ.Size = new System.Drawing.Size(266, 401);
            this.dtgvKQ.TabIndex = 5;
            this.dtgvKQ.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKQ_CellDoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Kết quả";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // KQRutGon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 427);
            this.Controls.Add(this.dtgvKQ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(310, 474);
            this.Name = "KQRutGon";
            this.Text = "Kết quả";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvKQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

