using LinqToExcel;
using Syroot.Windows.IO;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CommImportCompare {

    public partial class Form1 : Form {
        public static ExcelQueryFactory FileA;
        public static ExcelQueryFactory FileB;
        public static List<CommLine> FileARows;
        public static List<CommLine> FileBRows;

        public Form1() {
            InitializeComponent();
        }

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
                    for(int i = start; i < rows.Count; i++) {
                        FileARows.Add(new CommLine(
                            rows[i][0].ToString(),
                            rows[i][1].ToString(),
                            rows[i][4].ToString(),
                            Convert.ToDouble(rows[i][7]) + Convert.ToDouble(rows[i][8])
                            ));
                    }

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

                    for (int i = start; i < rows.Count; i++) {
                        FileBRows.Add(new CommLine(
                            rows[i][0].ToString(),
                            rows[i][1].ToString(),
                            rows[i][4].ToString(),
                            Convert.ToDouble(rows[i][7]) + Convert.ToDouble(rows[i][8])
                            ));
                    }

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

        private void btnCompare_Click(object sender, EventArgs e) {
            dgvFileA.DataSource = null; dgvFileB.DataSource = null;
            dgvFileA.Refresh(); dgvFileB.Refresh();

            List<string> Akeys = FileARows.GroupBy(z => z.Key).Select(x => x.Key).ToList();
            List<string> Bkeys = FileBRows.GroupBy(z => z.Key).Select(x => x.Key).ToList();

            List<CommLine> ListAErrors = new List<CommLine>();
            List<CommLine> ListBErrors = new List<CommLine>();

            foreach (CommLine line in FileARows) {
                if (Akeys.Contains(line.Key)) {

                    var FileAResults = FileARows.Where(x => x.Key == line.Key);
                    var FileBResults = FileBRows.Where(x => x.Key == line.Key);

                    int fileACount = FileAResults.Count();
                    int fileBCount = FileBResults.Count();

                    if (fileACount != fileBCount) {
                        ListAErrors.Add(line);
                    }
                    Akeys.RemoveAll(y => y == line.Key);
                }                
            }

            foreach (CommLine line in FileBRows) {
                if (Bkeys.Contains(line.Key)) {
                    int fileACount = FileARows.Count(x => x.Key == line.Key);
                    int fileBCount = FileBRows.Count(x => x.Key == line.Key);

                    if (fileBCount != fileACount) {
                        ListBErrors.Add(line);
                    }
                    Bkeys.RemoveAll(y => y == line.Key);
                }
            }

            dgvFileA.DataSource = ListAErrors;
            dgvFileB.DataSource = ListBErrors;

            dgvFileA.Refresh(); dgvFileB.Refresh();
        }
    }
}
