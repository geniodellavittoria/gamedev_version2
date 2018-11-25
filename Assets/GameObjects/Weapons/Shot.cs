using System;
using UnityEngine;

namespace Assets.GameObjects.Weapons
{
    public class Shot : MonoBehaviour
    {
        public bool IsEnemyShot { get; set; }
        public float ShotDamage { get; set; }
        public float ShotSpeed { get; set; }
        public Vector3 Position { get; set; }

        public Shot(Vector3 position, bool isEnemyShot, float shotDamage, float shotSpeed)
        {
            Position = position;
            IsEnemyShot = isEnemyShot;
            ShotDamage = shotDamage;
            if (shotSpeed <= 0)
            {
                ShotSpeed = 1;
            }
            else
            {
                ShotSpeed = shotSpeed;
            }

        }

        public Shot()
        {
            ShotSpeed = 1;
        }

        private void Start()
        {
            //transform.position = Position;
            ShotSpeed = 1;
        }

        public void Move()
        {
            transform.localPosition -= new Vector3(-ShotSpeed, 0) * Time.deltaTime;
        }

        private void Update()
        {
            Move();
        }
    }
}
