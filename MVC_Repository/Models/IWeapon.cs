using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repository.Models
{
    public interface IWeapon
    {
        string Hit(string target);
    }
}
