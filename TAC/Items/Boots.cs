using Microsoft.Xna.Framework;

namespace TAC
{
    class Boots : Item
    {
        public Boots()
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "feet";
            Name = "Boots";
            TextureRect = new Rectangle(0, 96, 32, 32);
        }
        public Boots(string name)
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "legs";
            Name = name;
            TextureRect = new Rectangle(0, 96, 32, 32);
        }
    }
}
