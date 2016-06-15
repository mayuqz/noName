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

namespace Teste_SideScroller
{
    public partial class MainWind : Form
    {
        private SideScroller sideScroller = new SideScroller();

        public MainWind() {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e) {
            sideScroller.loadLevel();
            Graphics g = canvas.CreateGraphics();
            sideScroller.startGraphcs(g);
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
    }
}
