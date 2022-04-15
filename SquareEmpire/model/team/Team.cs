using System.Drawing;

namespace SquareEmpire.models.team
{
    public class Team
    {
        public Color Color { get; }

        public Team(Color color)
        {
            Color = color;
        }
    }
}