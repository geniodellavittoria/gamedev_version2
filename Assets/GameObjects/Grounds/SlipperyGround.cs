using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class SlipperyGround : Ground
    {
        [SerializeField]
        private int slipperyValue = 0;

        private void Start()
        {
            Nature = GroundNature.Slippery;
            Value = slipperyValue;
        }
    }
}
