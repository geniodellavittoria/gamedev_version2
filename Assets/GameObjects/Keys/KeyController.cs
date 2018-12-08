using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.GameObjects.Keys
{
    public class KeyController : MonoBehaviour
    {
        [SerializeField]
        private GameObject KeyPanel;

        [SerializeField]
        private int KeysToFind = 5;

        private int KeysFound = 0;

        public void KeyFound()
        {
            KeysFound++;
            if (AllKeysFound())
            {
                print("All keys found. Find the portal");
            }
        }

        public bool AllKeysFound()
        {
            return KeysToFind == KeysFound;
        }

    }

}