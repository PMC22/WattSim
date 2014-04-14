using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Research.DynamicDataDisplay.Common;

namespace WattSim_03A.ViewModels
{
    public class ThrottlePosPointCollection : RingArray <ThrottlePosPoint>
    {
        private const int TOTAL_POINTS = 300;

        public ThrottlePosPointCollection()
            : base(TOTAL_POINTS)
        {
        }
    }

    public class ThrottlePosPoint
    {
        public DateTime Date { get; set; }
        
        public double ThrottlePos { get; set; }

        public ThrottlePosPoint(double throttlePos, DateTime date)
        {
            this.Date = date;
            this.ThrottlePos = throttlePos;
        }    }
}
