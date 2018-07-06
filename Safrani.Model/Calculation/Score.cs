using System.Collections.Generic;

namespace Safrani.Model.Calculation
{
    public partial class Mark {
        public static Mark Nope = new Mark(-1, 6);
        public static Mark Bad = new Mark(-1,3);
        public static Mark Meh = new Mark(-1,1);
        public static Mark Neutral = new Mark(0,0);
        public static Mark Yeah = new Mark(1,1);
        public static Mark Good = new Mark(1,3);
        public static Mark Top = new Mark(1,6);
        public static Mark Best = new Mark(1,10);
    }

    public partial class Mark
    {
        public Mark(float c, uint v)
        {
            Measure = v;
            Coefficient = c;
        }

        public static implicit operator int(Mark m)
        {
            return (int)(m.Measure * m.Coefficient);
        }

        public uint Measure { get; set; }
        public float Coefficient { get; set; }
    }

    public enum Position { Front, Side, Diagonal }
}
