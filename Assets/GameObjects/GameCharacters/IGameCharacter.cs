
using UnityEngine;

namespace Assets.GameObjects.GameCharacters
{
    public interface IGameCharacter
    {

        float Speed { get; set; }
        float Life { get; set; }
        float Strength { get; set; }
        bool IsDead { get; set; }

        void Shoot();

        void Die();

        void Move();

        void TakeDamage(float damage);
    }
}