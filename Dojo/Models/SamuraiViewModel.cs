using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dojo.Models
{
    public class SamuraiViewModel
    {
        public Samurai Samurai { get; set; }
        public List<Arme> armes { get; set; }
        public List<ArtMartial> ArtMartials { get; set; }
        [Display(Name = "Arme")]
        public long? armeId { get; set; }
        [Display(Name = "Arts martiaux maitrisés")]
        public List<long> ArtMartiauxIds { get; set; }
    }
}