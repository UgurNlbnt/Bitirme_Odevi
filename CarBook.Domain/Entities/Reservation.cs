using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int Age { get; set; }
        public int DriveLicenseYear { get; set; }
        public string Description { get; set; }
        public int PickUpLocationID { get; set; }
        [ForeignKey("PickUpLocationID")]
        public Location? PickUpLocation { get; set; }
        public int DropOffLocationID { get; set; }
        [ForeignKey("DropOffLocationID")]
        public Location? DropOffLocation { get; set; }
        public string Status { get; set; }
    }
}
//Eğer bir sınıfta XId adında bir property varsa
//ve aynı sınıfta X adında bir navigation property varsa,
//o zaman XId onun foreign key’idir.