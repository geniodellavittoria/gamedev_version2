using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.GameObjects.Keys
{
    public class Key : MonoBehaviour
    {
        [SerializeField]
        private GameObject GameManager;

        [SerializeField]
        private GameObject KeyImage;

        private KeyController KeyController;

        private bool Found = false;

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
            if (col.CompareTag("hero") && !Found)
            {
                Found = true;
                KeyController.KeyFound();
                gameObject.SetActive(false);
                var color = KeyImage.GetComponent<Image>().color;
                color.a = 1f;
                KeyImage.GetComponent<Image>().color = color;
            }
        }
    }
}
