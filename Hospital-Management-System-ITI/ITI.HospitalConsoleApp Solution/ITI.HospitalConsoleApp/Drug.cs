using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    class Drug : BaseClass
    {
        #region Fields
        private int dose; 
        #endregion

        #region Properties
        public int Dose { get => dose; set => dose = value; } 
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
