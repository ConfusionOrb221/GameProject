using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
TieOrDye Player Class
*/

namespace TieOrDye
{
    class Player: Game1
    {
        //Game1 object
        Game1 gm1 = new Game1();

        //Attributes
        float posX;
        float posY;

            //Get player's current position
        public void GetPos(float x, float y)
        {
            posX = x;
            posY = y;
        }




    }
}
