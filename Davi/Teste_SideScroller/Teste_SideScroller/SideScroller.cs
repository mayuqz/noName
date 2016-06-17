using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Teste_SideScroller
{
    class SideScroller {

        public const int CANVAS_WIDTH = 1200;
        public const int CANVAS_HEIGHT = 690;
        public const int LEVEL_WIDTH = 30;
        public const int LEVEL_HEIGHT = 15;
        public const int TILE_SIDE_LENGTH = 50;

        private GEngine gEngine;

        public void loadLevel() {
            Level.initLevel();
        }

        public void startGraphcs(Graphics g) {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        public void stopSideScroller() {
            gEngine.stop();
        }

        public void pauseSideScroller(){
            gEngine.pause();
        }

        public void resumeSideScroller(){
            gEngine.resume();
        }

    }

    public enum TextureID {
        air,
        dirt,
        dirt2,
        lava,
        coin
    }
}
