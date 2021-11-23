using Microsoft.Xna.Framework;

namespace TAC
{
    class Sword : Item
    {
        public Sword()
        {
            HealthMod = 0;
            DefenseMod = 0;
            AttackMod = 2;
            Weight = 1.5d;
            Slot = "hand";
            Name = "Sword";
            TextureRect = new Rectangle(0, 128, 32, 32);
        }
        public Sword(string name)
        {
            HealthMod = 0;
            DefenseMod = 0;
            AttackMod = 2;
            Weight = 1.5d;
            Slot = "hand";
            Name = name;
            TextureRect = new Rectangle(0, 128, 32, 32);
        }
    }
}
