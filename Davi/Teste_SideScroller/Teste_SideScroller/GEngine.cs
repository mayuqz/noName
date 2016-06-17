using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Teste_SideScroller
{
    class GEngine {

        /* --------- Members ----------*/
        private Graphics drawHandle;
        private Thread renderThread;
        private static Thread renderJump;

        private Bitmap tex_koala;
        private Bitmap tex_dirt;
        private Bitmap tex_dirt2;

        static int koala_x = 0;
        static int koala_y = 0;

        public static bool koalaLeft = false;
        public static bool koalaRifht = false;

        int screen_x = 0;
        int screen_y = 0;

        int pontos = 0;

        int fps = 0;

        /* --------- Functions ---------- */

        public GEngine(Graphics g) {
            drawHandle = g;
        }

        public void init() {
            loadAssets();

            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();

            renderJump = new Thread(new ThreadStart(renderJump_));
            //renderJump.Start();
            //renderJump.Start();
        }

        private void loadAssets() {
            tex_koala = Teste_SideScroller.Properties.Resources.Koala4;
            tex_dirt = Teste_SideScroller.Properties.Resources.tex_dirt2;
            tex_dirt2 = Teste_SideScroller.Properties.Resources.tex_dirt;
        }

        public void stop() {
            renderThread.Abort();
        }

        static bool koalaFall = true;
        static bool koalaJumpBool = false;

        public static void koalaJump() {
            if (!koalaJumpBool) { koalaJumpBool = true; Console.WriteLine("Jump"); }
        }

        private void renderJump_() {
            while (true) {
                int old_koalaX = koala_x;
                int old_koalaY = koala_y;

                int koalaPositionX = koala_x / SideScroller.TILE_SIDE_LENGTH;
                int koalaPositionY = koala_y / SideScroller.TILE_SIDE_LENGTH;

                //koalaFall = false;

                TextureID[,] textures = Level.Blocks;

                if (koalaJumpBool) {
                    koalaJumpBool = false;

                    while (true) {
                        koalaFall = false;

                        for (int i = 0; true; i++){
                            if (i % 100 == 0) {
                                if (koala_y >= old_koalaY - 100) {
                                    koala_y--;
                                }
                                else break;
                            }
                        }

                        //koalaFall = true;
                        break;

                        //if (koalaJump == true) {
                            //if(
                        //}

                        //TextureID[,] textures = Level.Blocks;
                        //int koalaBlock = (int)textures[koalaPositionX, koalaPositionY];
                    }
                }
                
                if(koalaFall){
                    if (textures[koalaPositionX, koalaPositionY] == TextureID.air) {
                        //MessageBox.Show("Fora do shão");
                        koala_y = koala_y + 10;
                    }
                }

                //koalaFall = true;
            }
        }

        static bool run = true;
        bool runable = false;

        public void pause() {
            renderThread.Suspend();
            Console.WriteLine("Pause");
            runable = true;
        }

        public void resume() {
            if (runable) {
                renderThread.Resume();
                Console.WriteLine("Resume");
            }
        }

        private void end() {
            pontos = 0;
            koala_x = 0;
            koala_y = 3 + 8 * SideScroller.TILE_SIDE_LENGTH;
            //koala_y = 8;
        }

        int old_koalaY = 0;

        bool koalajumpable = true;

        private void render() {
            int frameRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(SideScroller.CANVAS_WIDTH, SideScroller.CANVAS_HEIGHT);
            Graphics frameGraphcs = Graphics.FromImage(frame);

            TextureID[,] textures = Level.Blocks;

            koala_y = 8;

            while (true) {
                
                frameGraphcs.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, SideScroller.CANVAS_WIDTH, SideScroller.CANVAS_HEIGHT);

                while (!run) ;

                frameGraphcs.FillRectangle(new SolidBrush(Color.Aquamarine), 0, 0, SideScroller.CANVAS_WIDTH, 50);

                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 20);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
                frameGraphcs.DrawString("Pontos: " + pontos, drawFont, drawBrush, 50, 10);
                frameGraphcs.DrawString("FPS: " + fps, drawFont, drawBrush, SideScroller.CANVAS_WIDTH - 150, 10);

                frameGraphcs.DrawString("DaviApps inc.", new System.Drawing.Font("Arial", 50), new System.Drawing.SolidBrush(System.Drawing.Color.Azure), SideScroller.CANVAS_WIDTH/2 - screen_x, 100);

                //drawFont.Dispose();
                //drawBrush.Dispose();
                //frameGraphcs.Dispose();

                //if (koala_y < 8 * SideScroller.TILE_SIDE_LENGTH) {
                

                for (int x = 0; x < SideScroller.LEVEL_WIDTH; x++) {
                    for (int y = 0; y < SideScroller.LEVEL_HEIGHT; y++) {
                        switch (textures[x, y]) {
                            case TextureID.air:
                                //frameGraphcs.FillRectangle(new SolidBrush(Color.Red), x * SideScroller.TILE_SIDE_LENGTH, y * SideScroller.TILE_SIDE_LENGTH, 49, 49);
                            break;
                            case TextureID.dirt:
                                //frameGraphcs.DrawImage(tex_dirt, x * SideScroller.TILE_SIDE_LENGTH, y * SideScroller.TILE_SIDE_LENGTH);
                                frameGraphcs.FillRectangle(new SolidBrush(Color.Brown), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH, 49, 49);
                            break;
                            case TextureID.dirt2:
                            //frameGraphcs.DrawImage(tex_dirt2, x * SideScroller.TILE_SIDE_LENGTH, y * SideScroller.TILE_SIDE_LENGTH);
                            frameGraphcs.FillRectangle(new SolidBrush(Color.Green), x * SideScroller.TILE_SIDE_LENGTH - screen_x + 2, y * SideScroller.TILE_SIDE_LENGTH - 2, 10, 10);
                            frameGraphcs.FillRectangle(new SolidBrush(Color.Green), x * SideScroller.TILE_SIDE_LENGTH - screen_x + 15, y * SideScroller.TILE_SIDE_LENGTH - 5, 5, 10);
                            frameGraphcs.FillRectangle(new SolidBrush(Color.Green), x * SideScroller.TILE_SIDE_LENGTH - screen_x + 30, y * SideScroller.TILE_SIDE_LENGTH - 4, 10, 10);
                            //frameGraphcs.FillRectangle(new SolidBrush(Color.Green), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH, 49, 10);

                                frameGraphcs.FillRectangle(new SolidBrush(Color.Green), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH, 49, 10);
                                frameGraphcs.FillRectangle(new SolidBrush(Color.Brown), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH + 10, 49, 39);
                            break;
                            case TextureID.lava:
                                frameGraphcs.FillRectangle(new SolidBrush(Color.Red), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH, 49, 49);
                            break;
                            case TextureID.coin:
                                frameGraphcs.FillRectangle(new SolidBrush(Color.Orange), x * SideScroller.TILE_SIDE_LENGTH - screen_x, y * SideScroller.TILE_SIDE_LENGTH, 49, 49);
                            break;
                        }
                    }
                }

                int koalaPositionX = (koala_x) / 50;
                int koalaPositionY = (koala_y) /50;

                int koalaBlock = (int)textures[(koala_x + 45) / 50, koalaPositionY];
                int koalaBlock_DownRight = (int)textures[(koala_x + 52) / 50, (koala_y) / 50];
                int koalaBlock_DownLeft = (int)textures[(koala_x - 5) / 50, (koala_y) / 50];
                int koalaBlockDown = (int) textures[koalaPositionX, koalaPositionY +1];
                int koalaBlockUp = 0;
                if(koala_y / 50 > 1) koalaBlockUp = (int) textures[(koala_x + 25) / 50, koalaPositionY - 1];
                int koalaBlockLeft = 0;
                //if(koala_x/50 > 1) koalaBlockLeft = (int) textures[koalaPositionX - 1, koalaPositionY];
                if (koala_x / 50 > 1) koalaBlockLeft = (int)textures[(koala_x + 45) / 50 - 1, (koala_y + 45) /50];
                //int koalaBlockRight = (int) textures[ koalaPositionX + 1, koalaPositionY];
                int koalaBlockRight = (int)textures[(koala_x + 2) / 50 + 1, (koala_y + 45) / 50];

                int koalaBlockDownLeft = 0;
                if (koala_x / 50 > 1) koalaBlockDownLeft = (int)textures[koalaPositionX - 1, koalaPositionY + 1];
                int koalaBlockDownRight = 0;
                if (koala_x / 50 > 1) koalaBlockDownRight = (int)textures[(koala_x - 2) / 50 + 1, (koala_y) / 50 + 1];

                ///int koalaBlockUpLeft = 0;
                //if (koala_x / 50 > 1) koalaBlockUpLeft = (int)textures[koalaPositionX - 1, koalaPositionY - 1];
                int koalaBlockUpRight = 0;
                if (koala_x / 50 > 1) koalaBlockUpRight = (int)textures[koalaPositionX + 1, koalaPositionY - 1];

                if (koalaJumpBool && koalajumpable) { //  ----------------------------------------------  JUMP  ------------------------------------------
                    //koalaJumpBool = false;

                    koalaFall = false;

                    if (koalaBlock == (int) TextureID.coin) pontos = pontos + 5;

                    if (koala_y >= old_koalaY - 60 && old_koalaY - 100 > 0 && ((int)textures[(koala_x + 45) / 50, koalaPositionY] == (int)TextureID.air && (int)textures[(koala_x) / 50, koalaPositionY] == (int)TextureID.air /*&& (koalaBlockRight == (int) TextureID.air && koala_x% 50 > 0)*/)) koala_y = koala_y - 5;
                    else {
                        koalaJumpBool = false;
                        koalaFall = true;
                        koalajumpable = false;
                    }

                }

                /* ---------------------------------------------DIRECAO --------------------------------------- */

                if (koalaLeft && koalaRifht) ;
                else
                if (koalaRifht) {
                    if (koala_x < SideScroller.LEVEL_WIDTH * SideScroller.TILE_SIDE_LENGTH - 60) {
                        if (koalaBlockRight == (int) TextureID.air && koalaBlock_DownRight == (int) TextureID.air) {
                        //Console.WriteLine(koala_x + "Direita: " + koalaBlockRight);
                            koala_x = koala_x + 5;
                        }
                        /*else
                        if (koalaBlockRight == (int) TextureID.air) {
                        }*/
                    }
                }
                else 
                if (koalaLeft) {
                    if (koala_x >= 1) {
                        /*if (koalaBlockLeft == (int) TextureID.air){
                            koala_x = koala_x - 5;
                        }*/
                        if (koalaBlockLeft == (int) TextureID.air && koalaBlock_DownLeft == (int) TextureID.air) {
                            koala_x = koala_x - 5;
                        }
                    }
                }

                if (koalaBlockDown == (int) TextureID.lava) end();
                
                if(koalaFall){ // ------------------------------------------------------- FALL  -----------------------------------------
                    if (koalaBlockDown == (int) TextureID.air) {
                        if (koalaBlockDownLeft != (int) TextureID.air && koalaBlockDownRight != (int) TextureID.air) {
                            //if (koala_x % 50 == 0) { koala_y = koala_y + 5; }
                        }
                        else
                        if (koalaBlockDownRight != (int) TextureID.air) {
                            //koala_y = koala_y + 5;
                        }
                        else
                        if (koalaBlockDownLeft != (int) TextureID.air) {
                            koala_y = koala_y + 5;
                        }
                        /*else
                        if (koalaBlockDown != (int) TextureID.air) {
                            if (koalaBlockDownLeft != (int) TextureID.air && koalaBlockDownRight != (int) TextureID.air) {
                                Console.WriteLine(koala_x);
                            }
                        }*/
                        else {
                            koala_y = koala_y + 5;
                        }
                    }
                    else
                    if (koalaBlockDown == (int) TextureID.dirt || koalaBlockDown == (int) TextureID.dirt2) {
                        old_koalaY = koala_y;
                        koalaJumpBool = false;
                        koalajumpable = true;
                    }
                }

                //frameGraphcs.DrawImage(tex_koala, koala_x /* * SideScroller.TILE_SIDE_LENGTH */, koala_y - 55 /* * SideScroller.TILE_SIDE_LENGTH - 10 */, 50, 100);

                //frameGraphcs.FillRectangle(new SolidBrush(Color.Orange), koala_x, koala_y - 50, 49, 50);
                frameGraphcs.FillRectangle(new SolidBrush(Color.Green), koala_x - screen_x, koala_y - screen_y - 3, 49, 49);
                frameGraphcs.FillRectangle(new SolidBrush(Color.YellowGreen), koala_x - screen_x + 5, koala_y - screen_y + 2, 40, 40);

                //frameGraphcs.FillRectangle(new SolidBrush(Color.Red), (koala_x + 2) + 1, (koala_y + 45), 2, 2);

                //Bitmap koala = Teste_SideScroller.Properties.Resources.Koala2;
                //frameGraphcs.DrawImage(koala, 100, 100);

                drawHandle.DrawImage(frame, 0, 0);

                if (screen_x + SideScroller.CANVAS_WIDTH < SideScroller.LEVEL_WIDTH * SideScroller.TILE_SIDE_LENGTH + 17 && koala_x - screen_x > SideScroller.CANVAS_WIDTH/2) screen_x = screen_x + 5;
                if (screen_x > 0 && koala_x - screen_x < SideScroller.CANVAS_WIDTH / 2) screen_x = screen_x - 5;


                frameRendered++;
                if (Environment.TickCount >= startTime + 1000) {
                    fps = frameRendered;
                    //koala_x++;
                    //if (koala_x > SideScroller.LEVEL_WIDTH) koala_x = 0;
                    Console.Write("GEngine: " + frameRendered + " fps");
                    Console.WriteLine("Left: " + koalaLeft + " | Right: " + koalaRifht);
                    //Console.WriteLine("Bloco depois da queda: " + (int)textures[300/50, 600 / 50]);
                    frameRendered = 0;
                    startTime = Environment.TickCount;
                    //if (screen_x + SideScroller.CANVAS_WIDTH < SideScroller.LEVEL_WIDTH * SideScroller.TILE_SIDE_LENGTH) screen_x = screen_x + 5;
                }
            }
        }

    }
}
