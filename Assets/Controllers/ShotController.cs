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

        public List<GameObject> Shots = new List<GameObject>();

        public void Shoot(GameObject shot)
        {
            Shots.Add(shot);
            //Shots.Add(new Shot(position, isEnemyShot, shotDamage, shotSpeed));
        }

        public void RemoveShootsOutOfScreen()
        {

        }


    }
}
