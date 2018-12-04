using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Controllers
{
    public class GameSetup: MonoBehaviour
    {
        public Transform hero;
        public void OnLoadScene()
        {
            Instantiate(hero, new Vector2(0, 0), Quaternion.identity);
        }
    }
}
