namespace Stock
{
    partial class Stock
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
            this.components = new System.ComponentModel.Container();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.dgSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.labelProductCode = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerStock = new System.Windows.Forms.DateTimePicker();
            this.labelTotalProducts = new System.Windows.Forms.Label();
            this.labelTotalQuantity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.errorProviderStock = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStock)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(443, 123);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(61, 36);
            this.buttonReset.TabIndex = 20;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantity.Location = new System.Drawing.Point(461, 47);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(56, 17);
            this.labelQuantity.TabIndex = 19;
            this.labelQuantity.Text = "Quantity";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(286, 124);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 36);
            this.buttonAdd.TabIndex = 18;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(364, 124);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 36);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSno,
            this.dgProCode,
            this.dgProName,
            this.dgQuantity,
            this.dgDate,
            this.dgStatus});
            this.dataGridViewStock.Location = new System.Drawing.Point(22, 179);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(769, 259);
            this.dataGridViewStock.TabIndex = 16;
            this.dataGridViewStock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewStock_MouseDoubleClick);
            // 
            // dgSno
            // 
            this.dgSno.HeaderText = "S.No";
            this.dgSno.Name = "dgSno";
            // 
            // dgProCode
            // 
            this.dgProCode.HeaderText = "Product Code";
            this.dgProCode.Name = "dgProCode";
            // 
            // dgProName
            // 
            this.dgProName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProName.HeaderText = "Product Name";
            this.dgProName.Name = "dgProName";
            // 
            // dgQuantity
            // 
            this.dgQuantity.HeaderText = "Quantity";
            this.dgQuantity.Name = "dgQuantity";
            // 
            // dgDate
            // 
            this.dgDate.HeaderText = "Date";
            this.dgDate.Name = "dgDate";
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductName.Location = new System.Drawing.Point(310, 76);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(141, 25);
            this.textBoxProductName.TabIndex = 14;
            this.textBoxProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProductName_KeyDown);
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductCode.Location = new System.Drawing.Point(155, 76);
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(141, 25);
            this.textBoxProductCode.TabIndex = 13;
            this.textBoxProductCode.TextChanged += new System.EventHandler(this.textBoxProductCode_TextChanged);
            this.textBoxProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProductCode_KeyDown);
            this.textBoxProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProductCode_KeyPress);
            // 
            // labelProductCode
            // 
            this.labelProductCode.AutoSize = true;
            this.labelProductCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCode.Location = new System.Drawing.Point(154, 47);
            this.labelProductCode.Name = "labelProductCode";
            this.labelProductCode.Size = new System.Drawing.Size(88, 17);
            this.labelProductCode.TabIndex = 12;
            this.labelProductCode.Text = "Product Code";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(309, 47);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(92, 17);
            this.labelProductName.TabIndex = 11;
            this.labelProductName.Text = "Product Name";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantity.Location = new System.Drawing.Point(464, 76);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(141, 25);
            this.textBoxQuantity.TabIndex = 21;
            this.textBoxQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQuantity_KeyDown);
            this.textBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantity_KeyPress);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(41, 47);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(35, 17);
            this.labelDate.TabIndex = 22;
            this.labelDate.Text = "Date";
            // 
            // dateTimePickerStock
            // 
            this.dateTimePickerStock.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerStock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStock.Location = new System.Drawing.Point(44, 78);
            this.dateTimePickerStock.Name = "dateTimePickerStock";
            this.dateTimePickerStock.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerStock.TabIndex = 23;
            this.dateTimePickerStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerStock_KeyDown);
            // 
            // labelTotalProducts
            // 
            this.labelTotalProducts.AutoSize = true;
            this.labelTotalProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProducts.Location = new System.Drawing.Point(94, 461);
            this.labelTotalProducts.Name = "labelTotalProducts";
            this.labelTotalProducts.Size = new System.Drawing.Size(98, 17);
            this.labelTotalProducts.TabIndex = 24;
            this.labelTotalProducts.Text = "Total Products :";
            // 
            // labelTotalQuantity
            // 
            this.labelTotalQuantity.AutoSize = true;
            this.labelTotalQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalQuantity.Location = new System.Drawing.Point(486, 464);
            this.labelTotalQuantity.Name = "labelTotalQuantity";
            this.labelTotalQuantity.Size = new System.Drawing.Size(95, 17);
            this.labelTotalQuantity.TabIndex = 25;
            this.labelTotalQuantity.Text = "Total Quantity :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(198, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(587, 464);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 27;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(615, 46);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 17);
            this.labelStatus.TabIndex = 29;
            this.labelStatus.Text = "Status";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Active",
            "Deactive"});
            this.comboBoxStatus.Location = new System.Drawing.Point(618, 75);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(153, 25);
            this.comboBoxStatus.TabIndex = 28;
            this.comboBoxStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxStatus_KeyDown);
            // 
            // errorProviderStock
            // 
            this.errorProviderStock.ContainerControl = this;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 504);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTotalQuantity);
            this.Controls.Add(this.labelTotalProducts);
            this.Controls.Add(this.dateTimePickerStock);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.textBoxProductCode);
            this.Controls.Add(this.labelProductCode);
            this.Controls.Add(this.labelProductName);
            this.Name = "Stock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStock;
        private System.Windows.Forms.Label labelTotalProducts;
        private System.Windows.Forms.Label labelTotalQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ErrorProvider errorProviderStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
    }
}