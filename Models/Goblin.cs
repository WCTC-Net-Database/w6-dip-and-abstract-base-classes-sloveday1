using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Goblin : CharacterBase, ILootable
    {
        public string Treasure { get; set; }

        public Goblin(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }
    }
}
