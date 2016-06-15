using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Teste_SideScroller
{
    class SideScroller {

        public const int CANVAS_HEIGHT = 500;
        public const int CANVAS_WIDTH = 800;
        public const int LEVEL_WIDTH = 24;
        public const int LEVEL_HEIGHT = 14;
        public const int TILE_SIDE_LENGTH = 30;

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

    }

    public enum TextureID {
        air,
        dirt
    }
}
