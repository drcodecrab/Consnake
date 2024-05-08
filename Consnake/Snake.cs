using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consnake
{
    class Snake
    {
        public List<Point> points {  get; set; } = new List<Point>();
        public Point kopf {get; set; }
        Boolean gestorben { get; set; } = true;

        /// <summary>
        /// Wie Gross die Startschlange ist
        /// </summary>
        /// <param name="_snakeStartGroesse"></param>
        public Snake(int _snakeStartGroesse)
        {
            points = new List<Point>();
            kopf = new Point(0, 0);
            CreateSnake(_snakeStartGroesse);
        }

        public void CreateSnake(int _ssg)
        {
            for (int i = 0; i < _ssg; i++)
            {
                points.Add(new Point(4,i));
            }
        }
        public void UpdateSnake()
        {
            kopf = new Point(points[points.Count - 1].x, points[points.Count - 1].y); //der derzeitige kopf
            AddNewSnakeHeadPositionToSnake(GetNewSnakeHeadPosition()); // wandern zur nächsten position 
            kopf = new Point(points[points.Count - 1].x, points[points.Count - 1].y); // der derzeitige kopf hat nun die neue position
        }       

        public Point GetNewSnakeHeadPosition()
        {
            Point newSnakeHeadPosition = new Point(0, 0);

            if (GlobalVars.AktuelleRichtung == Bewegungsrichtung.rechts)
            {
                newSnakeHeadPosition.x = kopf.x;
                newSnakeHeadPosition.y = kopf.y + 1;
            }
            if (GlobalVars.AktuelleRichtung == Bewegungsrichtung.unten)
            {
                newSnakeHeadPosition.x = kopf.x + 1;
                newSnakeHeadPosition.y = kopf.y;
            }
            if (GlobalVars.AktuelleRichtung == Bewegungsrichtung.links)
            {
                newSnakeHeadPosition.x = kopf.x;
                newSnakeHeadPosition.y = kopf.y - 1;
            }
            if (GlobalVars.AktuelleRichtung == Bewegungsrichtung.oben)
            {
                newSnakeHeadPosition.x = kopf.x - 1;
                newSnakeHeadPosition.y = kopf.y;
            }

            return newSnakeHeadPosition;
        }

        public void AddNewSnakeHeadPositionToSnake(Point newSnakeHeadPosi)
        {
            points.Add(newSnakeHeadPosi);
            DeleteTheEndPositionFromSnake();
        }

        public void AddSnakeElement(Point headPosi)
        {
            points.Add(headPosi);
        }

        public void DeleteTheEndPositionFromSnake()
        {
            points.RemoveAt(0);
        }
    }
}
