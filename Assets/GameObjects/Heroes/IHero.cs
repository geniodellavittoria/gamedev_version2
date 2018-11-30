using System;
using Assets.GameObjects.GameCharacters;

namespace Assets.GameObjects.Heroes
{
    public interface IHero : IGameCharacter
    {
        float AttackDmg { get; set; }
        float ShootDmg { get; set; }
        float Jumping { get; set; }

        void Jump();

        void MoveRight();
        void MoveLeft();

        void Attack();
    }
}
