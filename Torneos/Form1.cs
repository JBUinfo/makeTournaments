using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneos {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void newT_Click(object sender, EventArgs e) {
            this.Hide();
            WTabla WTabla = new WTabla("");
            WTabla.Show();
        }

        private void openFile_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != ""){
                this.Hide();
                WTabla WTabla = new WTabla(openFileDialog1.FileName);
                WTabla.Show();
            }
        }
    }
}
