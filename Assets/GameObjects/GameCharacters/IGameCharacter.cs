
using UnityEngine;

namespace Assets.GameObjects.GameCharacters
{
    public interface IGameCharacter
    {

        float Speed { get; set; }
        double Life { get; set; }
        double Strength { get; set; }
        bool IsDead { get; set; }

        void Shoot();

        void Die();

        void Move();

        void TakeDamage(double damage);
    }
}