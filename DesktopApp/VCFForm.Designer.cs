namespace DesktopApp
{
    partial class VCFForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VCFForm));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.choosingVCFsPanel = new System.Windows.Forms.Panel();
            this.unmarkButton = new System.Windows.Forms.Button();
            this.markEverythingButton = new System.Windows.Forms.Button();
            this.showChartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vcfCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.settingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.choosingVCFsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.BorderWidth = 2;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(32, 29);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "vcf";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1275, 523);
            this.chart.TabIndex = 0;
            // 
            // choosingVCFsPanel
            // 
            this.choosingVCFsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choosingVCFsPanel.Controls.Add(this.unmarkButton);
            this.choosingVCFsPanel.Controls.Add(this.markEverythingButton);
            this.choosingVCFsPanel.Controls.Add(this.showChartButton);
            this.choosingVCFsPanel.Controls.Add(this.label1);
            this.choosingVCFsPanel.Controls.Add(this.vcfCheckedListBox);
            this.choosingVCFsPanel.Location = new System.Drawing.Point(29, 29);
            this.choosingVCFsPanel.Name = "choosingVCFsPanel";
            this.choosingVCFsPanel.Size = new System.Drawing.Size(1278, 523);
            this.choosingVCFsPanel.TabIndex = 1;
            // 
            // unmarkButton
            // 
            this.unmarkButton.Location = new System.Drawing.Point(205, 46);
            this.unmarkButton.Name = "unmarkButton";
            this.unmarkButton.Size = new System.Drawing.Size(77, 24);
            this.unmarkButton.TabIndex = 8;
            this.unmarkButton.Text = "Zrušit vše";
            this.unmarkButton.UseVisualStyleBackColor = true;
            this.unmarkButton.Click += new System.EventHandler(this.unmarkButton_Click);
            // 
            // markEverythingButton
            // 
            this.markEverythingButton.Location = new System.Drawing.Point(288, 46);
            this.markEverythingButton.Name = "markEverythingButton";
            this.markEverythingButton.Size = new System.Drawing.Size(77, 24);
            this.markEverythingButton.TabIndex = 7;
            this.markEverythingButton.Text = "Označit vše";
            this.markEverythingButton.UseVisualStyleBackColor = true;
            this.markEverythingButton.Click += new System.EventHandler(this.markEverythingButton_Click);
            // 
            // showChartButton
            // 
            this.showChartButton.Location = new System.Drawing.Point(194, 460);
            this.showChartButton.Name = "showChartButton";
            this.showChartButton.Size = new System.Drawing.Size(171, 42);
            this.showChartButton.TabIndex = 6;
            this.showChartButton.Text = "Zobrazit graf";
            this.showChartButton.UseVisualStyleBackColor = true;
            this.showChartButton.Click += new System.EventHandler(this.showChartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vyberte VCF soubory, jež chcete zobrazit.";
            // 
            // vcfCheckedListBox
            // 
            this.vcfCheckedListBox.CheckOnClick = true;
            this.vcfCheckedListBox.FormattingEnabled = true;
            this.vcfCheckedListBox.Location = new System.Drawing.Point(22, 76);
            this.vcfCheckedListBox.Name = "vcfCheckedListBox";
            this.vcfCheckedListBox.Size = new System.Drawing.Size(343, 364);
            this.vcfCheckedListBox.TabIndex = 0;
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(1268, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(36, 36);
            this.settingsButton.TabIndex = 33;
            this.settingsButton.TabStop = false;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // VCFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 564);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.choosingVCFsPanel);
            this.Controls.Add(this.chart);
            this.Name = "VCFForm";
            this.Text = "VCF";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.choosingVCFsPanel.ResumeLayout(false);
            this.choosingVCFsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel choosingVCFsPanel;
        private System.Windows.Forms.CheckedListBox vcfCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button markEverythingButton;
        private System.Windows.Forms.Button showChartButton;
        private System.Windows.Forms.Button unmarkButton;
        private System.Windows.Forms.Button settingsButton;
    }
}