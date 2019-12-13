using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles {
    public partial class Presets : Form {

        MainWindow parent;

        public Presets(MainWindow _parent) {

            InitializeComponent();

            parent = _parent;
        }

        /// <summary>
        /// Event for the solar system button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolarSys_btn_Click(object sender, EventArgs e) {

            //parent.startMode = MainWindow.StartModes.solar;
            //parent.Restart();
            //Close();
        }

        /// <summary>
        /// Event for the two body system button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoBodySys_btn_Click(object sender, EventArgs e) {

            parent.startMode = MainWindow.StartModes.twoBod;
            parent.Restart();
            Close();
        }

        /// <summary>
        /// Event for the three body system button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreeBodySys_btn_Click(object sender, EventArgs e) {

            parent.startMode = MainWindow.StartModes.threeBod;
            parent.Restart();
            Close();
        }
    }
}
