﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceKey { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public string State { get; set; }
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Contract Contract { get; set; }
        //public int ContractId { get; set; }
    }
}