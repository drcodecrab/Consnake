using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consnake
{

    public enum Bewegungsrichtung
    {
        rechts,
        unten,
        links,
        oben,
    }

    public static class GlobalVars
    {
        private static Bewegungsrichtung aktuelleRichtung;

        public static Bewegungsrichtung AktuelleRichtung
        {
            get { return aktuelleRichtung; }
            set { aktuelleRichtung = value; }
        }
    }
}
