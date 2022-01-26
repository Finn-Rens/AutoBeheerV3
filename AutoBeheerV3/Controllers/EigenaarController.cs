using AutoBeheerV3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBeheerV3.Controllers
{
    public class EigenaarController
    {
        public ObservableCollection<Eigenaar> Eigenaars { get; }

        private AutoBeheerDataContext db;

        public EigenaarController()
        {
            db = new AutoBeheerDataContext();

            Eigenaars = new ObservableCollection<Eigenaar>(db.Eigenaars);
        }

        public void NieuwEigenaar(Eigenaar eigenaar) 
        {
            if (eigenaar != null) 
            {
                db.Eigenaars.InsertOnSubmit(eigenaar);

                db.SubmitChanges();

                Eigenaars.Add(eigenaar);
            }
        }

        public void VerwijderEigenaar(Eigenaar eigenaar) 
        {
            if (eigenaar != null)
            {
                db.Eigenaars.DeleteOnSubmit(eigenaar);

                db.SubmitChanges();

                Eigenaars.Remove(eigenaar);
            }
        }

        public void WijzigEigenaar(Eigenaar eigenaar) 
        {
            if (eigenaar != null)
            {
                db.SubmitChanges();
            }
        }
    }
}
