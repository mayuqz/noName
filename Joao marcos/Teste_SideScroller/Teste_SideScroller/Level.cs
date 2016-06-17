using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_SideScroller
{
    class Level {
        private static TextureID[,] blocks = new TextureID[SideScroller.LEVEL_WIDTH, SideScroller.LEVEL_HEIGHT];

        public static TextureID[,] Blocks {
            get { return blocks; }
            set { blocks = value; }
        }

        static int[,] level1 = new int[SideScroller.LEVEL_HEIGHT, SideScroller.LEVEL_WIDTH] { 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                            { 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0, 2, 2, 2, 2, 1, 2, 2, 0, 0, 0, 0, 0, 2 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0 }, 
                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }, 
                            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 } 
                        };

        public static void initLevel() {

            for (int x = 0; x < SideScroller.LEVEL_WIDTH; x++) {
                for (int y = 0; y < SideScroller.LEVEL_HEIGHT; y++) {
                    TextureID block = (TextureID) level1[y, x];
                    blocks[x, y] = block;
                }
            }

            /*for (int x = 0; x < SideScroller.LEVEL_WIDTH; x++) {
                for (int y = 0; y < SideScroller.LEVEL_HEIGHT; y++) {
                    blocks[x, y] = TextureID.air;
                    if (y >= 11 && y < 13) {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else
                    if(y == 10){
                        blocks[x, y] = TextureID.dirt2;
                    }
                    else
                    if(y == 13) blocks[x, y] = TextureID.lava;
                    else {
                        blocks[x, y] = TextureID.air;
                    }
                }
            }

            blocks[7, 10] = TextureID.air;
            blocks[7, 11] = TextureID.air;
            blocks[7, 12] = TextureID.air;

            blocks[9, 10] = TextureID.dirt;
            blocks[9, 9] = TextureID.dirt2;*/
        }
    }
}
