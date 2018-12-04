using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class NormalGround : Ground
    {
        private void Start()
        {
            Nature = GroundNature.Normal;
        }
    }
}
