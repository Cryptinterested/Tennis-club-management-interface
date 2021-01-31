using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
   public class Cours
    {
        private DateTime datecours;
        private Entraineur responsable;
        private string niveau; // défini par le niveau minimal pour accéder à ce cours

        public Cours(DateTime datecours, Entraineur responsable, string niveau)
        {
            this.datecours = datecours;
            this.responsable = responsable;
            this.niveau = niveau;
        }
        
        public override string ToString()
        {
            return "Date : " + datecours + "\nEncadrant : " + responsable.Affich() + "\nNiveau minimum : " + niveau;
        }

        public string Niveau { get { return niveau; } }
        public Entraineur Responsable { get { return responsable; } }
        public DateTime DateCours { get { return datecours; } }
    }
}
