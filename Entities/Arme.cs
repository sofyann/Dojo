using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Arme : Entity
    {
        private long id;
        public long Id { get => this.id; set => this.id = value; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Le nom doit faire entre 2 et 30 caractères.")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required]
        public int Degats { get; set; }
    }
}
