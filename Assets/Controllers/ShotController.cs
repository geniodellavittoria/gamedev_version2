using System.Collections;
using System.Collections.Generic;
using Assets.GameObjects.Weapons;
using UnityEngine;

namespace Assets.Controllers
{

    public class ShotController : MonoBehaviour
    {
        [SerializeField]
        private Camera Camera { get; set; }

        [SerializeField]
        private GameObject Shot;

        [SerializeField]
        private int numberOfShots = 100;

        private List<GameObject> ShotPool = new List<GameObject>();

        public List<GameObject> Shots = new List<GameObject>();


        private void Start()
        {
            for (int i = 0; i < numberOfShots; i++)
            {
                var shot = Instantiate(Shot, Vector3.zero, Quaternion.identity);
                shot.transform.parent = GameObject.Find("Shots").transform;
                shot.SetActive(false);
                ShotPool.Add(shot);
            }
        }

        public void Shoot(GameObject shooter)
        {
            GameObject temp = ShotPool.Find(go => go.activeInHierarchy == false);
            if (temp != null)
            {
                temp.transform.position = shooter.transform.position;
                temp.SetActive(true);
            }
        }

        /*public void Shoot(GameObject shot)
        {
            Shots.Add(shot);
            //Shots.Add(new Shot(position, isEnemyShot, shotDamage, shotSpeed));
        }*/

        public void RemoveShootsOutOfScreen()
        {

        }


    }
}
