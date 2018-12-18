using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;

namespace Assets.GameObjects.Enemies
{
    public class EnemyNearFieldAttack : NearFieldAttack
    {

        private void Update()
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackCoolDown)
            {
                AttackNearField();
            }
        }

    }
}
