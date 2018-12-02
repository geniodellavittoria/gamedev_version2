﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
    class Hero : ScriptableObject
    {
        public string Name;
        public int Jumping;
        public int Speed;
        public int Strength;
        public int Life;
        public int Toughness;
    }
}
