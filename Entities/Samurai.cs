using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Samurai : Entity
    {
        private long id;
        public long Id { get => this.id; set => this.id = value; }
        [Required]
        public int Force { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Le nom doit faire entre 2 et 30 caractères.")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        [Display(Name = "Arts martiaux maitrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; }

        public int Potentiel { get { return (this.Force +(this.Arme == null ? 0 : this.Arme.Degats)) * ((this.ArtMartials == null ? 0 : this.ArtMartials.Count) + 1); } }
    }
}
