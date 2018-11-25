﻿using System;
using Assets.GameObjects.GameCharacters;

namespace Assets.GameObjects.Heroes
{
    public interface IHero : IGameCharacter
    {
        float Jumping { get; set; }

        void Jump();
    }
}
