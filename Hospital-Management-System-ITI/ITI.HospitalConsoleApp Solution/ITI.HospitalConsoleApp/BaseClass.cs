using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    abstract class BaseClass
    {
        #region Fields
        private int id;
        private string name;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        } 
        #endregion

        #region Methods
        public virtual void Create() { }
        public virtual void Read() { }
        public virtual void Search() { }
        public virtual void Update() { }
        public virtual void Delete() { }

        #endregion


    }
}
