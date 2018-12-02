using UnityEngine;
using System.Collections;

namespace Assets.GameObjects.Grounds
{
    public class Ground : MonoBehaviour, IGround
    {
        [SerializeField]
        private GameObject hero;
        private int _value;
        private GroundNature _nature;

        public GroundNature Nature
        {
            get
            {
                return _nature;
            }

            set
            {
                _nature = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public GameObject Hero
        {
            get
            {
                return hero;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
