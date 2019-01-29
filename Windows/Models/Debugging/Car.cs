using System.Collections.Generic;

namespace Windows.Models.Debugging
{
    public class Car
    {
        public List<Seat> Seats { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Wheelbase Wheelbase { get; set; }
    }
}
