using LinqToExcel;
using Syroot.Windows.IO;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace CommImportCompare {

    public partial class Form1 : Form {
        public static ExcelQueryFactory FileA;
        public static ExcelQueryFactory FileB;
        public static List<CommLine> FileARows;
        public static List<CommLine> FileBRows;

        /// <summary>
        /// Start Form
        /// </summary>
        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// File A load button. Loads Excel file and writes CommLines to a List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadA_Click(object sender, EventArgs e) {
            string type = "xls";
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Desktop.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    FileA = new ExcelQueryFactory(ofd.FileName);
                    lblLoadA.Text = ofd.FileName;

                    var rows = FileA.Worksheet(0).ToList();
                    FileARows = new List<CommLine>();
                    int start = 0;

                    if(rows[0][0] == "Policy") {
                        start = 1;
                    }

                    for(int i = start; i < rows.Count; i++) { //iterate through the file and write to a list
                        FileARows.Add(new CommLine(
                            rows[i][0].ToString(),
                            rows[i][1].ToString(),
                            rows[i][4].ToString(),
                            Convert.ToDouble(rows[i][7]) + Convert.ToDouble(rows[i][8])
                            ));
                    }

                    //sort by policy, premium, total
                    FileARows.OrderBy(x => x.Policy).ThenBy(x => x.Premium).ThenBy(x => x.Total).ToList();
                    var keys = FileARows.Select(z => new { Value = z.Key }).ToList();
                    dgvFileA.DataSource = FileARows;
                    dgvFileA.Refresh();
                } else {
                    MessageBox.Show("ERROR LOADING INPUT FILE", "ERROR LOADING INPUT FILE", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// File B load button. Loads Excel file and writes CommLines to a List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadB_Click(object sender, EventArgs e) {
            string type = "xls";
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Desktop.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    FileB = new ExcelQueryFactory(ofd.FileName);
                    lblLoadB.Text = ofd.FileName;

                    var rows = FileB.Worksheet(0).ToList();
                    FileBRows = new List<CommLine>();

                    int start = 0;
                    if (rows[0][0] == "Policy") {
                        start = 1;
                    }

                    for (int i = start; i < rows.Count; i++) {//iterate through the file and write to a list
                        FileBRows.Add(new CommLine(
                            rows[i][0].ToString(),
                            rows[i][1].ToString(),
                            rows[i][4].ToString(),
                            Convert.ToDouble(rows[i][7]) + Convert.ToDouble(rows[i][8])
                            ));
                    }

                    //sort by policy, premium, total
                    FileBRows.OrderBy(x => x.Policy).ThenBy(x => x.Premium).ThenBy(x => x.Total).ToList();
                    var keys = FileBRows.Select(z => new { Value = z.Key }).ToList();
                    dgvFileB.DataSource = FileBRows;
                    dgvFileB.Refresh();
                } else {
                    MessageBox.Show("ERROR LOADING INPUT FILE", "ERROR LOADING INPUT FILE", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Compares the two lists of CommLines by CommLine.Key value counts.
        /// Compares listA to listB and then listB to listA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompare_Click(object sender, EventArgs e) {
            if(!File.Exists(lblLoadA.Text) || !File.Exists(lblLoadB.Text)) {
                MessageBox.Show("LOAD FILES FIRST", "LOAD FILES FIRST", MessageBoxButtons.OK);
                return;
            }

            dgvFileA.DataSource = null; dgvFileB.DataSource = null;
            dgvFileA.Refresh(); dgvFileB.Refresh();

            //make list of keys to skip duplicates
            List<string> Akeys = FileARows.GroupBy(z => z.Key).Select(x => x.Key).ToList();
            List<string> Bkeys = FileBRows.GroupBy(z => z.Key).Select(x => x.Key).ToList();

            //track mismatches
            List<CommLine> ListAErrors = new List<CommLine>();
            List<CommLine> ListBErrors = new List<CommLine>();

            //compare list A to list B
            foreach (CommLine line in FileARows) {
                if (Akeys.Contains(line.Key)) {

                    var FileAResults = FileARows.Where(x => x.Key == line.Key);
                    var FileBResults = FileBRows.Where(x => x.Key == line.Key);

                    int fileACount = FileAResults.Count();
                    int fileBCount = FileBResults.Count();

                    if (fileACount != fileBCount) {
                        ListAErrors.Add(line); //missmatch
                    }
                    Akeys.RemoveAll(y => y == line.Key);
                }                
            }

            //compare list B to list A
            foreach (CommLine line in FileBRows) {
                if (Bkeys.Contains(line.Key)) {
                    int fileACount = FileARows.Count(x => x.Key == line.Key);
                    int fileBCount = FileBRows.Count(x => x.Key == line.Key);

                    if (fileBCount != fileACount) {
                        ListBErrors.Add(line); //missmatch
                    }
                    Bkeys.RemoveAll(y => y == line.Key);
                }
            }

            //write errors to left and right Data Grid Views
            dgvFileA.DataSource = ListAErrors;
            dgvFileB.DataSource = ListBErrors;

            dgvFileA.Refresh(); dgvFileB.Refresh(); //redraw grid views
        }

        /// <summary>
        /// Ensures any stuck/open threads are closed on thread close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(0);
        }
    }
}
