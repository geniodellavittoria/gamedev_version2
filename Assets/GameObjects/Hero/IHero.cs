using System;
using Assets.GameObjects.GameCharacter;

namespace Assets.GameObjects.Hero
{
    public interface IHero : IGameCharacter
    {
        float Jumping { get; set; }

        void Jump();
    }
}
