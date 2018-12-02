using System;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class NormalGround : Ground
    {
        [SerializeField]
        private int _value;

        private void Start()
        {
            Nature = GroundNature.Normal;
        }
    }
}
