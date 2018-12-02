using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class SlipperyGround : Ground
    {
        [SerializeField]
        private int slipperyValue;

        private void Start()
        {
            Nature = GroundNature.Slippery;
            Value = slipperyValue;
        }
    }
}
