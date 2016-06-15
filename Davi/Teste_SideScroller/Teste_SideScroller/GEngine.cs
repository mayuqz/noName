using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Teste_SideScroller
{
    class GEngine {

        /* --------- Members ----------*/
        private Graphics drawHandle;
        private Thread renderThread;

        private Bitmap tex_koala;
        private Bitmap tex_dirt;

        public int koala_x = 0;
        public int koala_y = 0;

        /* --------- Functions ---------- */

        public GEngine(Graphics g) {
            drawHandle = g;
        }

        public void init() {
            loadAssets();

            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        private void loadAssets() {
            tex_koala = Teste_SideScroller.Properties.Resources.Koala2;
            tex_dirt = Teste_SideScroller.Properties.Resources.tex_dirt2;
        }

        public void stop() {
            renderThread.Abort();
        }

        private void render() {
            int frameRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(SideScroller.CANVAS_WIDTH, SideScroller.CANVAS_HEIGHT);
            Graphics frameGraphcs = Graphics.FromImage(frame);

            TextureID[,] textures = Level.Blocks;

            koala_y = 8;

            while (true) {
                frameGraphcs.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, SideScroller.CANVAS_WIDTH, SideScroller.CANVAS_HEIGHT);

                for (int x = 0; x < SideScroller.LEVEL_WIDTH; x++) {
                    for (int y = 0; y < SideScroller.LEVEL_HEIGHT; y++) {
                        switch (textures[x, y]) {
                            case TextureID.air:

                            break;
                            case TextureID.dirt:
                            frameGraphcs.DrawImage(tex_dirt, x * SideScroller.TILE_SIDE_LENGTH, y * SideScroller.TILE_SIDE_LENGTH);
                            break;
                        }
                    }
                }

                frameGraphcs.DrawImage(tex_koala, koala_x * SideScroller.TILE_SIDE_LENGTH, koala_y * SideScroller.TILE_SIDE_LENGTH - 10);

                //Bitmap koala = Teste_SideScroller.Properties.Resources.Koala2;
                //frameGraphcs.DrawImage(koala, 100, 100);

                drawHandle.DrawImage(frame, 0, 0);

                frameRendered++;
                if (Environment.TickCount >= startTime + 1000) {
                    koala_x++;
                    if (koala_x > SideScroller.LEVEL_WIDTH) koala_x = 0;
                    Console.WriteLine("GEngine: " + frameRendered + " fps");
                    frameRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }

    }
}
