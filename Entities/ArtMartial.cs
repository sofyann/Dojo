using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ArtMartial : Entity
    {
        private long id;
        public long Id { get => this.id; set => this.id = value; }
        public string Nom { get; set; }

        public virtual List<Samurai> Samurais { get; set; }
    }
}
