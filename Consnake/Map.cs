using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consnake
{
    class Map
    {
        public int rows { get ; set; }
        public int columns { get; set; }
        int[,] logicMap;

        /// <summary>
        /// Erstellt die Spielflaeche
        /// </summary>
        /// <param name="_rows">Zeilen, also Hoehe</param>
        /// <param name="_columns">Spalten, also Breite</param>
        public Map(int _rows, int _columns) 
        {
            rows = _rows;
            columns = _columns;
            logicMap = new int[_rows, _columns]; //definiert die groesse unserer karte
        }

        public void CreateMap()
        {
            for (int i = 0; i < rows; i++) //reihe nr i
            { 
                for(int j = 0; j < columns; j++) // einmal alle spalten der jeweiligen zeile
                {
                    logicMap[i, j] = 0;
                }
            }
        }

        public void CreateMapRahmen()
        {
            // oben links die ecke
            logicMap[0, 0] = 20;

            //obere rahmen
            for (int j = 1; j < columns -1; j++) //obere zeile der matrix wird als rand mit einer 20 besetzt (wir starten mit 1, und hoeren mit weniger als eins auf, da die ecken eine andere zahl als 21 bekommen)
                {
                    logicMap[0, j] = 21;
                }
            //oben rechts die ecke
              logicMap[0, columns-1] = 22;
            //linke seite
            for (int i = 1; i < rows-1; i++) //alle reihen links in der spalte, wir lassen die ecken aus
            {
                    logicMap[i, 0] = 23;
            }
            //rechte seite
            for (int i = 1; i < rows - 1; i++) //alle reihen rechts in der spalte, wir lassen die ecken aus
            {
                logicMap[i, columns - 1] = 23;
            }
            //der rahmen unten
            for (int i = 1; i < columns - 1; i++) //der rahmen unten, ohne die ecken
            {
                logicMap[rows - 1,i] = 21;
            }
            //ecke unten links
            logicMap[rows - 1, 0] = 24;
            //ecke unten rechts
            logicMap[rows - 1, columns-1] = 25;
        }

        public void UpdateMapWithFood(List<Food> _foodPoints)
        {
            foreach (Food _food in _foodPoints)
            {
                logicMap[_food.point.x, _food.point.y] = 4; // die 4 ist nun futter inerhalb der logikmap
            }
        }

        public void UpdateMapWithSnake(List<Point> _snakePoints)
        {
                foreach (var item in _snakePoints) // wir zeichnen dann die schlange in die map
                {
                    logicMap[item.x, item.y] = 1; // die 1 ist ein schlangenelement innerhalb der logikmap
                }
        }

        public void Draw()
        {
           Console.CursorVisible = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                   Console.SetCursorPosition(j, i); //es ist hier vertaucht weil: zuerst die X-Koordinate (horizontale Position) und dann die Y-Koordinate (vertikale Position). (ist beim cursor halt so)
                    if (logicMap[i, j] == 0)
                    {
                        Console.Write(" "); //leeres Feld (freiflaeche)
                    }
                    if (logicMap[i, j] == 1)
                    {
                        Console.Write("\x1b[93m▓"); //schlangenteil
                    }
                    if (logicMap[i, j] == 4)
                    {
                        Console.Write("\x1b[32m®"); //futter
                    }

                    // raender der map

                    //oben links die ecke
                    if (logicMap[i, j] == 20)
                    {
                        Console.Write("\x1b[31m╔"); //das \x1b ist einfach nur eine farbe (hier ist es rot)
                    }
                    //obere rand
                    if (logicMap[i, j] == 21)
                    {
                        Console.Write("\x1b[31m═"); //rahmen oben und unten
                    }
                    //oben rechts die ecke
                    if (logicMap[i, j] == 22)
                    {
                        Console.Write("\x1b[31m╗");
                    }
                    //links der rand, ohne ecken
                    if (logicMap[i, j] == 23)
                    {
                        Console.Write("\x1b[31m║"); //rahmen links und rechts
                    }
                    //ecke unten links
                    if (logicMap[i, j] == 24)
                    {
                        Console.Write("\x1b[31m╚"); //rahmen links und rechts
                    }
                    //ecke unten rechts
                    if (logicMap[i, j] == 25)
                    {
                        Console.Write("\x1b[31m╝"); //rahmen links und rechts
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
