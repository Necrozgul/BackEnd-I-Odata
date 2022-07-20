using Models;
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
    public class Contract_Device_Relation
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public virtual Contract Contract { get; set; }
            public int ContractId { get; set; }

            public virtual Device Device { get; set; }
            public int DeviceId { get; set; }
    }
}
