using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Taxi.Web.Data.Entities
{

    public class TaxiEntity
    {
        public int id { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "The {0} field must have {1} characters.")]
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string plaque { get; set; }

        public ICollection<TripEntity> Trips { get; set; }
    }
}