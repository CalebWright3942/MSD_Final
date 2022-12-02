using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ManufacturerSerialNumber { get; set; }
        public string OfficeRoomNumber { get; set; }
        public string OfficeLocation { get; set; }
        public string ComputerSpecification { get; set; }
        public string OperatingSystem { get; set; }
        public string OwnerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }




    }
}
