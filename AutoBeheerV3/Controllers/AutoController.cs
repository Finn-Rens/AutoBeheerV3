using AutoBeheerV3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBeheerV3.Controllers
{ 
    public class AutoController
    {
        public ObservableCollection<Auto> Autos { get; }

        private AutoBeheerDataContext db;

        public AutoController() 
        {
            db = new AutoBeheerDataContext();

            Autos = new ObservableCollection<Auto>(db.Autos);
        }

        public void NieuwAuto(Auto auto) 
        {
            if (auto != null) 
            {
                db.Autos.InsertOnSubmit(auto);

                db.SubmitChanges();

                Autos.Add(auto);
            }
        }

        public void VerwijderAuto(Auto auto) 
        {
            if (auto != null) 
            {
                db.Autos.DeleteOnSubmit(auto);

                db.SubmitChanges();

                Autos.Remove(auto);
            }
        }

        public void WijzigAuto(Auto auto)
        {
            if (auto != null)
            {
                db.SubmitChanges();
            }
        }
    }
}
