using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management.Instrumentation;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {

        private static int endSpaceWidth = 6;
        private static int minimumSpaceWidth = 0;
        private static int maximumSpaceWidth = 100;
        private static int shiftSpace = 5;
        private static int spaceWidth = 10;
        private static int labelWidth = 22;


        bool isLoaded = false;

        List<Genom> genoms;
        VCF choosedVCF;
        Variant choosedVariance;

        bool settingClicked = false;
        public MainForm()
        {
            InitializeComponent();
            try { genoms = Gateway.LoadGenoms(); }
            catch(Exception e) 
            {
                Gateway.DeleteData();
                MessageBox.Show("Vyskytla se chyba při načítání uložených genomů. Uložené data budou odstraněny. Spusťte aplikaci znova.","Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vcfListView.Columns[0].Width = vcfListView.Width - 5;
            altCharacterPanel.HorizontalScroll.Maximum = 0;
            altCharacterPanel.AutoScroll = false;
            altCharacterPanel.VerticalScroll.Visible = false;
            altCharacterPanel.AutoScroll = true;

            UpdateGenoms();      
            UpdateVCFListView();
            HideAllColumns();
            filterCheckedListBox.CheckOnClick = true;

            zoomLabel.Text = spaceWidth.ToString() + " %";
            propertyLabel.Text = "";
            if (genomComboBox.Items.Count > 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0)
            {
                positionTextBox.Text = "1";
                ShowBases();
            }
            isLoaded = true;
        }

        private void HideAllColumns()
        {
            for (var i = 7; i < vcfDetailListView.Columns.Count; i++)
            {
                vcfDetailListView.Columns[i].Width = 0;
            }
        }
        private void UpdateGenoms()
        {
            genomComboBox.DataSource = null;
            genomComboBox.DataSource = genoms;
            genomComboBox.ValueMember = "pathToFile";
            genomComboBox.DisplayMember = "name";
            vcfDetailListView.Items.Clear();
            choosedVCF = null;
        }
        private void UpdateChromosomes()
        {
            chromComboBox.DataSource = null;
            int selectedIndex;

            if (genomComboBox.SelectedIndex > -1) selectedIndex = genomComboBox.SelectedIndex;
            else selectedIndex = 0;


            if (genoms.Count > 0 && genoms[selectedIndex].chromosomes.Count > 0)
            {
                chromComboBox.DataSource = genoms[selectedIndex].chromosomes;
                chromComboBox.ValueMember = "name";
                chromComboBox.DisplayMember = "name";
            }
        }
        private void UpdateVCFListView()
        {
            vcfListView.Items.Clear();
            vcfDetailListView.Items.Clear();
            settingsButton.Visible = false;
            choosedVCF = null;
            if (genomComboBox.SelectedIndex >= 0)
            {               
                foreach (var vcf in genoms[genomComboBox.SelectedIndex].vcfs)
                {
                    var item = new ListViewItem(vcf.name);
                    item.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
                    vcfListView.Items.Add(item);
                }
                vcfListView.Update();
            }
        }

        private void genomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChromosomes();
            UpdateVCFListView();
        }
        private Label CreateBaseLabel(int x, int y, Base c)
        {
            var label = new Label();
            label.Name = c.position.ToString();
            if (c.addedPosition > 0) label.Name += " + " + c.addedPosition;
            //label.BorderStyle = BorderStyle.FixedSingle;
            label.Text = c.mark.ToString();
            label.Location = new Point(x, y);
            label.AutoSize = false;
            label.MinimumSize = new Size(labelWidth, 30);
            label.MaximumSize = new Size(labelWidth, 30);          
            label.UseCompatibleTextRendering = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.ForeColor = c.color;
            label.Font = new Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label.MouseLeave += new EventHandler(HideDescription);
            label.MouseEnter += new EventHandler(ShowDescription);
            return label;
        }
        private void ShowBases()
        {
            if (genomComboBox.Items.Count == 0) MessageBox.Show("K dispozici není žádný genom, nejprve prosím přidejte genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (genomComboBox.SelectedIndex < 0) MessageBox.Show("Nebyl vybrán žádný genom, prosím nejdříve vyberte z nabídky genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                Genom genom;
                genom = genoms[genomComboBox.SelectedIndex];

                Chromosome chrom;
                chrom = genom.chromosomes[chromComboBox.SelectedIndex];

                long position;
                try
                {
                    position = Int64.Parse(positionTextBox.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Zadaná pozice není korektní\n\n" + e.ToString(), "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!chrom.PositionCorrect(position)) MessageBox.Show("Zadaná pozice je mimo rozsah", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    characterPanel.Controls.Clear();
                    altCharacterPanel.Controls.Clear();

                    /*double _countChars = (characterPanel.Width + spaceWidth) / (labelWidth + spaceWidth);
                    _countChars = Math.Round(_countChars, MidpointRounding.AwayFromZero);*/

                    int countChars = characterPanel.Width / (labelWidth + spaceWidth);

                    if (countChars % 2 == 0) countChars++;
                    countChars += 2;
                            
                    int countCharsForEachSide = (countChars - 1) / 2;                              

                    List<Base> bases = genom.GetBases(chrom, position, countCharsForEachSide);

                    int x;
                    if(position - countCharsForEachSide <= 0)
                    {
                        x = endSpaceWidth;
                    }
                    else if(position + countCharsForEachSide > chrom.length)
                    {
                        x = characterPanel.Width - ((bases.Count * labelWidth) + ((bases.Count - 1) * spaceWidth) + endSpaceWidth);
                    }
                    else
                    {
                        int middle = (characterPanel.Width / 2) - (labelWidth / 2);
                        x = middle - ((labelWidth + spaceWidth) * countCharsForEachSide);
                    }
            
               

                    List<List<Base>> variants = GetVariantsForShowing(genom.vcfs, bases, chrom);
                    bases = CropBases(bases, position, countCharsForEachSide, chrom);


                    // zobrazení genomu
                    List<Label> labelBases = new List<Label>();
                    int tempX = x;
                    foreach (var c in bases)
                    {
                        labelBases.Add(CreateBaseLabel(tempX, 5, c));
                        tempX += labelWidth + spaceWidth;
                    }


                    // zobrazeni variant

                    List<Label> labelVariants = new List<Label>();
                    int y = 0;
                    foreach (var variant in variants)
                    {
                        bool isShowed = false;
                        int lastIndex = 0;
                        foreach (var vBase in variant)
                        {
                            if (vBase.mark != '*')
                            {
                                for (var i = lastIndex; i < bases.Count; i++)
                                {
                                    var gBase = bases[i];
                                    if (gBase.position == vBase.position && gBase.addedPosition == vBase.addedPosition)
                                    {
                                        labelVariants.Add(CreateBaseLabel(labelBases[i].Location.X, y, vBase));
                                        lastIndex = ++i;
                                        isShowed = true;
                                        break;
                                    }

                                }
                            }
                            
                            else
                            {
                                var fileName = new Label();
                                fileName.Text = vBase.note;
                                fileName.Font = new Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                fileName.AutoSize = true;

                                altCharacterPanel.Controls.Add(fileName);
                                y += 10;
                                isShowed = true;
                                fileName.Location = new Point((altCharacterPanel.Width / 2) - (fileName.Width / 2), y);
                            }                           
                        }
                        if(isShowed)
                            y += 30;
                    }

                    characterPanel.Controls.AddRange(labelBases.ToArray());
                    altCharacterPanel.Controls.AddRange(labelVariants.ToArray());
                 
                }
            }
        }
        private List<List<Base>> GetVariantsForShowing(List<VCF> vcfs, List<Base> bases, Chromosome chrom)
        {
            
            List<List<Base>> variants = new List<List<Base>>();
            foreach (var vcf in vcfs)
            {
                variants.Add(new List<Base>());
                variants[variants.Count - 1].Add(new Base('*', null));
                variants[variants.Count - 1][variants[variants.Count - 1].Count - 1].note = vcf.name;
                foreach (var variant in vcf.variants[0])
                {
                    variants.Add(new List<Base>());
                    if (variant.chrom == chrom.name)
                    {
                        List<Base> copyAlt = new List<Base>();
                        foreach (var copyChar in variant.alt)
                        {
                            copyAlt.Add(new Base(copyChar.mark, copyChar.position));
                            copyAlt[copyAlt.Count - 1].addedPosition = copyChar.addedPosition;
                        }

                        int lastIndex = 0;
                        for (var i = 0; i < bases.Count; i++)
                        {
                            var character = bases[i];

                            for (var j = lastIndex; j < copyAlt.Count; j++)
                            {
                                //var alt = variant.alt[j]; 
                                var alt = copyAlt[j];

                                if (alt.position == character.position && alt.addedPosition == character.addedPosition)
                                {
                                    variants[variants.Count - 1].Add(alt);
                                    copyAlt.RemoveAt(j);
                                    lastIndex = j;
                                    if (alt.position == chrom.length && bases.Count == i + 1 && copyAlt.Count > 0)
                                    {
                                        AddGenomBases(bases, copyAlt[j].addedPosition);
                                    }     
                                    break;
                                }
                                else if ((alt.position + 1 == character.position && alt.addedPosition > 0))
                                {
                                    ShiftGenomBases(i, bases, alt.addedPosition);
                                    i++;
                                    variants[variants.Count - 1].Add(alt);
                                    copyAlt.RemoveAt(j);
                                    j--;
                                }

                            }
                        }
                        
                    }
                }
            }
            return variants;
        }

        private List<Base> CropBases(List<Base> bases, long position, int countCharsForEachSide, Chromosome chrom)
        {
            int i;
            List<Base> croppedBases = new List<Base>();
            for (i = 0; i < bases.Count; i++)
            {
                if (bases[i].position == position)
                {
                    break;
                }
            }

            int startIndex, endIndex = 0;
            if (i - countCharsForEachSide < 0)
            {
                startIndex = 0;
                endIndex = -(i - countCharsForEachSide);
            }
            else startIndex = i - countCharsForEachSide;

            if (i + countCharsForEachSide >= bases.Count)
            {
                endIndex = bases.Count - 1;
                startIndex += endIndex - countCharsForEachSide - i;
            }
            else endIndex += i + countCharsForEachSide;


            for (int j = startIndex; j <= endIndex; j++)
            {
                
                croppedBases.Add(bases[j]);
            }
            return croppedBases;
        }  

        private void ShiftGenomBases(int index, List<Base> bases, int addedPosition)
        {
            Base b = new Base('+', bases[index].position - 1);
            b.addedPosition = addedPosition;
            bases.Insert(index, b);
        }

        private void AddGenomBases(List<Base> bases, int addedPosition)
        {
            Base b = new Base('+', bases[bases.Count - 1].position);
            b.addedPosition = addedPosition;
            bases.Add(b);
        }

        private void ShowDescription(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Wheat;
            propertyLabel.Text = label.Name;
        }
        private void HideDescription(object sender, EventArgs e)
        {
            propertyLabel.Text = "";
            Label label = (Label)sender;
            label.BackColor = Color.Empty;
        }
        private void positionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ShowBases();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (spaceWidth < maximumSpaceWidth)
            {
                spaceWidth += shiftSpace;
                zoomLabel.Text = spaceWidth.ToString() + " %";
                if (genomComboBox.Items.Count > 0 && genomComboBox.SelectedIndex >= 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0 && chromComboBox.SelectedIndex >= 0)
                {
                    ShowBases();
                }
            }

        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            if (spaceWidth > minimumSpaceWidth)
            {
                spaceWidth -= shiftSpace;
                zoomLabel.Text = spaceWidth.ToString() + " %";
                if (genomComboBox.Items.Count > 0 && genomComboBox.SelectedIndex >= 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0 && chromComboBox.SelectedIndex >= 0)
                {
                    ShowBases();
                }
            }
        }

        private void ShowMarking(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.BackColor = Color.Beige;
            button.FlatAppearance.BorderSize = 1;
        }
        private void HideMarking(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.BackColor = Color.Empty;
            button.FlatAppearance.BorderSize = 0;
        }

        private void goToPositionButton_Click(object sender, EventArgs e)
        {
            ShowBases();
        }

        private void addGenomeButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Přidat genom", addGenomeButton);
        }

        private void deleteGenomeButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Odstranit vybraný genom", deleteGenomeButton);
        }

        private void addGenomeButton_Click(object sender, EventArgs e)
        {              
            var genomFile = new OpenFileDialog();
            genomFile.Title = "Vyberte soubor s genomem";
            genomFile.Filter = "Genom files (*.fa) | *.fa;";
            if (genomFile.ShowDialog() == DialogResult.OK)
            {
                var indexerFile = new OpenFileDialog();
                indexerFile.Title = "Vyberte indexer genomu";
                indexerFile.Filter = "Indexer files (*.fai) | *.fai;";
                if (indexerFile.ShowDialog() == DialogResult.OK)
                {
                    genoms.Add(new Genom(genomFile.FileName, indexerFile.FileName));
                }
                
                Gateway.SaveGenoms(genoms);
                UpdateGenoms();
                genomComboBox.SelectedIndex = genomComboBox.Items.Count - 1;
            }
        }

        private void leftButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Vlevo", leftButton);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (genomComboBox.Items.Count > 0 && genomComboBox.SelectedIndex >= 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0 && chromComboBox.SelectedIndex >=0) 
            {
                long position;
                try
                {                 
                    position = Int64.Parse(positionTextBox.Text);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    return;
                }

                if (position > 1) position -= 1;
                positionTextBox.Text = position.ToString();
                ShowBases();
            }
        }

        private void rightButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Vpravo", rightButton);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (genomComboBox.Items.Count > 0 && genomComboBox.SelectedIndex >= 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0 && chromComboBox.SelectedIndex >= 0)
            {
                var choosedChrom = genoms[genomComboBox.SelectedIndex].chromosomes[chromComboBox.SelectedIndex];
                long position;
                try
                {
                    position = Int64.Parse(positionTextBox.Text);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    return;
                }

                if (position < choosedChrom.length) position += 1;
                positionTextBox.Text = position.ToString();
                ShowBases();
            }
        }

        private void deleteGenomeButton_Click(object sender, EventArgs e)
        {
            if (genomComboBox.Items.Count > 0)
            {

                var result = MessageBox.Show("Opravdu si přejete odstranit daný genom ze seznamu?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selectedIndex = genomComboBox.SelectedIndex;
                    genoms.RemoveAt(selectedIndex);
                    Gateway.SaveGenoms(genoms);
                    UpdateGenoms();
                    if (genomComboBox.Items.Count > 0)
                    {
                        genomComboBox.SelectedIndex = 0;
                        //chromComboBox.SelectedIndex = 0;
                    }

                }
            }
        }

        private void addVcfButton_Click(object sender, EventArgs e)
        {

            if (genomComboBox.Items.Count == 0) MessageBox.Show("K dispozici není žádný genom, nejprve prosím přidejte genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if(genomComboBox.SelectedIndex < 0) MessageBox.Show("Nebyl vybrán žádný genom, prosím nejdříve vyberte z nabídky genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                var file = new OpenFileDialog();
                file.Title = "Vyberte soubor";
                file.Filter = "VCF files (*.vcf) | *.vcf;";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    var choosedGenom = genoms[genomComboBox.SelectedIndex];
                    var vcfName = GetReferenceOnGenom(file.FileName);
                    bool load = true;
                    if (choosedGenom.name != vcfName)
                    {
                        DialogResult rs = MessageBox.Show("Soubor nemá refenci na genom, chcete i přesto načíst soubor?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.No) load = false;
                    }
                    if (load)
                    {
                        var vcf = new VCF(file.FileName);
                        choosedGenom.vcfs.Add(vcf);
                        Gateway.SaveGenoms(genoms);
                        UpdateVCFListView();
                    }
                }
            }
        }   

        private void removeVcfButton_Click(object sender, EventArgs e)
        {
            if (choosedVCF == null) MessageBox.Show("Nebyl vybrán žádný VCF soubor ze seznamu.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult rs = MessageBox.Show("Opravdu si přejete odstranit vybraný soubor " + choosedVCF.name + " ze seznamu?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    genoms[genomComboBox.SelectedIndex].vcfs.Remove(choosedVCF);
                    choosedVCF = null;
                    UpdateVCFListView();
                    vcfDetailListView.Items.Clear();
                    Gateway.SaveGenoms(genoms);
                }
            }
        }
        private String GetReferenceOnGenom(String path)
        {
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("##reference"))
                    {
                        string[] pathSegments = line.Split('=')[1].Split('/');
                        return pathSegments[pathSegments.Length - 1];
                    }

                }
                return null;
            }
        }

        private void ChangeColorOfRows()
        {
            for (var i = 0; i < vcfListView.Items.Count; i++)
            {
                vcfListView.Items[i].BackColor = Color.Transparent;
                vcfListView.Items[i].ForeColor = Color.Black;
            }
        }

        private void vcfListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) 
            {
                ChangeColorOfRows();
                e.Item.BackColor = Color.ForestGreen;
                e.Item.ForeColor = Color.White;
                choosedVCF = genoms[genomComboBox.SelectedIndex].vcfs[e.ItemIndex];
                vcfDetailListView.Items.Clear();
                vcfDetailListView.Columns.Clear();
                FillCheckListBox();
                FillListView();
                e.Item.Selected = false;
                settingsButton.Visible = true;
            }                               
        }

        private void filterCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = 7; i < vcfDetailListView.Columns.Count; i++)
            {
                bool isAtList = false;
                for (var j = 0; j < filterCheckedListBox.CheckedItems.Count; j++)
                {

                    if (filterCheckedListBox.CheckedItems[j].ToString().Split('-')[0] == vcfDetailListView.Columns[i].Text)
                    {
                        if (vcfDetailListView.Columns[i].Width == 0) //vcfDetailListView.Columns[i].Width = 60;
                            vcfDetailListView.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        isAtList = true;
                        break;
                    }
                }
                if (!isAtList)
                {
                    vcfDetailListView.Columns[i].Width = 0;
                }
            }
        }
        private int? GetColumnIndex(string name)
        {
            for (var i = 0; i < vcfDetailListView.Columns.Count; i++)
            {
                if (vcfDetailListView.Columns[i].Text == name)
                {
                    return i;
                }
            }
            return null;
        }
        private ColumnHeader GetColumn(string name)
        {
            var col = new ColumnHeader();
            col.Text = name;
            col.Width = 100;
            col.TextAlign = HorizontalAlignment.Center;
            return col;
        }
        private void FillCheckListBox()
        {
            filterCheckedListBox.HorizontalScrollbar = true;
            filterCheckedListBox.Items.Clear();

            vcfDetailListView.Columns.Add(GetColumn("Chrom"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("Pozice"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("ID"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("Reference"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("Alt"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("Qual"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Columns.Add(GetColumn("Filter"));
            vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            vcfDetailListView.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            foreach (var item in choosedVCF.info)
            {
                filterCheckedListBox.Items.Add(item["ID"] + "-" + item["Description"]);
                var col = new ColumnHeader();
                col.Text = item["ID"];              
                col.Width = 0;
                vcfDetailListView.Columns.Add(col);
                vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            }

            foreach (var format in choosedVCF.format)
            {
                filterCheckedListBox.Items.Add(format["ID"] + "-" + format["Description"]);
                var col = new ColumnHeader();
                col.Text = format["ID"];
                col.Width = 0;
                vcfDetailListView.Columns.Add(col);
                vcfDetailListView.Columns[vcfDetailListView.Columns.Count - 1].TextAlign = HorizontalAlignment.Center;
            }

            var col2 = new ColumnHeader();
            col2.Text = "list";
            col2.Width = 0;
            vcfDetailListView.Columns.Add(col2);

            var col3 = new ColumnHeader();
            col3.Text = "order";
            col3.Width = 0;
            vcfDetailListView.Columns.Add(col3);
        }
        private void FillListView()
        {
            List<ListViewItem> list = new List<ListViewItem>();
            int h = 0;
            foreach (var variance in choosedVCF.variants)
            {

                for (var j = 0; j < variance.Count; j++)
                {
                    list.Add(new ListViewItem());
                    for (var i = 0; i < choosedVCF.info.Count + 7 + choosedVCF.format.Count + 1; i++)
                    {
                        list[list.Count - 1].SubItems.Add(new ListViewItem.ListViewSubItem());
                    }
                    list[list.Count - 1].SubItems[0].Text = variance[j].chrom;
                    list[list.Count - 1].SubItems[1].Text = variance[j].position.ToString();
                    list[list.Count - 1].SubItems[2].Text = variance[j].id.ToString();
                    list[list.Count - 1].SubItems[3].Text = variance[j].reference.ToString();
                    foreach (var alt in variance[j].alt)
                    {
                        if (alt.mark != '-')
                            list[list.Count - 1].SubItems[4].Text += alt.mark.ToString();
                    }
                    if (variance[j].formatNumber > 0 && choosedVCF.moreColumns) list[list.Count - 1].SubItems[4].Text += " (" + choosedVCF.formatNames[h] + ")"; /*variance[j].formatNumber + ")";*/
                    list[list.Count - 1].SubItems[5].Text = variance[j].qual.ToString();
                    list[list.Count - 1].SubItems[6].Text = variance[j].filter.ToString();
                    foreach (var info in variance[j].info)
                    {
                        var index = GetColumnIndex(info.Key);
                        if (index != null) list[list.Count - 1].SubItems[index.Value].Text = info.Value;
                    }

                    foreach (var format in variance[j].format)
                    {
                        var index = GetColumnIndex(format.Key);
                        if (index != null) list[list.Count - 1].SubItems[index.Value].Text = format.Value;
                    }

                    list[list.Count - 1].SubItems[list[list.Count - 1].SubItems.Count - 2].Text = h.ToString();
                    list[list.Count - 1].SubItems[list[list.Count - 1].SubItems.Count - 1].Text = j.ToString();

                    list[list.Count - 1].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
                }
                h++;
            }

            vcfDetailListView.Items.AddRange(list.ToArray());
        }

        private void vcfDetailListView_DoubleClick(object sender, EventArgs e)
        {
            
            chromComboBox.SelectedIndex = GetChromId(choosedVariance.chrom);

            positionTextBox.Text = choosedVariance.position.ToString();

            ShowBases();
        }

        private void vcfDetailListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int list = Int32.Parse(vcfDetailListView.Items[e.ItemIndex].SubItems[vcfDetailListView.Items[e.ItemIndex].SubItems.Count - 2].Text);
            int order = Int32.Parse(vcfDetailListView.Items[e.ItemIndex].SubItems[vcfDetailListView.Items[e.ItemIndex].SubItems.Count - 1].Text);

            if (e.IsSelected) choosedVariance = choosedVCF.variants[list][order];
        }
        private int GetChromId(string name)
        {
            var genom = genoms[genomComboBox.SelectedIndex];
            for (var i = 0; i < genom.chromosomes.Count; i++)
            {
                if (genom.chromosomes[i].name == name) return i;
            }
            return -1;
        }

        private void showChartButton_Click(object sender, EventArgs e)
        {
            if (genomComboBox.Items.Count == 0) MessageBox.Show("K dispozici není žádný genom, nejprve prosím přidejte genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (genomComboBox.SelectedIndex < 0) MessageBox.Show("Nebyl vybrán žádný genom, prosím nejdříve vyberte z nabídky genom.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (genoms[genomComboBox.SelectedIndex].vcfs.Count == 0) MessageBox.Show("Nejsou k dispozici žádné VCF soubory.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            else
            {
                ChartForm form = new ChartForm(genoms[genomComboBox.SelectedIndex].vcfs);
                form.Show();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (genoms[genomComboBox.SelectedIndex].vcfs.Count == 0) MessageBox.Show("Nejsou k dispozici žádné VCF soubory.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (choosedVCF == null) MessageBox.Show("Prosím, nejprve vyberte ze seznamu VCF soubor.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (!settingClicked)
                    {
                        filterCheckedListBox.Visible = true;
                        settingClicked = true;
                    }
                    else
                    {
                        filterCheckedListBox.Visible = false;
                        settingClicked = false;
                    }
                }
            }
        }

        private void positionTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Int64.Parse(positionTextBox.Text);

            }
            catch (Exception ex)
            {
                positionTextBox.Text = "1";
            }
        }

        private void chromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionTextBox.Text = "1";
        }

        private void addVcfButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Přidat VCF soubor", addVcfButton);
        }

        private void removeVcfButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Odstranit VCF soubor", removeVcfButton);
        }

        private void showChartButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Zobrazit graf", showChartButton);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if(isLoaded && (genomComboBox.Items.Count > 0 && genoms[genomComboBox.SelectedIndex].chromosomes.Count > 0))
                ShowBases();
        }
    }
}
