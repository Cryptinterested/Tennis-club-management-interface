using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_POO_DanielJEAN_MarwanMENAA
{
    public class MembreLoisir : Membre
    {
        private List<Cours> participe; // Liste des cours auxquels le membre participe

        public MembreLoisir(string nom, string prenom, DateTime naissance, string adresse, int code_postal, string numtel, TypeSex sexe)
        : base(nom, prenom, naissance, adresse, code_postal, numtel, sexe)
        {
            //membreLoisir créé
            this.CotisationPayee = false; // par defaut ils payent apres inscription
            participe = new List<Cours>();
        }

        public List<Cours> Participe { get { return participe; } set { participe = value; } }

    }
}
