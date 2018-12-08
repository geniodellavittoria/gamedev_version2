using UnityEngine;
using System.Collections;
using Assets.Controllers;
using Assets.GameObjects.Weapons;
using System;
using Assets.Scripts;
using UnityEngine.UI;

namespace Assets.GameObjects.Heroes
{
    public class HeroShootAttack : ShootAttack
    {
        [SerializeField]
        private Text AmmoText;

        private int maximumAmmo;

        private int currentAmmo;

        private InputController inputController;

        private Direction direction = Direction.Right;

        private new void Start()
        {
            base.Start();
            inputController = InputManager.GetComponent<InputController>();
            if (inputController == null)
            {
                Debug.LogError("GameObject does not contain inputController");
            }
            inputController.MoveLeft += () => direction = Direction.Left;
            inputController.MoveRight += () => direction = Direction.Right;
            inputController.Shoot += Attack;

        }

        public void InitializeWithAmmo(int Ammo)
        {
            maximumAmmo = Ammo;
            currentAmmo = Ammo;
            UpdateAmmoText();
        }

        public void AddAmmo(int value)
        {
            currentAmmo += value;
            if (currentAmmo > maximumAmmo)
            {
                currentAmmo = maximumAmmo;
            }
            UpdateAmmoText();
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
            if (currentAmmo == 0)
            {
                return;
            }
            var shot = ShotController.Shoot(gameObject);
            shot.transform.rotation = transform.rotation;
            shot.transform.position = transform.position + transform.forward;

            if (direction == Direction.Right)
            {
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;
            }
            else
            {
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed;
            }

            shot.GetComponent<Shot>().ShotSpeed = Speed;
            shot.GetComponent<Shot>().ShotDamage = Damage;
            shot.GetComponent<Shot>().IsEnemyShot = false;

            Shoot(shot);

            currentAmmo--;
            UpdateAmmoText();

        }

        private void UpdateAmmoText()
        {
            AmmoText.text = string.Format("{0}/{1}", currentAmmo, maximumAmmo);
            if (currentAmmo == 0)
            {
                AmmoText.color = Color.red;
            }
        }
    }
}
