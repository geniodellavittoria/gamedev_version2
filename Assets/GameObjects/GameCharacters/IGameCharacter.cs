
using UnityEngine;

namespace Assets.GameObjects.GameCharacters
{
    public interface IGameCharacter
    {
        float Speed { get; set; }
        float Strength { get; set; }

        void TakeDamage(int damage);
    }
}