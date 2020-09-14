using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Personal.Models
{
    public enum Place
    {
        Universidad = 1,
        Colegio = 2,
        Escuela = 3,
        Instituo = 4,
        Normal = 5
    }
    public class poma
    {
        [Key]
        public int poma_ID { get; set; }

        
        [DisplayName("Full Name")]
        [Required]
        [StringLength(24, ErrorMessage = "This must between {0} and {1}", MinimumLength = 2)]
        public string Friendof_poma { get; set; }

        [Required]
        public Place Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

    }
}