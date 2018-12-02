using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;

namespace Assets.GameObjects.Enemies
{
    public class EnemyNearFieldAttack : NearFieldAttack
    {
        public void Attack()
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackRate)
            {
                AttackNearField();
            }
        }

    }
}
