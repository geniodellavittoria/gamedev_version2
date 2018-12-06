using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.Keys
{
    public class KeyController : MonoBehaviour
    {

        [SerializeField]
        private int KeysToFind = 1;

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