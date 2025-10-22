using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Domain.Entities
{
    public class CarDescription
    {
        public Car Car { get; set; }
        public int CarId { get; set; }
        public int CarDescriptionId { get; set; }
        public string Details { get; set; }
        
    }
}
