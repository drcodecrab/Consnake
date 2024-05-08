using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Consnake
{
    class GameManager
    {

        const int gameSpeed = 70; // je kleiner der wert, desto schneller, (milliseconds bis zum nächsten gamestep)
        const int gameHoehe = 18;
        const int gameBreite = 28;
        const int snakeGroesse = 5; //die anfangsgroesse der schlange

        TimeSpan stepIntervall; //die gemerkte zeit bis zum naechsten gamestep
        Stopwatch stopwatch; //ein counter fuer echte zeit

        Map map;
        Snake schlange;
        public List<Food> futter; //was die schlange so essen kann
        InputManager inputManager;  //fuer die usereingabe

        public GameManager() { }

        public void StartNewGame()
        {
            Initialze_SystemGameData();
            Initialize_InsideGameData();

            RunGame();
        }

        public void Initialze_SystemGameData()
        {
            inputManager = new InputManager();
            stepIntervall = TimeSpan.FromMilliseconds(gameSpeed);
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void Initialize_InsideGameData() // z.b wenn spiel resettet werden soll... einfach hier aufrufen
        {
            map = new Map(gameHoehe, gameBreite);
            schlange = new Snake(snakeGroesse);
            futter = new List<Food>();

            GlobalVars.AktuelleRichtung = Bewegungsrichtung.rechts;
        }

        public void RunGame()
        {
            while (true)
            {
                inputManager.GetUserInput();

                if (stopwatch.Elapsed >= stepIntervall)
                {
                    UpdateGame();
                    DrawGame();
                    stopwatch.Restart();
                }
            }
        }

        public void UpdateGame()
        {
            PruefeSchlangenkopfMitSchlange();// pruefe ob schlange sich selbst trifft
            map.CreateMap(); //wir erstellen jedes mal zuerst eine Leere Map.
            map.CreateMapRahmen();//wir ziehen einmal außen einen rahmen
            futter.RemoveAll(f => f.gegessen); //entferne alles gegessenes futter aus der liste
            CreateFood(); //erstelle essen wenn keins mehr da ist
            map.UpdateMapWithFood(futter); //wir uebergeben das futter der karte zum eintragen in die logikmap
            PruefeSchlangenkopfFrisstFutter();
            schlange.UpdateSnake(); // bewegt die schlange immer um eine stelle weiter innerhalb der Liste der schlange (nicht auf der logikmap (Map) ), aktualisiert auch die daten des kopfes der schlange
            
            if (IsSnakeInsideMap(schlange.kopf)) //pruefen ob der schlangenkopf(x,y) sich innerhalb der map(x,y) befindet, (also innerhalb der logikMap))) wenn ja dann....
            {
                map.UpdateMapWithSnake(schlange.points); //uebergeben wir der logikmap die schlangenpositionen, (da der kopf sich innerhalb des mehrdimensionalen arrays der map befindet)
            }
            else //wenn nicht... dann ist die schlange gegen die wand gekommen, 
            {
                Initialize_InsideGameData(); // dann starten wir hier neu...
            }

        }

        public Boolean IsSnakeInsideMap(Point _snakeHead) // auch hier haben die werte jeweils +1 fuer oben und links, und -1 fuer rechts und unten, wegen dem rand
        {
            if (_snakeHead.y > map.columns - 2) //schlange kommt rechts außerhalb der map
            {
                Console.Beep(40, 800); //deadsound
                return false;
            }

            if (_snakeHead.y < 1) //schlange kommt links außerhalb der map
            {
                Console.Beep(40, 800); //deadsound
                return false;
            }

            if (_snakeHead.x > map.rows - 2) //schlange kommt rechts außerhalb der map
            {
                Console.Beep(40, 800); //deadsound
                return false;
            }

            if (_snakeHead.x < 1) //schlange kommt oben aus der map
            {
                Console.Beep(40, 800); //deadsound
                return false;
            }

            return true;
        }

        public void PruefeSchlangenkopfFrisstFutter()
        {
            foreach (var f in futter)
            {
                if (schlange.kopf.x == f.point.x && schlange.kopf.y == f.point.y)
                {
                    f.gegessen = true;
                    schlange.AddSnakeElement(schlange.kopf);
                    Console.Beep(400, 10); //schlucksound
                }
            }
        }

        public void PruefeSchlangenkopfMitSchlange()
        {
            for (int i = 0; i < schlange.points.Count - 2; i++) //minus 2 weil wir den kopf selbst nicht mit dem kopf pruefen wollen, -1 waere der kopf, also ein element dahinter
            {
                if (schlange.kopf.x == schlange.points[i].x && schlange.kopf.y == schlange.points[i].y)
                {
                    Initialize_InsideGameData();
                    Console.Beep(40, 800); //deadsound
                }
            }
        }

        public void CreateFood()
        {
            Random rnd = new Random();

            if (futter.Count < 1)
            {
                futter.Add(new Food(rnd.Next(1, gameHoehe - 2), rnd.Next(1, gameBreite - 2))); //+1 statt 0 , und -1 extra beim bis, da wir keine futter im aussenrand haben wollen
            }

        }

        public void DrawGame()
        {
            Console.WriteLine("\x1b[37mConsnake by Codecrab");
            map.Draw();
            Console.WriteLine("\n"+ "\x1b[37mSchlangenlaenge: " + schlange.points.Count);
        }

    }
}
