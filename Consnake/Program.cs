using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/*Consnake Version 0.9
 Super simple kind of a "snake game", developed in May 2024 by "Christian Bammel" (drcodecrab), 4 houers of coding, easy for modding or expanding the code."
 Developed in Win 10. use "win10" to get a colorized game inside of the console.
*/
namespace Consnake
{
    class Program
    {
        GameManager gameManager;

        static void Main()
        {
            Program program = new Program();
            program.gameManager = new GameManager();
            program.gameManager.StartNewGame();
        }
    }
}
