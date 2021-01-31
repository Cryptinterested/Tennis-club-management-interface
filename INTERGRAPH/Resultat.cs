using System;
namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public abstract class Resultat // CLASSE VIDE CAR UN RESULTAT EST SOIT UN RESULTAT EQUIPE SOIT UN RESULTAT SIMPLE
    {
        private int result;
        public Resultat(int res)
        {
            this.result = res;
        }

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
