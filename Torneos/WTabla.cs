using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace Torneos {
    public partial class WTabla : Form {
        private Dictionary<String, List<String>> allInputs = new Dictionary<String, List<String>>();
        private String urlFile = "";
        private int currentTeams = 128;
        Tournament128 Tournament128 = new Tournament128();
        Tournament64 Tournament64 = new Tournament64();
        Tournament32 Tournament32 = new Tournament32();
        Tournament16 Tournament16 = new Tournament16();
        Tournament8 Tournament8 = new Tournament8();

        public WTabla(String uri) {
            InitializeComponent();
            allInputs.Add("128", new List<String>());
            allInputs.Add("64", new List<String>());
            allInputs.Add("32", new List<String>());
            allInputs.Add("16", new List<String>());
            allInputs.Add("8", new List<String>());
            allInputs.Add("4", new List<String>());
            allInputs.Add("2", new List<String>());
            allInputs.Add("1", new List<String>());
            panelInputs.Controls.Add(Tournament128);
            if (uri != ""){
                urlFile = uri;
                readFileTournament();
            }
        }

        private void WTabla_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void btSave_Click(object sender, EventArgs e) {
            saveTableOnFile();
        }

        private void backTeam_Click(object sender, EventArgs e) {
            saveTableOnList();
            if (currentTeams != 128){
                panelInputs.Controls.Clear();
                switch (currentTeams){
                    case 64:
                        lb128.Show();
                        lb128.Width = 125;
                        lb64.Width = 150;
                        panelInputs.Controls.Add(Tournament128);
                        currentTeams = 128;
                        break;
                    case 32:
                        lb64.Show();
                        lb64.Width = 125;
                        lb32.Width = 150;
                        panelInputs.Controls.Add(Tournament64);
                        currentTeams = 64;
                        break;
                    case 16:
                        lb32.Show();
                        lb32.Width = 125;
                        lb16.Width = 150;
                        panelInputs.Controls.Add(Tournament32);
                        currentTeams = 32;
                        break;
                    case 8:
                        lb16.Show();
                        lb16.Width = 125;
                        lb8.Width = 150;
                        panelInputs.Controls.Add(Tournament16);
                        currentTeams = 16;
                        break;
                    default:
                        break;
                }
                putTextOnTable();
            }
        }

        private void nextTeam_Click(object sender, EventArgs e) {
            saveTableOnList();
            if (currentTeams != 8){
                panelInputs.Controls.Clear();
                switch (currentTeams){
                    case 128:
                        lb128.Hide();
                        lb64.Width = 125;
                        panelInputs.Controls.Add(Tournament64);
                        currentTeams = 64;
                        break;
                    case 64:
                        lb64.Hide();
                        lb32.Width = 125;
                        panelInputs.Controls.Add(Tournament32);
                        currentTeams = 32;
                        break;
                    case 32:
                        lb32.Hide();
                        lb16.Width = 125;
                        panelInputs.Controls.Add(Tournament16);
                        currentTeams = 16;
                        break;
                    case 16:
                        lb16.Hide();
                        lb8.Width = 125;
                        panelInputs.Controls.Add(Tournament8);
                        currentTeams = 8;
                        break;
                    default:
                        break;
                }
                putTextOnTable();
            }

        }

        private void saveTableOnList() {
            for (int i = currentTeams; i > 0; i /= 2){
                allInputs[i.ToString()].Clear();
                for (int j = 0; j < i; j++){
                    Simple_Input cnt = (Simple_Input)panelInputs.Controls.Find("i" + i + "_" + j, true).First();
                    allInputs[i.ToString()].Add(cnt.textBox1.Text);
                }
            }
        }

        private void saveTableOnFile() {
            saveTableOnList();
            if (urlFile == "") {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    urlFile = saveFileDialog1.FileName;
                }
            }
            using (StreamWriter file = new StreamWriter(urlFile, false)){
                for (int i = 128; i > 0; i /= 2){
                    foreach (string item in allInputs[i.ToString()]){
                        file.WriteLine("{0},{1}", i.ToString(), item);
                    }
                }
            }
        }

        public void putTextOnTable() {
            for (int i = currentTeams; i > 0; i /= 2){
                for (int j = 0; j < i; j++){
                    Simple_Input cnt = (Simple_Input)panelInputs.Controls.Find("i" + i + "_" + j, true).First();
                    cnt.textBox1.Text = allInputs[i.ToString()][j];
                }
            }
        }

        public void readFileTournament() {
            try {
                allInputs["128"].Clear();
                allInputs["64"].Clear();
                allInputs["32"].Clear();
                allInputs["16"].Clear();
                allInputs["8"].Clear();
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(urlFile))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) {
                    String line;
                    while ((line = streamReader.ReadLine()) != null) {
                        allInputs[line.Substring(0, line.IndexOf(","))].Add(line.Substring(line.IndexOf(",") + 1));
                    }
                }
                putTextOnTable();
            } catch (Exception) {
            }

        }

        private void btOpen_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "") {             urlFile = openFileDialog1.FileName;
                readFileTournament();
            }
        }
    }
}
