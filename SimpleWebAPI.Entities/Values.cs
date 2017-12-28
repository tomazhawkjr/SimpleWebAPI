using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleWebAPI.Entities
{
    [Table("Cliente")]
    public class Values
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
