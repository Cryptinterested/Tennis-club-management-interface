using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
   public class Cours
    {
        private DateTime datecours;
        private Entraineur responsable;
        private int niveau; // défini par le niveau minimal pour accéder à ce cours

        public Cours(DateTime datecours, Entraineur responsable, int niveau)
        {
            this.datecours = datecours;
            this.responsable = responsable;
            this.niveau = niveau;
        }
        
        public override string ToString()
        {
            return "Date : " + datecours + ", encadrant : " + responsable + ", niveau minimum : " + niveau;
        }

    }
}
