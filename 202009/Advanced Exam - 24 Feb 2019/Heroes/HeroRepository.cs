using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count { get { return this.data.Count; } }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero targetHero = this.data.FirstOrDefault(n => n.Name == name);

            this.data.Remove(targetHero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            int highestStrength = this.data.Max(s => s.Item.Strength);

            return this.data.FirstOrDefault(s => s.Item.Strength == highestStrength);
        }

        public Hero GetHeroWithHighestAbility()
        {
            int highestAbility = this.data.Max(a => a.Item.Ability);

            return this.data.FirstOrDefault(a => a.Item.Ability == highestAbility);
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int highestIntelligence = this.data.Max(i => i.Item.Intelligence);

            return this.data.FirstOrDefault(i => i.Item.Intelligence == highestIntelligence);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
