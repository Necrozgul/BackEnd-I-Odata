using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public string State { get; set; }
        public int Price { get; set; }

        public DateTime Date { get; set; }

        public string InstallationStatus { get; set; }

        public virtual IList<ContractDevice> Contract_Device_Relations { get; set; }

        public virtual InstallationStatus Status { get; set; }
    }
}