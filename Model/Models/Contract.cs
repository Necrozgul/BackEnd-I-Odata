using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual IList<Contract_Device> Contract_Device_Relations { get; set; }

    }
    public class ContractMap : ClassMapping<Contract>
    {
        public ContractMap()
        {
            Id(x => x.Id, map => map.Generator(Generators.Guid));
            Property(x => x.Name, map => map.Length(150));
            Property(x => x.Startdate, map => map.Length(150));
            Property(x => x.Enddate, map => map.Length(150));
            Property(x => x.Email, map => map.Length(150));
            Property(x => x.Phone, map => map.Length(150));
            Property(x => x.Address, map => map.Length(150));
        }
    }
}
