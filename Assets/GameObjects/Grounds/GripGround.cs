using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class GripGround : Ground
    {
        [SerializeField]
        private int gripValue;

        private void Start()
        {
            Nature = GroundNature.Grip;
            Value = gripValue;
        }
    }
}
