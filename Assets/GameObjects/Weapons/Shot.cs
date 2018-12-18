using System;
using UnityEngine;

namespace Assets.GameObjects.Weapons
{
    public class Shot : MonoBehaviour
    {
        public bool IsEnemyShot { get; set; }
        [SerializeField]
        public int ShotDamage { get; set; }

        public float ShotSpeed { get; set; }
        public Vector3 Position { get; set; }
        public GameObject Shooter { get; set; }
        [SerializeField]
        private ParticleSystem explosionPrefab;

        private ParticleSystem Explosion = null;

        public Shot(Vector3 position, bool isEnemyShot, int shotDamage, float shotSpeed)
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

        public void Start()
        {
            //transform.position = Position;
            ShotSpeed = 1;
        }

        public void Move()
        {
            transform.position += Vector3.forward * ShotSpeed * Time.deltaTime;
        }

        private void Update()
        {
            Move();
        }

        void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == Shooter || (!IsEnemyShot && col.gameObject.CompareTag("hero")) || col.gameObject.CompareTag("bonus") ||
            (!col.isTrigger && !col.gameObject.CompareTag("ground")))
            {
                return;
            }
            if (Explosion == null)
            {
                Explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                Explosion.transform.parent = GameObject.Find("Particles").transform;
            }
            Explosion.transform.position = gameObject.transform.position;
            Explosion.Play();
            gameObject.SetActive(false);
            if (col.gameObject.CompareTag("hero"))
            {
                col.gameObject.SendMessageUpwards("TakeDamage", this.ShotDamage);
            }
        }
    }
}
