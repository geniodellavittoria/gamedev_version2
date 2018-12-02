using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class GripGround : Ground
    {
        [SerializeField]
        private int _value;

        private void Start()
        {
            Nature = GroundNature.Grip;
        }
    }
}
