using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBeheerV3.Data;

namespace AutoBeheerV3.Controllers
{
    class GebruikerController
    {
        public ObservableCollection<Gebruiker> Gebruikers { get; }

        private AutoBeheerDataContext db;

        public GebruikerController()
        {
            db = new AutoBeheerDataContext();

            Gebruikers = new ObservableCollection<Gebruiker>(db.Gebruikers);
        }

        public void NieuwAuto(Gebruiker gebruiker)
        {
            if (gebruiker != null)
            {
                db.Gebruikers.InsertOnSubmit(gebruiker);

                db.SubmitChanges();

                Gebruikers.Add(gebruiker);
            }
        }

        public void VerwijderAuto(Gebruiker gebruiker)
        {
            if (gebruiker != null)
            {
                db.Gebruikers.DeleteOnSubmit(gebruiker);

                db.SubmitChanges();

                Gebruikers.Remove(gebruiker);
            }
        }

        public void WijzigAuto(Gebruiker gebruiker)
        {
            if (gebruiker != null)
            {
                db.SubmitChanges();
            }
        }
    }
}
