using Microsoft.Xna.Framework;

namespace TAC
{
    class Chestplate : Item
    {
        public Chestplate()
        {
            HealthMod = 0;
            DefenseMod = 3;
            AttackMod = 0;
            Weight = 2.0d;
            Slot = "chest";
            Name = "Chestplate";
            TextureRect = new Rectangle(0, 32, 32, 32);
        }
        public Chestplate(string name)
        {
            HealthMod = 0;
            DefenseMod = 3;
            AttackMod = 0;
            Weight = 2.0d;
            Slot = "chest";
            Name = name;
            TextureRect = new Rectangle(0, 32, 32, 32);
        }
    }
}
