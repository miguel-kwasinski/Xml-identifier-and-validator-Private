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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridExtracao = new DataGridView();
            label3 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridExtracao).BeginInit();
            SuspendLayout();
            // 
            // dataGridExtracao
            // 
            dataGridExtracao.AllowUserToAddRows = false;
            dataGridExtracao.AllowUserToDeleteRows = false;
            dataGridExtracao.AllowUserToResizeColumns = false;
            dataGridExtracao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridExtracao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridExtracao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridExtracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridExtracao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridExtracao.BackgroundColor = SystemColors.Control;
            dataGridExtracao.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridExtracao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridExtracao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridExtracao.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridExtracao.Location = new Point(12, 99);
            dataGridExtracao.MultiSelect = false;
            dataGridExtracao.Name = "dataGridExtracao";
            dataGridExtracao.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridExtracao.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridExtracao.RowHeadersVisible = false;
            dataGridExtracao.RowHeadersWidth = 51;
            dataGridExtracao.RowTemplate.Height = 29;
            dataGridExtracao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridExtracao.Size = new Size(1141, 547);
            dataGridExtracao.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 31;
            label3.Text = "Relação de Xml";
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ImeMode = ImeMode.NoControl;
            button3.Location = new Point(1168, 99);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.MinimumSize = new Size(57, 0);
            button3.Name = "button3";
            button3.Size = new Size(202, 34);
            button3.TabIndex = 32;
            button3.Text = "Iniciar Extração";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1442, 683);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(dataGridExtracao);
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
        private Button button3;
    }
}
