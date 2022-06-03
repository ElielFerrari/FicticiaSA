using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class NewClientDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public bool Estate { get; set; }

        public bool Drives { get; set; }
        public bool HasGlasses { get; set; }
        public bool HasDiabetes { get; set; }
        public bool HasDisease { get; set; }
        public string DiseaseName { get; set; }
    }
}
