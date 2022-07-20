using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
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

        public virtual IList<Contract_Device> Contract_Device_Relations { get; set; }


        
    }
    public class DeviceMap : ClassMapping<Device>
    {
        public DeviceMap()
        {
            Id(x => x.Id, map => map.Generator(Generators.Guid));
            Property(x => x.Name, map => map.Length(150));
            Property(x => x.Date, map => map.Length(150));
            Property(x => x.Price, map => map.Length(150));
            Property(x => x.State, map => map.Length(150));

            Table("Device");
        }
    }
}