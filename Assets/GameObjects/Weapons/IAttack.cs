using System;
using UnityEngine;

namespace Assets.GameObjects.Weapons
{
    public interface IAttack
    {
        GameObject InputManager { get; set; }

        int Damage { get; set; }
        float Speed { get; set; }
        float AttackCoolDown { get; set; }

        float Timer { get; set; }

        void Attack();
    }
}
