using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm.OtherFiles
{
    public static class DB
    {
        static MvvmDzContext dataBase;

        public static MvvmDzContext instance
        {
            get
            {
                if (dataBase == null)
                    dataBase = new MvvmDzContext();
                return dataBase;
            }
        }
    }
}
