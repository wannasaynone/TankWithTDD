using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTank
{
    public class Tank
    {
        public struct Stats
        {
            public Vector3 Position { get; private set; }
            public int HP { get; private set; }
            public int Attack { get; private set; }

            public Stats(Vector3 startPosition, int startHP, int startAttack)
            {
                Position = startPosition;
                HP = startHP;
                Attack = startAttack;
            }
        }

        public Stats CurrentStats { get; private set; }

        public Tank(Vector3 startPosition, int startHP, int startAttack)
        {
            CurrentStats = new Stats(startPosition, startHP, startAttack);
        }
    }
}
