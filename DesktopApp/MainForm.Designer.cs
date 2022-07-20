namespace DesktopApp
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.genomComboBox = new System.Windows.Forms.ComboBox();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chromComboBox = new System.Windows.Forms.ComboBox();
            this.characterPanel = new System.Windows.Forms.Panel();
            this.propertyLabel = new System.Windows.Forms.Label();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.goToPositionButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addGenomeButton = new System.Windows.Forms.Button();
            this.deleteGenomeButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.altCharacterPanel = new System.Windows.Forms.Panel();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.addVcfButton = new System.Windows.Forms.Button();
            this.removeVcfButton = new System.Windows.Forms.Button();
            this.vcfListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vcfDetailListView = new System.Windows.Forms.ListView();
            this.filterCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.showChartButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // genomComboBox
            // 
            this.genomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genomComboBox.FormattingEnabled = true;
            this.genomComboBox.Location = new System.Drawing.Point(32, 114);
            this.genomComboBox.Name = "genomComboBox";
            this.genomComboBox.Size = new System.Drawing.Size(169, 21);
            this.genomComboBox.TabIndex = 0;
            this.genomComboBox.SelectedIndexChanged += new System.EventHandler(this.genomComboBox_SelectedIndexChanged);
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(434, 114);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(109, 20);
            this.positionTextBox.TabIndex = 2;
            this.positionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.positionTextBox_KeyDown);
            this.positionTextBox.Leave += new System.EventHandler(this.positionTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Genom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(475, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pozice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(277, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chromozóm";
            // 
            // chromComboBox
            // 
            this.chromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chromComboBox.FormattingEnabled = true;
            this.chromComboBox.Location = new System.Drawing.Point(225, 114);
            this.chromComboBox.Name = "chromComboBox";
            this.chromComboBox.Size = new System.Drawing.Size(182, 21);
            this.chromComboBox.TabIndex = 1;
            this.chromComboBox.SelectedIndexChanged += new System.EventHandler(this.chromComboBox_SelectedIndexChanged);
            // 
            // characterPanel
            // 
            this.characterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.characterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.characterPanel.Location = new System.Drawing.Point(32, 210);
            this.characterPanel.Name = "characterPanel";
            this.characterPanel.Size = new System.Drawing.Size(1157, 40);
            this.characterPanel.TabIndex = 10;
            // 
            // propertyLabel
            // 
            this.propertyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyLabel.AutoSize = true;
            this.propertyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.propertyLabel.Location = new System.Drawing.Point(259, 163);
            this.propertyLabel.Name = "propertyLabel";
            this.propertyLabel.Size = new System.Drawing.Size(52, 24);
            this.propertyLabel.TabIndex = 11;
            this.propertyLabel.Text = "XXX";
            this.propertyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusButton
            // 
            this.plusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plusButton.FlatAppearance.BorderSize = 0;
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusButton.Image = ((System.Drawing.Image)(resources.GetObject("plusButton.Image")));
            this.plusButton.Location = new System.Drawing.Point(501, 159);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(36, 36);
            this.plusButton.TabIndex = 15;
            this.plusButton.TabStop = false;
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            this.plusButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.plusButton.MouseLeave += new System.EventHandler(this.HideMarking);
            // 
            // minusButton
            // 
            this.minusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minusButton.FlatAppearance.BorderSize = 0;
            this.minusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusButton.Image = ((System.Drawing.Image)(resources.GetObject("minusButton.Image")));
            this.minusButton.Location = new System.Drawing.Point(448, 157);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(36, 36);
            this.minusButton.TabIndex = 16;
            this.minusButton.TabStop = false;
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            this.minusButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.minusButton.MouseLeave += new System.EventHandler(this.HideMarking);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(58, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 37);
            this.label4.TabIndex = 17;
            this.label4.Text = "  ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(237, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "  ";
            // 
            // goToPositionButton
            // 
            this.goToPositionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToPositionButton.FlatAppearance.BorderSize = 0;
            this.goToPositionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goToPositionButton.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.goToPositionButton.Image = ((System.Drawing.Image)(resources.GetObject("goToPositionButton.Image")));
            this.goToPositionButton.Location = new System.Drawing.Point(568, 100);
            this.goToPositionButton.Name = "goToPositionButton";
            this.goToPositionButton.Size = new System.Drawing.Size(39, 43);
            this.goToPositionButton.TabIndex = 3;
            this.goToPositionButton.TabStop = false;
            this.goToPositionButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goToPositionButton.UseVisualStyleBackColor = true;
            this.goToPositionButton.Click += new System.EventHandler(this.goToPositionButton_Click);
            this.goToPositionButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.goToPositionButton.MouseLeave += new System.EventHandler(this.HideMarking);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(435, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 37);
            this.label6.TabIndex = 19;
            this.label6.Text = "  ";
            // 
            // addGenomeButton
            // 
            this.addGenomeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addGenomeButton.FlatAppearance.BorderSize = 0;
            this.addGenomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGenomeButton.Image = ((System.Drawing.Image)(resources.GetObject("addGenomeButton.Image")));
            this.addGenomeButton.Location = new System.Drawing.Point(32, 12);
            this.addGenomeButton.Name = "addGenomeButton";
            this.addGenomeButton.Size = new System.Drawing.Size(36, 36);
            this.addGenomeButton.TabIndex = 22;
            this.addGenomeButton.TabStop = false;
            this.addGenomeButton.UseVisualStyleBackColor = true;
            this.addGenomeButton.Click += new System.EventHandler(this.addGenomeButton_Click);
            this.addGenomeButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.addGenomeButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.addGenomeButton.MouseHover += new System.EventHandler(this.addGenomeButton_MouseHover);
            // 
            // deleteGenomeButton
            // 
            this.deleteGenomeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteGenomeButton.FlatAppearance.BorderSize = 0;
            this.deleteGenomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteGenomeButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteGenomeButton.Image")));
            this.deleteGenomeButton.Location = new System.Drawing.Point(72, 12);
            this.deleteGenomeButton.Name = "deleteGenomeButton";
            this.deleteGenomeButton.Size = new System.Drawing.Size(36, 36);
            this.deleteGenomeButton.TabIndex = 23;
            this.deleteGenomeButton.TabStop = false;
            this.deleteGenomeButton.UseVisualStyleBackColor = true;
            this.deleteGenomeButton.Click += new System.EventHandler(this.deleteGenomeButton_Click);
            this.deleteGenomeButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.deleteGenomeButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.deleteGenomeButton.MouseHover += new System.EventHandler(this.deleteGenomeButton_MouseHover);
            // 
            // altCharacterPanel
            // 
            this.altCharacterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.altCharacterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.altCharacterPanel.Location = new System.Drawing.Point(3, 3);
            this.altCharacterPanel.Name = "altCharacterPanel";
            this.altCharacterPanel.Size = new System.Drawing.Size(1157, 187);
            this.altCharacterPanel.TabIndex = 11;
            // 
            // rightButton
            // 
            this.rightButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightButton.FlatAppearance.BorderSize = 0;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.Location = new System.Drawing.Point(93, 157);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(36, 36);
            this.rightButton.TabIndex = 24;
            this.rightButton.TabStop = false;
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            this.rightButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.rightButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.rightButton.MouseHover += new System.EventHandler(this.rightButton_MouseHover);
            // 
            // leftButton
            // 
            this.leftButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftButton.FlatAppearance.BorderSize = 0;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.Location = new System.Drawing.Point(32, 157);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(36, 36);
            this.leftButton.TabIndex = 25;
            this.leftButton.TabStop = false;
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            this.leftButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.leftButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.leftButton.MouseHover += new System.EventHandler(this.leftButton_MouseHover);
            // 
            // addVcfButton
            // 
            this.addVcfButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addVcfButton.FlatAppearance.BorderSize = 0;
            this.addVcfButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVcfButton.Image = ((System.Drawing.Image)(resources.GetObject("addVcfButton.Image")));
            this.addVcfButton.Location = new System.Drawing.Point(553, 12);
            this.addVcfButton.Name = "addVcfButton";
            this.addVcfButton.Size = new System.Drawing.Size(36, 36);
            this.addVcfButton.TabIndex = 26;
            this.addVcfButton.TabStop = false;
            this.addVcfButton.UseVisualStyleBackColor = true;
            this.addVcfButton.Click += new System.EventHandler(this.addVcfButton_Click);
            this.addVcfButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.addVcfButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.addVcfButton.MouseHover += new System.EventHandler(this.addVcfButton_MouseHover);
            // 
            // removeVcfButton
            // 
            this.removeVcfButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeVcfButton.FlatAppearance.BorderSize = 0;
            this.removeVcfButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeVcfButton.Image = ((System.Drawing.Image)(resources.GetObject("removeVcfButton.Image")));
            this.removeVcfButton.Location = new System.Drawing.Point(595, 13);
            this.removeVcfButton.Name = "removeVcfButton";
            this.removeVcfButton.Size = new System.Drawing.Size(36, 36);
            this.removeVcfButton.TabIndex = 27;
            this.removeVcfButton.TabStop = false;
            this.removeVcfButton.UseVisualStyleBackColor = true;
            this.removeVcfButton.Click += new System.EventHandler(this.removeVcfButton_Click);
            this.removeVcfButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.removeVcfButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.removeVcfButton.MouseHover += new System.EventHandler(this.removeVcfButton_MouseHover);
            // 
            // vcfListView
            // 
            this.vcfListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vcfListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.vcfListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vcfListView.FullRowSelect = true;
            this.vcfListView.HideSelection = false;
            this.vcfListView.Location = new System.Drawing.Point(637, 12);
            this.vcfListView.Name = "vcfListView";
            this.vcfListView.Size = new System.Drawing.Size(552, 192);
            this.vcfListView.TabIndex = 28;
            this.vcfListView.UseCompatibleStateImageBehavior = false;
            this.vcfListView.View = System.Windows.Forms.View.Details;
            this.vcfListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.vcfListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "VCF soubory";
            this.columnHeader1.Width = 500;
            // 
            // vcfDetailListView
            // 
            this.vcfDetailListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vcfDetailListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vcfDetailListView.FullRowSelect = true;
            this.vcfDetailListView.HideSelection = false;
            this.vcfDetailListView.Location = new System.Drawing.Point(3, 3);
            this.vcfDetailListView.MultiSelect = false;
            this.vcfDetailListView.Name = "vcfDetailListView";
            this.vcfDetailListView.Size = new System.Drawing.Size(1157, 155);
            this.vcfDetailListView.TabIndex = 29;
            this.vcfDetailListView.UseCompatibleStateImageBehavior = false;
            this.vcfDetailListView.View = System.Windows.Forms.View.Details;
            this.vcfDetailListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.vcfDetailListView_ItemSelectionChanged);
            this.vcfDetailListView.DoubleClick += new System.EventHandler(this.vcfDetailListView_DoubleClick);
            // 
            // filterCheckedListBox
            // 
            this.filterCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterCheckedListBox.FormattingEnabled = true;
            this.filterCheckedListBox.Location = new System.Drawing.Point(825, 9);
            this.filterCheckedListBox.Name = "filterCheckedListBox";
            this.filterCheckedListBox.Size = new System.Drawing.Size(295, 139);
            this.filterCheckedListBox.TabIndex = 30;
            this.filterCheckedListBox.Visible = false;
            this.filterCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.filterCheckedListBox_SelectedIndexChanged);
            // 
            // showChartButton
            // 
            this.showChartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showChartButton.FlatAppearance.BorderSize = 0;
            this.showChartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showChartButton.Image = ((System.Drawing.Image)(resources.GetObject("showChartButton.Image")));
            this.showChartButton.Location = new System.Drawing.Point(511, 12);
            this.showChartButton.Name = "showChartButton";
            this.showChartButton.Size = new System.Drawing.Size(36, 36);
            this.showChartButton.TabIndex = 31;
            this.showChartButton.TabStop = false;
            this.showChartButton.UseVisualStyleBackColor = true;
            this.showChartButton.Click += new System.EventHandler(this.showChartButton_Click);
            this.showChartButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.showChartButton.MouseLeave += new System.EventHandler(this.HideMarking);
            this.showChartButton.MouseHover += new System.EventHandler(this.showChartButton_MouseHover);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(1126, 5);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(32, 34);
            this.settingsButton.TabIndex = 32;
            this.settingsButton.TabStop = false;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            this.settingsButton.MouseEnter += new System.EventHandler(this.ShowMarking);
            this.settingsButton.MouseLeave += new System.EventHandler(this.HideMarking);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoomLabel.Location = new System.Drawing.Point(561, 169);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(52, 24);
            this.zoomLabel.TabIndex = 33;
            this.zoomLabel.Text = "XXX";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(29, 256);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.altCharacterPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filterCheckedListBox);
            this.splitContainer1.Panel2.Controls.Add(this.settingsButton);
            this.splitContainer1.Panel2.Controls.Add(this.vcfDetailListView);
            this.splitContainer1.Size = new System.Drawing.Size(1163, 358);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 34;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 626);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.showChartButton);
            this.Controls.Add(this.removeVcfButton);
            this.Controls.Add(this.addVcfButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.deleteGenomeButton);
            this.Controls.Add(this.addGenomeButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.goToPositionButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.propertyLabel);
            this.Controls.Add(this.characterPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chromComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.genomComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vcfListView);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainForm";
            this.Text = "VCF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox genomComboBox;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox chromComboBox;
        private System.Windows.Forms.Panel characterPanel;
        private System.Windows.Forms.Label propertyLabel;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button goToPositionButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addGenomeButton;
        private System.Windows.Forms.Button deleteGenomeButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel altCharacterPanel;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button addVcfButton;
        private System.Windows.Forms.Button removeVcfButton;
        private System.Windows.Forms.ListView vcfListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView vcfDetailListView;
        private System.Windows.Forms.CheckedListBox filterCheckedListBox;
        private System.Windows.Forms.Button showChartButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

