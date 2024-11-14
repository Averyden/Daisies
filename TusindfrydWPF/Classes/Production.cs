using Daisies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Classes
{
    public class Production
    {
        public DateTime StartDate { get; set; }

        public int StartAmt { get; set; }

        public int ExpectedAmt { get; set; }
        public bool IsCompleted { get; set; }

        //implicit constructor here

        public void StartProd(string greenHouseName, string prodTray, FlowerSort flower, int startAmt)
        { // Start date, start amount and expected date.
            StartDate = DateTime.Now;
            StartAmt = startAmt;
            // 


        }
    }
}
