using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Scripts;

namespace Assets.GameObjects.Enemies
{
    public class EnemyShootAttack : ShootAttack
    {

        public void Attack(Direction direction, GameObject hero)
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackCoolDown)
            {
                Shoot(direction, hero);
            }
        }

        protected void Shoot(Direction direction, GameObject hero)
        {
            var shot = ShotController.Shoot(gameObject);
            shot.transform.rotation = transform.rotation;
            shot.transform.position = transform.position + transform.forward;
            shot.GetComponent<Rigidbody2D>().velocity = (hero.transform.position - shot.transform.position).normalized * 2;

            shot.GetComponent<Shot>().ShotSpeed = Speed;
            shot.GetComponent<Shot>().ShotDamage = Damage;
            shot.GetComponent<Shot>().IsEnemyShot = true;

            Shoot(shot);

        }

    }
}
