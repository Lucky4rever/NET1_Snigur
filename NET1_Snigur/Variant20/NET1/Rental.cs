using System;
using System.Collections.Generic;

namespace NET1_Snigur.Variant20.NET1
{
    class Rental
    {
        public string Name = string.Empty;
        public List<Covenant> Covenants = new List<Covenant>();

        public Rental()
        {
            Data.Covenants.ForEach(covenant => { NewCovenant(covenant); });
        }

        public Rental SetName(string Name)
        {
            this.Name = Name;
            return this;
        }

        private void NewCovenant(Covenant covenant)
        {
            bool isFree = true;
            foreach (var thisCovenant in Covenants)
            {
                if (thisCovenant.CarId == covenant.CarId)
                {
                    if (thisCovenant.ReturnDate >= covenant.IssueDate)
                    {
                        isFree = false;
                        break;
                    }
                }
            }

            if (isFree)
            {
                Covenants.Add(covenant);
            }
        }
    }
}
