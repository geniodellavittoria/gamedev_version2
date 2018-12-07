using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.GameObjects.Keys
{
    public class Portal : MonoBehaviour
    {

        [SerializeField]
        private GameObject GameManager;
        private KeyController KeyController;
        private void Start()
        {
            KeyController = GameManager.GetComponent<KeyController>();
            if (KeyController == null)
            {
                print("Defined GameManager does not contain any KeyController");
            }
        }

        private void Update()
        {
            if (KeyController.AllKeysFound())
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                print("You won");
            }
        }
    }
}
