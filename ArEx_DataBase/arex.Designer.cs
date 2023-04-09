namespace ArEx_DataBase
{
    partial class arex
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
            System.Windows.Forms.Label arrival_IDLabel;
            System.Windows.Forms.Label stock_IDLabel;
            System.Windows.Forms.Label ar_material_suppliesLabel;
            System.Windows.Forms.Label ar_dateLabel;
            System.Windows.Forms.Label ar_number_vehicleLabel;
            System.Windows.Forms.Label ar_number_consignmentLabel;
            System.Windows.Forms.Label ar_name_providerLabel;
            System.Windows.Forms.Label ar_tonnageLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(arex));
            this.arExDbDataSet = new ArEx_DataBase.ArExDbDataSet();
            this.arrivalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.arrivalTableAdapter = new ArEx_DataBase.ArExDbDataSetTableAdapters.ArrivalTableAdapter();
            this.tableAdapterManager = new ArEx_DataBase.ArExDbDataSetTableAdapters.TableAdapterManager();
            this.arrivalBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.arrivalBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.arrivalDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrival_IDTextBox = new System.Windows.Forms.TextBox();
            this.stock_IDTextBox = new System.Windows.Forms.TextBox();
            this.ar_material_suppliesTextBox = new System.Windows.Forms.TextBox();
            this.ar_dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ar_number_vehicleTextBox = new System.Windows.Forms.TextBox();
            this.ar_number_consignmentTextBox = new System.Windows.Forms.TextBox();
            this.ar_name_providerTextBox = new System.Windows.Forms.TextBox();
            this.ar_tonnageTextBox = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            arrival_IDLabel = new System.Windows.Forms.Label();
            stock_IDLabel = new System.Windows.Forms.Label();
            ar_material_suppliesLabel = new System.Windows.Forms.Label();
            ar_dateLabel = new System.Windows.Forms.Label();
            ar_number_vehicleLabel = new System.Windows.Forms.Label();
            ar_number_consignmentLabel = new System.Windows.Forms.Label();
            ar_name_providerLabel = new System.Windows.Forms.Label();
            ar_tonnageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.arExDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalBindingNavigator)).BeginInit();
            this.arrivalBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // arrival_IDLabel
            // 
            arrival_IDLabel.AutoSize = true;
            arrival_IDLabel.Location = new System.Drawing.Point(30, 290);
            arrival_IDLabel.Name = "arrival_IDLabel";
            arrival_IDLabel.Size = new System.Drawing.Size(64, 16);
            arrival_IDLabel.TabIndex = 2;
            arrival_IDLabel.Text = "Arrival ID:";
            // 
            // stock_IDLabel
            // 
            stock_IDLabel.AutoSize = true;
            stock_IDLabel.Location = new System.Drawing.Point(30, 318);
            stock_IDLabel.Name = "stock_IDLabel";
            stock_IDLabel.Size = new System.Drawing.Size(60, 16);
            stock_IDLabel.TabIndex = 4;
            stock_IDLabel.Text = "Stock ID:";
            // 
            // ar_material_suppliesLabel
            // 
            ar_material_suppliesLabel.AutoSize = true;
            ar_material_suppliesLabel.Location = new System.Drawing.Point(30, 346);
            ar_material_suppliesLabel.Name = "ar_material_suppliesLabel";
            ar_material_suppliesLabel.Size = new System.Drawing.Size(128, 16);
            ar_material_suppliesLabel.TabIndex = 6;
            ar_material_suppliesLabel.Text = "Ar material supplies:";
            // 
            // ar_dateLabel
            // 
            ar_dateLabel.AutoSize = true;
            ar_dateLabel.Location = new System.Drawing.Point(30, 375);
            ar_dateLabel.Name = "ar_dateLabel";
            ar_dateLabel.Size = new System.Drawing.Size(53, 16);
            ar_dateLabel.TabIndex = 8;
            ar_dateLabel.Text = "Ar date:";
            // 
            // ar_number_vehicleLabel
            // 
            ar_number_vehicleLabel.AutoSize = true;
            ar_number_vehicleLabel.Location = new System.Drawing.Point(30, 402);
            ar_number_vehicleLabel.Name = "ar_number_vehicleLabel";
            ar_number_vehicleLabel.Size = new System.Drawing.Size(117, 16);
            ar_number_vehicleLabel.TabIndex = 10;
            ar_number_vehicleLabel.Text = "Ar number vehicle:";
            // 
            // ar_number_consignmentLabel
            // 
            ar_number_consignmentLabel.AutoSize = true;
            ar_number_consignmentLabel.Location = new System.Drawing.Point(30, 430);
            ar_number_consignmentLabel.Name = "ar_number_consignmentLabel";
            ar_number_consignmentLabel.Size = new System.Drawing.Size(150, 16);
            ar_number_consignmentLabel.TabIndex = 12;
            ar_number_consignmentLabel.Text = "Ar number consignment:";
            // 
            // ar_name_providerLabel
            // 
            ar_name_providerLabel.AutoSize = true;
            ar_name_providerLabel.Location = new System.Drawing.Point(30, 458);
            ar_name_providerLabel.Name = "ar_name_providerLabel";
            ar_name_providerLabel.Size = new System.Drawing.Size(113, 16);
            ar_name_providerLabel.TabIndex = 14;
            ar_name_providerLabel.Text = "Ar name provider:";
            // 
            // ar_tonnageLabel
            // 
            ar_tonnageLabel.AutoSize = true;
            ar_tonnageLabel.Location = new System.Drawing.Point(30, 486);
            ar_tonnageLabel.Name = "ar_tonnageLabel";
            ar_tonnageLabel.Size = new System.Drawing.Size(75, 16);
            ar_tonnageLabel.TabIndex = 16;
            ar_tonnageLabel.Text = "Ar tonnage:";
            // 
            // arExDbDataSet
            // 
            this.arExDbDataSet.DataSetName = "ArExDbDataSet";
            this.arExDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // arrivalBindingSource
            // 
            this.arrivalBindingSource.DataMember = "Arrival";
            this.arrivalBindingSource.DataSource = this.arExDbDataSet;
            // 
            // arrivalTableAdapter
            // 
            this.arrivalTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArrivalTableAdapter = this.arrivalTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ExpenseTableAdapter = null;
            this.tableAdapterManager.Recipe_ExpenseTableAdapter = null;
            this.tableAdapterManager.RecipeTableAdapter = null;
            this.tableAdapterManager.registerTableAdapter = null;
            this.tableAdapterManager.StockTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ArEx_DataBase.ArExDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // arrivalBindingNavigator
            // 
            this.arrivalBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.arrivalBindingNavigator.BindingSource = this.arrivalBindingSource;
            this.arrivalBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.arrivalBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.arrivalBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.arrivalBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.arrivalBindingNavigatorSaveItem});
            this.arrivalBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.arrivalBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.arrivalBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.arrivalBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.arrivalBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.arrivalBindingNavigator.Name = "arrivalBindingNavigator";
            this.arrivalBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.arrivalBindingNavigator.Size = new System.Drawing.Size(820, 27);
            this.arrivalBindingNavigator.TabIndex = 0;
            this.arrivalBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // arrivalBindingNavigatorSaveItem
            // 
            this.arrivalBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arrivalBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("arrivalBindingNavigatorSaveItem.Image")));
            this.arrivalBindingNavigatorSaveItem.Name = "arrivalBindingNavigatorSaveItem";
            this.arrivalBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.arrivalBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.arrivalBindingNavigatorSaveItem.Click += new System.EventHandler(this.arrivalBindingNavigatorSaveItem_Click);
            // 
            // arrivalDataGridView
            // 
            this.arrivalDataGridView.AllowUserToAddRows = false;
            this.arrivalDataGridView.AllowUserToDeleteRows = false;
            this.arrivalDataGridView.AutoGenerateColumns = false;
            this.arrivalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.arrivalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.arrivalDataGridView.DataSource = this.arrivalBindingSource;
            this.arrivalDataGridView.Location = new System.Drawing.Point(0, 30);
            this.arrivalDataGridView.Name = "arrivalDataGridView";
            this.arrivalDataGridView.ReadOnly = true;
            this.arrivalDataGridView.RowHeadersWidth = 51;
            this.arrivalDataGridView.RowTemplate.Height = 24;
            this.arrivalDataGridView.Size = new System.Drawing.Size(820, 247);
            this.arrivalDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Arrival_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Arrival_ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Stock_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Stock_ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ar_material_supplies";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ar_material_supplies";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Ar_date";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ar_date";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ar_number_vehicle";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ar_number_vehicle";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ar_number_consignment";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ar_number_consignment";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Ar_name_provider";
            this.dataGridViewTextBoxColumn7.HeaderText = "Ar_name_provider";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Ar_tonnage";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ar_tonnage";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // arrival_IDTextBox
            // 
            this.arrival_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Arrival_ID", true));
            this.arrival_IDTextBox.Location = new System.Drawing.Point(186, 287);
            this.arrival_IDTextBox.Name = "arrival_IDTextBox";
            this.arrival_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.arrival_IDTextBox.TabIndex = 3;
            // 
            // stock_IDTextBox
            // 
            this.stock_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Stock_ID", true));
            this.stock_IDTextBox.Location = new System.Drawing.Point(186, 315);
            this.stock_IDTextBox.Name = "stock_IDTextBox";
            this.stock_IDTextBox.Size = new System.Drawing.Size(200, 22);
            this.stock_IDTextBox.TabIndex = 5;
            // 
            // ar_material_suppliesTextBox
            // 
            this.ar_material_suppliesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Ar_material_supplies", true));
            this.ar_material_suppliesTextBox.Location = new System.Drawing.Point(186, 343);
            this.ar_material_suppliesTextBox.Name = "ar_material_suppliesTextBox";
            this.ar_material_suppliesTextBox.Size = new System.Drawing.Size(200, 22);
            this.ar_material_suppliesTextBox.TabIndex = 7;
            // 
            // ar_dateDateTimePicker
            // 
            this.ar_dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.arrivalBindingSource, "Ar_date", true));
            this.ar_dateDateTimePicker.Location = new System.Drawing.Point(186, 371);
            this.ar_dateDateTimePicker.Name = "ar_dateDateTimePicker";
            this.ar_dateDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.ar_dateDateTimePicker.TabIndex = 9;
            // 
            // ar_number_vehicleTextBox
            // 
            this.ar_number_vehicleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Ar_number_vehicle", true));
            this.ar_number_vehicleTextBox.Location = new System.Drawing.Point(186, 399);
            this.ar_number_vehicleTextBox.Name = "ar_number_vehicleTextBox";
            this.ar_number_vehicleTextBox.Size = new System.Drawing.Size(200, 22);
            this.ar_number_vehicleTextBox.TabIndex = 11;
            // 
            // ar_number_consignmentTextBox
            // 
            this.ar_number_consignmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Ar_number_consignment", true));
            this.ar_number_consignmentTextBox.Location = new System.Drawing.Point(186, 427);
            this.ar_number_consignmentTextBox.Name = "ar_number_consignmentTextBox";
            this.ar_number_consignmentTextBox.Size = new System.Drawing.Size(200, 22);
            this.ar_number_consignmentTextBox.TabIndex = 13;
            // 
            // ar_name_providerTextBox
            // 
            this.ar_name_providerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Ar_name_provider", true));
            this.ar_name_providerTextBox.Location = new System.Drawing.Point(186, 455);
            this.ar_name_providerTextBox.Name = "ar_name_providerTextBox";
            this.ar_name_providerTextBox.Size = new System.Drawing.Size(200, 22);
            this.ar_name_providerTextBox.TabIndex = 15;
            // 
            // ar_tonnageTextBox
            // 
            this.ar_tonnageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrivalBindingSource, "Ar_tonnage", true));
            this.ar_tonnageTextBox.Location = new System.Drawing.Point(186, 483);
            this.ar_tonnageTextBox.Name = "ar_tonnageTextBox";
            this.ar_tonnageTextBox.Size = new System.Drawing.Size(200, 22);
            this.ar_tonnageTextBox.TabIndex = 17;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightBlue;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.Location = new System.Drawing.Point(606, 354);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 44);
            this.button9.TabIndex = 21;
            this.button9.Text = "Сохранить";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightBlue;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button11.Location = new System.Drawing.Point(606, 416);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(139, 44);
            this.button11.TabIndex = 19;
            this.button11.Text = "Удалить";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.LightBlue;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.Location = new System.Drawing.Point(606, 304);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(139, 44);
            this.button12.TabIndex = 18;
            this.button12.Text = "Новая запись";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // arex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 611);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(arrival_IDLabel);
            this.Controls.Add(this.arrival_IDTextBox);
            this.Controls.Add(stock_IDLabel);
            this.Controls.Add(this.stock_IDTextBox);
            this.Controls.Add(ar_material_suppliesLabel);
            this.Controls.Add(this.ar_material_suppliesTextBox);
            this.Controls.Add(ar_dateLabel);
            this.Controls.Add(this.ar_dateDateTimePicker);
            this.Controls.Add(ar_number_vehicleLabel);
            this.Controls.Add(this.ar_number_vehicleTextBox);
            this.Controls.Add(ar_number_consignmentLabel);
            this.Controls.Add(this.ar_number_consignmentTextBox);
            this.Controls.Add(ar_name_providerLabel);
            this.Controls.Add(this.ar_name_providerTextBox);
            this.Controls.Add(ar_tonnageLabel);
            this.Controls.Add(this.ar_tonnageTextBox);
            this.Controls.Add(this.arrivalDataGridView);
            this.Controls.Add(this.arrivalBindingNavigator);
            this.Name = "arex";
            this.Text = "arex";
            this.Load += new System.EventHandler(this.arex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.arExDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalBindingNavigator)).EndInit();
            this.arrivalBindingNavigator.ResumeLayout(false);
            this.arrivalBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ArExDbDataSet arExDbDataSet;
        private System.Windows.Forms.BindingSource arrivalBindingSource;
        private ArExDbDataSetTableAdapters.ArrivalTableAdapter arrivalTableAdapter;
        private ArExDbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator arrivalBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton arrivalBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView arrivalDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox arrival_IDTextBox;
        private System.Windows.Forms.TextBox stock_IDTextBox;
        private System.Windows.Forms.TextBox ar_material_suppliesTextBox;
        private System.Windows.Forms.DateTimePicker ar_dateDateTimePicker;
        private System.Windows.Forms.TextBox ar_number_vehicleTextBox;
        private System.Windows.Forms.TextBox ar_number_consignmentTextBox;
        private System.Windows.Forms.TextBox ar_name_providerTextBox;
        private System.Windows.Forms.TextBox ar_tonnageTextBox;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}