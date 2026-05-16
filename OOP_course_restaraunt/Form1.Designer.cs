namespace OOP_course_restaraunt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            Column8 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewButtonColumn();
            Column7 = new DataGridViewButtonColumn();
            label1 = new Label();
            inputName = new TextBox();
            inputDesc = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            cancelEditBtn = new Button();
            checkBox1 = new CheckBox();
            confirmEditBtn = new Button();
            inputSell = new NumericUpDown();
            inputProd = new NumericUpDown();
            inputIngr = new TextBox();
            addDishBtn = new Button();
            inputMarkup = new NumericUpDown();
            label3 = new Label();
            button2 = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            button5 = new Button();
            button7 = new Button();
            button8 = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputSell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputProd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputMarkup).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column8, Column1, Column2, Column3, Column5, Column6, Column4, Column7 });
            dataGridView1.Location = new Point(399, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(819, 528);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column8
            // 
            Column8.HeaderText = "ID";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.FillWeight = 90F;
            Column1.HeaderText = "Название блюда";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 120F;
            Column2.HeaderText = "Описание";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 120F;
            Column3.HeaderText = "Ингредиенты";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.FillWeight = 85F;
            Column5.HeaderText = "Цена изготовления";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 85F;
            Column6.HeaderText = "Цена продажи";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "";
            Column4.Name = "Column4";
            Column4.Text = "Изменить";
            Column4.UseColumnTextForButtonValue = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "";
            Column7.Name = "Column7";
            Column7.Text = "Удалить";
            Column7.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Название";
            // 
            // inputName
            // 
            inputName.Location = new Point(15, 27);
            inputName.MaxLength = 100;
            inputName.Name = "inputName";
            inputName.Size = new Size(335, 23);
            inputName.TabIndex = 2;
            // 
            // inputDesc
            // 
            inputDesc.Location = new Point(16, 86);
            inputDesc.MaxLength = 2500;
            inputDesc.Multiline = true;
            inputDesc.Name = "inputDesc";
            inputDesc.Size = new Size(334, 127);
            inputDesc.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 68);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Описание";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cancelEditBtn);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(confirmEditBtn);
            panel1.Controls.Add(inputSell);
            panel1.Controls.Add(inputProd);
            panel1.Controls.Add(inputIngr);
            panel1.Controls.Add(addDishBtn);
            panel1.Controls.Add(inputMarkup);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(inputDesc);
            panel1.Controls.Add(inputName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 494);
            panel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(265, 366);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 18;
            label7.Text = "Наценка (%)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(144, 366);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 17;
            label6.Text = "Цена продажи";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 366);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 16;
            label4.Text = "Цена изготовления";
            // 
            // cancelEditBtn
            // 
            cancelEditBtn.Location = new Point(240, 439);
            cancelEditBtn.Name = "cancelEditBtn";
            cancelEditBtn.Size = new Size(104, 46);
            cancelEditBtn.TabIndex = 15;
            cancelEditBtn.Text = "Отменить изменения";
            cancelEditBtn.UseVisualStyleBackColor = true;
            cancelEditBtn.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(104, 415);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(151, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Использовать наценку";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // confirmEditBtn
            // 
            confirmEditBtn.Location = new Point(128, 439);
            confirmEditBtn.Name = "confirmEditBtn";
            confirmEditBtn.Size = new Size(104, 46);
            confirmEditBtn.TabIndex = 13;
            confirmEditBtn.Text = "Подтвердить изменения";
            confirmEditBtn.UseVisualStyleBackColor = true;
            confirmEditBtn.Click += button3_Click;
            // 
            // inputSell
            // 
            inputSell.DecimalPlaces = 2;
            inputSell.Location = new Point(141, 385);
            inputSell.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            inputSell.Name = "inputSell";
            inputSell.Size = new Size(94, 23);
            inputSell.TabIndex = 12;
            // 
            // inputProd
            // 
            inputProd.DecimalPlaces = 2;
            inputProd.Location = new Point(17, 385);
            inputProd.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            inputProd.Name = "inputProd";
            inputProd.Size = new Size(102, 23);
            inputProd.TabIndex = 11;
            // 
            // inputIngr
            // 
            inputIngr.Location = new Point(16, 248);
            inputIngr.Multiline = true;
            inputIngr.Name = "inputIngr";
            inputIngr.Size = new Size(334, 101);
            inputIngr.TabIndex = 10;
            // 
            // addDishBtn
            // 
            addDishBtn.Location = new Point(15, 439);
            addDishBtn.Name = "addDishBtn";
            addDishBtn.Size = new Size(103, 46);
            addDishBtn.TabIndex = 9;
            addDishBtn.Text = "Добавить блюдо";
            addDishBtn.UseVisualStyleBackColor = true;
            addDishBtn.Click += button1_Click;
            // 
            // inputMarkup
            // 
            inputMarkup.DecimalPlaces = 3;
            inputMarkup.Location = new Point(253, 385);
            inputMarkup.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            inputMarkup.Name = "inputMarkup";
            inputMarkup.Size = new Size(97, 23);
            inputMarkup.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 227);
            label3.Name = "label3";
            label3.Size = new Size(184, 15);
            label3.TabIndex = 5;
            label3.Text = "Ингредиенты (введите через \";\")";
            label3.Click += label3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(414, 12);
            button2.Name = "button2";
            button2.Size = new Size(117, 23);
            button2.TabIndex = 6;
            button2.Text = "Найти...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(697, 16);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 7;
            label5.Text = "Сортировать по ";
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Название", "Описание", "Количество ингредиентов", "Цена изготовления", "Цена продажи" });
            comboBox1.Location = new Point(801, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(193, 23);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "-";
            // 
            // button4
            // 
            button4.Location = new Point(208, 516);
            button4.Name = "button4";
            button4.Size = new Size(161, 23);
            button4.TabIndex = 10;
            button4.Text = "Очистить базу данных";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(20, 516);
            button5.Name = "button5";
            button5.Size = new Size(161, 23);
            button5.TabIndex = 11;
            button5.Text = "Сохранить базу данных";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(556, 12);
            button7.Name = "button7";
            button7.Size = new Size(117, 23);
            button7.TabIndex = 13;
            button7.Text = "Фильтр...";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(20, 545);
            button8.Name = "button8";
            button8.Size = new Size(350, 39);
            button8.TabIndex = 14;
            button8.Text = "ВЫЙТИ";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1014, 14);
            button1.Name = "button1";
            button1.Size = new Size(42, 23);
            button1.TabIndex = 15;
            button1.Text = "А-Я";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(1062, 14);
            button3.Name = "button3";
            button3.Size = new Size(37, 23);
            button3.TabIndex = 16;
            button3.Text = "Я-А";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 590);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Менеджер БД \"Меню\"";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputSell).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputProd).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputMarkup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox inputName;
        private TextBox inputDesc;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private NumericUpDown inputMarkup;
        private Button addDishBtn;
        private Button button2;
        private Label label5;
        private ComboBox comboBox1;
        private Button button4;
        private Button button5;
        private Button button7;
        private Button button8;
        private TextBox inputIngr;
        private NumericUpDown inputSell;
        private NumericUpDown inputProd;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column7;
        private Button confirmEditBtn;
        private CheckBox checkBox1;
        private Label label4;
        private Button cancelEditBtn;
        private Label label7;
        private Label label6;
        private Button button1;
        private Button button3;
    }
}
