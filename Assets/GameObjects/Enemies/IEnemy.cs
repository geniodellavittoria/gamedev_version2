using System;
using Assets.GameObjects.GameCharacters;

namespace Assets.GameObjects.Enemies
{
    public interface IEnemy : IGameCharacter
    {
        void Move();
    }
}
