using UnityEngine;
using System.Collections;

namespace Assets.Controllers
{
    public class InputControlsManager : MonoBehaviour
    {
        public KeyCode jump { get; set; }
        public KeyCode right1 { get; set; }
        public KeyCode right2 { get; set; }
        public KeyCode left1 { get; set; }
        public KeyCode left2 { get; set; }
        public KeyCode shoot { get; set; }
        public KeyCode switchHero { get; set; }
        public KeyCode attack { get; set; }
        public KeyCode pause { get; set; }
        public KeyCode restartGame { get; set; }

        public static InputControlsManager ControlManager;

        private void Awake()
        {
            if (ControlManager == null)
            {
                DontDestroyOnLoad(gameObject);
                ControlManager = this;
            }
            else if (ControlManager != this)
            {
                Destroy(gameObject);
            }

            jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
            right1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey1", "D"));
            right2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey2", "RightArrow"));
            left1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey1", "A"));
            left2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey2", "LeftArrow"));
            shoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey", "S"));
            switchHero = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("switchHeroKey", "Tab"));
            attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "F"));
            pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
            restartGame = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("restartGame", "R"));
        }
    }
}
