using System;
using UnityEngine;

namespace Assets.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public GameObject player;
        private Vector3 offset;         //Private variable to store the offset distance between the player and camera

        // Use this for initialization
        void Start()
        {
            offset = transform.position - player.transform.position;
        }

        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}


