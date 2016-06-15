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

        public static void initLevel() {
            for (int x = 0; x < SideScroller.LEVEL_WIDTH; x++) {
                for (int y = 0; y < SideScroller.LEVEL_HEIGHT; y++) {
                    if (y >= 11) {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else {
                        blocks[x, y] = TextureID.air;
                    }
                }
            }
        }
    }
}
