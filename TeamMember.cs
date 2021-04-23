using System;

namespace heist
{
    public class TeamMember
    {
        public string Name { get; set; }

        public int SkillLevel { get; set; }

        public double CourageFactor { get; set; }

        public TeamMember(string name, int skillLevel, double courage)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courage;
        }
    }
}
