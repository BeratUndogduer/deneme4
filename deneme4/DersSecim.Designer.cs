namespace deneme4
{
    partial class DersSecim
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
            datagrid = new DataGridView();
            ogrlabel = new Label();
            aldigidersler = new DataGridView();
            drsscmbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)datagrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aldigidersler).BeginInit();
            SuspendLayout();
            // 
            // datagrid
            // 
            datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid.Location = new Point(12, 105);
            datagrid.Name = "datagrid";
            datagrid.RowHeadersWidth = 51;
            datagrid.RowTemplate.Height = 29;
            datagrid.Size = new Size(372, 218);
            datagrid.TabIndex = 0;
            // 
            // ogrlabel
            // 
            ogrlabel.AutoSize = true;
            ogrlabel.Location = new Point(38, 23);
            ogrlabel.Name = "ogrlabel";
            ogrlabel.Size = new Size(116, 20);
            ogrlabel.TabIndex = 1;
            ogrlabel.Text = "Öğrenci Bilgileri";
            // 
            // aldigidersler
            // 
            aldigidersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            aldigidersler.Location = new Point(401, 105);
            aldigidersler.Name = "aldigidersler";
            aldigidersler.RowHeadersWidth = 51;
            aldigidersler.RowTemplate.Height = 29;
            aldigidersler.Size = new Size(372, 218);
            aldigidersler.TabIndex = 2;
            // 
            // drsscmbtn
            // 
            drsscmbtn.Location = new Point(257, 354);
            drsscmbtn.Name = "drsscmbtn";
            drsscmbtn.Size = new Size(276, 34);
            drsscmbtn.TabIndex = 3;
            drsscmbtn.Text = "Ders Seçimini Kaydet";
            drsscmbtn.UseVisualStyleBackColor = true;
            drsscmbtn.Click += drsscmbtn_Click;
            // 
            // DersSecim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(drsscmbtn);
            Controls.Add(aldigidersler);
            Controls.Add(ogrlabel);
            Controls.Add(datagrid);
            Name = "DersSecim";
            Text = "DersSecim";
            ((System.ComponentModel.ISupportInitialize)datagrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)aldigidersler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datagrid;
        private Label ogrlabel;
        private DataGridView aldigidersler;
        private Button drsscmbtn;
    }
}