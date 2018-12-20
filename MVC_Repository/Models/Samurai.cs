using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Repository.Models
{
    public class Samurai
    {
        readonly IWeapon weapon;
        public Samurai(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public string Attack(string target)
        {
            return this.weapon.Hit(target);
        }
    }
}