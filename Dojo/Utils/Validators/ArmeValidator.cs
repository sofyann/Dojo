using Dojo.Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dojo.Utils.Validators
{
    public static class ArmeValidator
    {
        public static bool Validate(Arme arme, ModelStateDictionary ModelState, DojoContext context)
        {
            if (context.Armes.FirstOrDefault(a => a.Nom.Equals(arme.Nom) && a.Id != arme.Id) != null)
            {
                ModelState.AddModelError("Nom", "Une arme portant se nom existe déjà.");
            }

            if (arme.Degats < 0 || arme.Degats > 1000000)
            {
                ModelState.AddModelError("Degats", "Les dégats de l'arme doivent faire entre 0 et 1 000 000.");
            }


            if (ModelState.IsValid)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}