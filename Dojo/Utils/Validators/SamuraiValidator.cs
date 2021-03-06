﻿using Dojo.Data;
using Dojo.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; 


namespace Dojo.Utils.Validators
{
    public static class SamuraiValidator
    { 
        public static bool Validate(SamuraiViewModel svm, ModelStateDictionary ModelState, DojoContext context)
        {
            Samurai samurai = context.Samurais.Include(x => x.Arme).Include(x => x.ArtMartials).FirstOrDefault(s => s.Id == svm.Samurai.Id);
            if (context.Samurais.FirstOrDefault(s => s.Nom.Equals(svm.Samurai.Nom) && s.Id != svm.Samurai.Id) != null)
            {
                ModelState.AddModelError("Samurai.Nom", "Un samuraï portant se nom existe déjà.");
            }

            if (svm.Samurai.Force < 0 || svm.Samurai.Force > 1000000)
            {
                ModelState.AddModelError("Samurai.Force", "La force du samurai doit être entre 0 et 1 000 000.");
            }


            if (svm.armeId != null) 
            {
                Arme arme = context.Armes.FirstOrDefault(a => a.Id == svm.armeId);
                Samurai samuraiWithArme;
                if (samurai == null) {
                    samuraiWithArme = context.Samurais.Include(x => x.Arme).Where(s => s.Arme.Id.Equals(arme.Id)).FirstOrDefault();
                } else
                {
                    samuraiWithArme = context.Samurais.Include(x => x.Arme).Where(s => s.Arme.Id.Equals(arme.Id) && s.Id != samurai.Id).FirstOrDefault();
                }
                if (arme == null)
                {
                    ModelState.AddModelError("armeId", "L'arme que vous avez indiqué n'existe pas.");
                } else if (samuraiWithArme != null) 
                {
                    if (samurai == null)
                    ModelState.AddModelError("armeId", "L'arme que vous avez indiqué est déjà utilisée.");
                } else
                {
                    if (svm.Samurai.Id != 0)
                    {
                        samurai.Nom = svm.Samurai.Nom;
                        samurai.Force = svm.Samurai.Force;
                        svm.Samurai = samurai;
                    }
                    svm.Samurai.Arme = arme;
                }
            } else
            {
                if (samurai != null)
                {
                    svm.Samurai = samurai;
                }
                svm.Samurai.Arme = null;
            }

            if (svm.ArtMartiauxIds != null)
            {
                svm.Samurai.ArtMartials = svm.ArtMartials.Where(a => svm.ArtMartiauxIds.Contains(a.Id)).Select(a => a).ToList();
            } else
            {
                svm.Samurai.ArtMartials = null;
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