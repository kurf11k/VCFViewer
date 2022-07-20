using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DesktopApp
{
    public partial class ChartForm : Form
    {
        List<VCF> VCFs;
        public ChartForm(List<VCF> vcfs)
        {
            InitializeComponent();

            VCFs = GetPossibleVCFs(vcfs);


            ShowPick();
            settingsButton.Visible = false;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisY.Title = "Procentuální zastoupení alternativní alely - %";
            chart.MouseWheel += chart_MouseWheel;
            chart.ChartAreas[0].AxisX.Interval= 1;
        }

        private List<VCF> GetPossibleVCFs(List<VCF> allVCFs)
        {
            string hideVCFs = "";
            List<VCF> possibleVCFs = new List<VCF>();
            foreach (var item in allVCFs)
            {

                if (item.isFormat) 
                {                 
                    possibleVCFs.Add(item);
                    vcfCheckedListBox.Items.Add(item.name);                   
                }
                else hideVCFs += item.name + "\n";
            }
            if (hideVCFs != "") MessageBox.Show("Níže uvedené soubory nelze zobrazit, jelikož neobsahuje sloupec \"FORMAT.\n" + hideVCFs, "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return possibleVCFs;
        }

        private void ShowPick()
        {
            choosingVCFsPanel.Visible = true;
            settingsButton.Visible = false;
        }


        private void ShowChart(List<VCF> vcfs)
        {          
            chart.Series.Clear();      
            int id = 1;
            int maxIndex = 0;
            foreach (var vcf in vcfs)
            {
                //chart.Series.Add(id + ". " + vcf.name);
                //chart.Series[chart.Series.Count - 1].IsValueShownAsLabel = false;
                int i = 0;
                for (var l = 0; l < vcf.variants.Count; l++)
                {
                    if (vcf.variants.Count > 1)
                        chart.Series.Add(id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")");
                    else
                        chart.Series.Add(id + ". " + vcf.name);
                    foreach (var variant in vcf.variants[l])
                    {
                   
                        bool foundedColumn = false;
                        string alt = "";
                        foreach (var c in variant.alt)
                        {
                            if (c.mark != '-') alt += c.mark;
                        }
                        string axisLabel = variant.chrom + "\n" + variant.position.ToString() + "\n" + variant.id + "\n" + variant.reference + "\n" + alt;

                        string altAD = variant.format["AD (FORMAT)"].Split(',')[1];
                        //double value = Math.Round(Double.Parse(altAD) / Double.Parse(variance.format["DP (FORMAT)"]), 10) * 100;
                        double value = Double.Parse(altAD) / Double.Parse(variant.format["DP (FORMAT)"]) * 100;

                        for (var j = 0; j < chart.Series.Count - 1; j++)
                        {
                            for (i = 0; i < chart.Series[j].Points.Count; i++)
                            {
                                if (chart.Series[j].Points[i].AxisLabel == axisLabel)
                                {
                                    i = (int)chart.Series[j].Points[i].XValue;
                                    foundedColumn = true;
                                    break;
                                }
                            }
                            if (foundedColumn) break;

                        }
                        int x;
                        if (foundedColumn)
                        {
                            x = i;
                        }
                        else
                        {
                            x = ++maxIndex;
                        }
                        if (vcf.variants.Count > 1)
                        {
                            chart.Series[id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")"].Points.AddXY(x, value);
                            chart.Series[id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")"].Points[chart.Series[id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")"].Points.Count - 1].ToolTip = value.ToString();
                            chart.Series[id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")"].Points[chart.Series[id + ". " + vcf.name + " (" + vcf.formatNames[l] + ")"].Points.Count - 1].AxisLabel = axisLabel;
                        }
                        else
                        {
                            chart.Series[id + ". " + vcf.name].Points.AddXY(x, value);
                            chart.Series[id + ". " + vcf.name].Points[chart.Series[id + ". " + vcf.name].Points.Count - 1].ToolTip = value.ToString();
                            chart.Series[id + ". " + vcf.name].Points[chart.Series[id + ". " + vcf.name].Points.Count - 1].AxisLabel = axisLabel;

                       
                        }
                    }               
                }
                id++;
            }
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
        }

        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;

            try
            {
                if (e.Delta < 0) //Zoom out
                {
                    xAxis.ScaleView.ZoomReset();                 
                }
                else if (e.Delta > 0) // Zoom in
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
 

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 3;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 3;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                }
            }
            catch { }
        }

        private void markEverythingButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < vcfCheckedListBox.Items.Count; i++)
            {
                vcfCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void unmarkButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < vcfCheckedListBox.Items.Count; i++)
            {
                vcfCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void showChartButton_Click(object sender, EventArgs e)
        {
            List<VCF> choosedVCFs = new List<VCF>();

            for (var i = 0; i < vcfCheckedListBox.Items.Count; i++)
            {               
                if (vcfCheckedListBox.GetItemChecked(i)) choosedVCFs.Add(VCFs[i]);
            }
            if (choosedVCFs.Count == 0) MessageBox.Show("Nebyl vybrán žádný soubor.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ShowChart(choosedVCFs);
                choosingVCFsPanel.Visible = false;
                settingsButton.Visible = true;
            }          
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ShowPick();
        }
    }
}
