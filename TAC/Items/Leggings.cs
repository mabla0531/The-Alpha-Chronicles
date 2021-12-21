using Microsoft.Xna.Framework;

namespace TAC
{
    class Leggings : Item
    {
        public Leggings()
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "legs";
            Name = "Leggings";
            TextureRect = new Rectangle(0, 64, 32, 32);
        }
        public Leggings(string name)
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "legs";
            Name = name;
            TextureRect = new Rectangle(0, 64, 32, 32);
        }
    }
}
