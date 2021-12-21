using Microsoft.Xna.Framework;

namespace TAC
{
    class Helmet : Item
    {
        public Helmet()
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "head";
            Name = "Helmet";
            TextureRect = new Rectangle(0, 0, 32, 32);
        }
        public Helmet(string name)
        {
            HealthMod = 0;
            DefenseMod = 2;
            AttackMod = 0;
            Weight = 1.5d;
            Slot = "hand";
            Name = name;
            TextureRect = new Rectangle(0, 0, 32, 32);
        }
    }
}
