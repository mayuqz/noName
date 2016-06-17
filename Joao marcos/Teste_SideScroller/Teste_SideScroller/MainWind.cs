using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Teste_SideScroller
{
    public partial class MainWind : Form
    {
        private SideScroller sideScroller = new SideScroller();

        public MainWind() {
            InitializeComponent();
            this.Width = SideScroller.CANVAS_WIDTH;
            this.Height = SideScroller.CANVAS_HEIGHT;

            sideScroller.loadLevel();
            Graphics g = canvas.CreateGraphics();
            sideScroller.startGraphcs(g);
        }

        private void canvas_Paint(object sender, PaintEventArgs e) {
            sideScroller.resumeSideScroller();
            //GEngine.resume();
            //sideScroller.loadLevel();
            //Graphics g = canvas.CreateGraphics();
            //sideScroller.startGraphcs(g);
        }

        private void MainWind_FormClosing(object sender, FormClosingEventArgs e) {
            sideScroller.stopSideScroller();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void MainWind_Load(object sender, EventArgs e) {
            AllocConsole();
        }

        private void MainWind_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Up) {
                //MessageBox.Show("Up");
                GEngine.koalaJump();
            }
            else
            if (e.KeyCode == Keys.Down) {
                //MessageBox.Show("O");
                
            }
            else
            if (e.KeyCode == Keys.Left) {
                GEngine.koalaLeft = true;
            }
            else
            if (e.KeyCode == Keys.Right) {
                GEngine.koalaRifht = true;
            }
            else
            if (e.KeyCode == Keys.Space) {
                //MessageBox.Show("K");
                GEngine.koalaJump();
            }
            else
            if (e.KeyCode == Keys.F4) {
                this.Close();
            }

        }

        private void MainWind_KeyUp(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Up) {
                //MessageBox.Show("Up");
            }
            else
            if (e.KeyCode == Keys.Down) {
                //MessageBox.Show("O");
                
            }
            else
            if (e.KeyCode == Keys.Left) {
                GEngine.koalaLeft = false;
            }
            else
            if (e.KeyCode == Keys.Right) {
                GEngine.koalaRifht = false;
            }
            else
            if (e.KeyCode == Keys.Space) {
                //MessageBox.Show("K");
                //GEngine.koalaJump();
            }
        }

        private void MainWind_Resize(object sender, EventArgs e){
            if (WindowState == FormWindowState.Minimized) {
                sideScroller.pauseSideScroller();
            }
        }
    }
}
