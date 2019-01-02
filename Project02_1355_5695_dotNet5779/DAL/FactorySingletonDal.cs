using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactorySingletonDal
    {
        protected static IDAL instance = null;

        protected FactorySingletonDal() { }

        public static IDAL getInstance()
        {
            if (instance == null)
            {
                instance = new Dal_imp();
            }
            return instance;
        }
    }
}
