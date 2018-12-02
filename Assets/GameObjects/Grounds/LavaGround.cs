using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class LavaGround : Ground
    {
        [SerializeField]
        private int _value;

        public LavaGround()
        {
            Nature = GroundNature.Lava;
        }
    }
}
