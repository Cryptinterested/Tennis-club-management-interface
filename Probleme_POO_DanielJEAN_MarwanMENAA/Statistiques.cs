using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    class Statistiques
    {
        private Club club_tennis;

        public Club ClubTennis { get { return club_tennis; } }

        public delegate int Operation();
        public int Affichage(Operation o)
        {
            return o();
        }
    }
}
