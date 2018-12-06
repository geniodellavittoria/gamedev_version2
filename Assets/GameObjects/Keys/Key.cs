using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.Keys
{
    public class Key : MonoBehaviour
    {
        [SerializeField]
        private GameObject GameManager;
        private KeyController KeyController;

        private void Start()
        {
            KeyController = GameManager.GetComponent<KeyController>();
            if (KeyController == null)
            {
                print("GameManager contains no Keycontroller");
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                KeyController.KeyFound();
                gameObject.SetActive(false);
            }
        }
    }
}
