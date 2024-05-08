using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consnake
{
    class InputManager
    {
        ConsoleKeyInfo key;

        public void GetUserInput()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (GlobalVars.AktuelleRichtung != Bewegungsrichtung.unten)
                        {
                            GlobalVars.AktuelleRichtung = Bewegungsrichtung.oben;
                        }
                        break;
                    case ConsoleKey.A:
                        if (GlobalVars.AktuelleRichtung != Bewegungsrichtung.rechts)
                        {
                            GlobalVars.AktuelleRichtung = Bewegungsrichtung.links;
                        }
                        break;
                    case ConsoleKey.S:
                        if (GlobalVars.AktuelleRichtung != Bewegungsrichtung.oben)
                        {
                            GlobalVars.AktuelleRichtung = Bewegungsrichtung.unten;
                        }
                        break;
                    case ConsoleKey.D:
                        if (GlobalVars.AktuelleRichtung != Bewegungsrichtung.links)
                        {
                            GlobalVars.AktuelleRichtung = Bewegungsrichtung.rechts;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

}
