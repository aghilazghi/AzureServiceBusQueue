using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzureServiceBusQueue.Shared.Models
{
    public class CabinetOrder
    {
        [Required]
        public string MaterialType { get; set; }
        public string DoorSepcification { get; set; }
        public int NumberOfDoors { get; set; }
        public string DrawerSepcification { get; set; }
        public int NumberOfDrawers { get; set; }
        public decimal Price { get; set; }
    }
}
