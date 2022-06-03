using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Client
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0,100)]
        public int Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required]
        public bool Estate { get; set; }

        public bool Drives { get; set; }
        public bool HasGlasses { get; set; }
        public bool HasDiabetes { get; set; }
        public bool HasDisease { get; set; }
        
        [StringLength(255)]
        public string DiseaseName { get; set; }
    }
}
