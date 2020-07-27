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
        public int? armeId { get; set; }
    }
}