using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    class Patient : BaseClass
    {
        #region Fields
        private int age; 
        #endregion

        #region Properties
        public int Age {get => age; set => age = value;} 
        #endregion

        #region Methods
        public override void Create() { }
        public override void Read() { }
        public override void Update() { }
        public override void Delete() { }
        public override void Search() { } 
        #endregion
    }
}
