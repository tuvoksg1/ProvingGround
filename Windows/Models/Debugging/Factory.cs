using System.Linq;

namespace Windows.Models.Debugging
{
    public class Factory
    {
        public string Inspect(Car car, string status)
        {
            if (car.Seats?.Count == 0 && car.Wheels?.Count == 0)
            {
                return "No Wheels or Seats";
            }

            if (car.Seats?.Any() ?? false)
            {
                foreach (var seat in car.Seats)
                {
                    return seat.Position;
                }
            }

            if (car.Wheels?.Any() ?? false)
            {
                foreach (var wheel in car.Wheels)
                {
                    return wheel.Position;
                }
            }

            return status;
        }
    }
}
