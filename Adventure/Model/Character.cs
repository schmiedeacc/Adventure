using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Model
{
    public class Character : Item
    {
        public Vector2 Velocity
        {
            get;
            set;
        }

        public Character()
        {

        }

    }
}
