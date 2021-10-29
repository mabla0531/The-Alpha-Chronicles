using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC
{
    abstract class Item
    {
        public int HealthMod { get; set; }
        public int DefenseMod { get; set; }
        public int AttackMod { get; set; }

        public string Name { get; set; }
        public Rectangle TextureRect { get; set; }


    }
}
