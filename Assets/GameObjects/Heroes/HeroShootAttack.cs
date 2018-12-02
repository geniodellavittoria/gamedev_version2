using UnityEngine;
using System.Collections;
using Assets.Controllers;
using Assets.GameObjects.Weapons;
using System;
using Assets.Scripts;

namespace Assets.GameObjects.Heroes
{
    public class HeroShootAttack : ShootAttack
    {
        private InputController inputController;

        private void Start()
        {
            base.Start();
            inputController = InputManager.GetComponent<InputController>();
            if (inputController == null)
            {
                Debug.LogError("GameObject does not contain inputController");
            }
            inputController.Shoot += Attack;
        }

        public new void Attack()
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackRate)
            {
                Shoot();
            }
        }

        protected void Shoot()
        {
            var shot = ShotController.Shoot(gameObject);
            shot.transform.rotation = transform.rotation;
            shot.transform.position = transform.position + transform.forward;

            shot.GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;
            /*if (direction == Direction.Right)
            {
            }
            else
            {
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed;
            }*/

            shot.GetComponent<Shot>().ShotSpeed = Speed;
            shot.GetComponent<Shot>().ShotDamage = Damage;
            shot.GetComponent<Shot>().IsEnemyShot = false;

            Shoot(shot);

        }

    }
}
