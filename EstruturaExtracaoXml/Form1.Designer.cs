namespace EstruturaExtracaoXml
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dataGridExtracao = new DataGridView();
            label3 = new Label();
            buttonExtract = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridExtracao).BeginInit();
            SuspendLayout();
            // 
            // dataGridExtracao
            // 
            dataGridExtracao.AllowUserToAddRows = false;
            dataGridExtracao.AllowUserToDeleteRows = false;
            dataGridExtracao.AllowUserToResizeColumns = false;
            dataGridExtracao.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridExtracao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridExtracao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridExtracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridExtracao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridExtracao.BackgroundColor = SystemColors.Control;
            dataGridExtracao.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridExtracao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridExtracao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridExtracao.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridExtracao.Location = new Point(15, 124);
            dataGridExtracao.Margin = new Padding(4, 4, 4, 4);
            dataGridExtracao.MultiSelect = false;
            dataGridExtracao.Name = "dataGridExtracao";
            dataGridExtracao.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridExtracao.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridExtracao.RowHeadersVisible = false;
            dataGridExtracao.RowHeadersWidth = 51;
            dataGridExtracao.RowTemplate.Height = 29;
            dataGridExtracao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridExtracao.Size = new Size(1426, 684);
            dataGridExtracao.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(15, 89);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(185, 29);
            label3.TabIndex = 31;
            label3.Text = "Relação de Xml";
            // 
            // buttonExtract
            // 
            buttonExtract.AutoSize = true;
            buttonExtract.Cursor = Cursors.Hand;
            buttonExtract.FlatAppearance.BorderSize = 2;
            buttonExtract.FlatStyle = FlatStyle.Flat;
            buttonExtract.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExtract.ImeMode = ImeMode.NoControl;
            buttonExtract.Location = new Point(1460, 124);
            buttonExtract.Margin = new Padding(4, 5, 4, 5);
            buttonExtract.MinimumSize = new Size(71, 0);
            buttonExtract.Name = "buttonExtract";
            buttonExtract.Size = new Size(252, 42);
            buttonExtract.TabIndex = 32;
            buttonExtract.Text = "Iniciar Extração";
            buttonExtract.UseVisualStyleBackColor = true;
            buttonExtract.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1802, 854);
            Controls.Add(buttonExtract);
            Controls.Add(label3);
            Controls.Add(dataGridExtracao);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridExtracao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridExtracao;
        private Label label3;
        private Button buttonExtract;
    }
}
