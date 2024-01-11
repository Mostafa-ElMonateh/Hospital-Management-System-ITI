using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    class Consultant : BaseClass
    {
        #region Fields
        private string department; 
        #endregion

        #region Properties
        public string Department
        {
            get => department;
            set => department = value;
        } 
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
