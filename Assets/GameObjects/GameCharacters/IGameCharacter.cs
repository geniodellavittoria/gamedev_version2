
using UnityEngine;

namespace Assets.GameObjects.GameCharacters
{
    public interface IGameCharacter
    {

        float Speed { get; set; }
        float Strength { get; set; }
        int ShotDmg { get; set; }
        float ShotSpeed { get; set; }

        void Shoot();

        void Move();

        void TakeDamage(int damage);
    }
}