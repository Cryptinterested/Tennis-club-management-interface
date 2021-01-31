﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public abstract class Membre : Personne, IComparable
    {
        private int numlicence;
        private bool cotisation_payee;
        private List<Cours> reserves;
        

        public int Numlicence { get { return numlicence; } set { numlicence = value; } }
        public bool CotisationPayee { get { return cotisation_payee; } set { cotisation_payee = value; } }

        public Membre(string nom, string prenom, DateTime naissance, string adresse, int code_postal,string  numtel, TypeSex sexe )
        : base (nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            this.cotisation_payee = false;
        }

        public bool Equals(Membre m)
        {
            return m.Nom == nom && m.Prenom == prenom && m.Naissance == naissance && m.Adresse == modifierAdresse && m.CodePostal == CodePostal && m.NumTel == NumTel && m.Sexe == Sexe;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Numéro de licence : " + numlicence + "\n Cotisation payée : " + cotisation_payee;
        }

        public int CompareTo(Object obj)
        {
            if (this.Nom == ((Membre)obj).Nom) return this.Prenom.CompareTo(((Membre)obj).Prenom);
            else return this.Nom.CompareTo(((Membre)obj).Nom);
        }

        public void modifierAdresse(string adresse, int code_postale)
        {
            this.Adresse = adresse;
            this.CodePostal = code_postale;
        }

        public void modifierTelephone(string num)
        {
            this.NumTel = num;
        }

        public void payerCotis()
        {
            this.cotisation_payee = true;
        }
    }
}
