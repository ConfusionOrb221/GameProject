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
        //True if player is p1, false if p2
        bool player1;
        //Immunity boolean
        bool immune;
        
        //player constructor
        public Player(bool pl)
        {
            player1 = pl;
        }

            //Get player's current position
        public void GetPos(float x, float y)
        {
            posX = x;
            posY = y;
        }




    }
}
