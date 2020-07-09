using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParexelDevTest.Models
{
    public class BaseTaskModel
    {
        [Key]
        public int TaskID { get; set; }
    }
}
