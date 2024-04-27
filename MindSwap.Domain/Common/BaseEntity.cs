using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModifired { get; set;}
    }
}
