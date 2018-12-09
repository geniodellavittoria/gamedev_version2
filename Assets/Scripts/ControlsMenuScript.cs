using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Controllers;
using System;

namespace Assets.Scripts
{
    public class ControlsMenuScript : MonoBehaviour
    {
        [SerializeField]
        private Button jumpButton;

        [SerializeField]
        private Button right1Button;

        [SerializeField]
        private Button right2Button;

        [SerializeField]
        private Button left1Button;

        [SerializeField]
        private Button left2Button;

        [SerializeField]
        private Button shootButton;

        [SerializeField]
        private Button switchHeroButton;

        [SerializeField]
        private Button attackButton;

        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button restartGameButton;

        private Event keyEvent;
        private Text buttonText;
        private KeyCode newKey;

        private bool waitingForKey;

        private void Start()
        {
            waitingForKey = false;

            jumpButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.jump.ToString();
            right1Button.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.right1.ToString();
            right2Button.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.right2.ToString();
            left1Button.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.left1.ToString();
            left2Button.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.left2.ToString();
            shootButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.shoot.ToString();
            switchHeroButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.switchHero.ToString();
            attackButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.attack.ToString();
            pauseButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.pause.ToString();
            restartGameButton.GetComponentInChildren<Text>().text = InputControlsManager.ControlManager.restartGame.ToString();
        }

        private void OnGUI()
        {
            keyEvent = Event.current;

            if (keyEvent.isKey && waitingForKey)
            {
                newKey = keyEvent.keyCode;
                waitingForKey = false;
            }
        }

        public void KeyAssignment(string keyName)
        {
            if (!waitingForKey)
            {
                StartCoroutine(AssignKey(keyName));
            }
        }

        public void SendText(Text text)
        {
            buttonText = text;
        }

        IEnumerator WaitForKey()
        {
            while (!keyEvent.isKey)
            {
                yield return null;
            }
        }

        IEnumerator AssignKey(string keyName)
        {
            waitingForKey = true;
            yield return WaitForKey();

            switch (keyName)
            {
                case "jump":
                    InputControlsManager.ControlManager.jump = newKey;
                    buttonText.text = InputControlsManager.ControlManager.jump.ToString();
                    PlayerPrefs.SetString("jumpKey", InputControlsManager.ControlManager.jump.ToString());
                    break;
                case "right1":
                    InputControlsManager.ControlManager.right1 = newKey;
                    buttonText.text = InputControlsManager.ControlManager.right1.ToString();
                    PlayerPrefs.SetString("rightKey1", InputControlsManager.ControlManager.right1.ToString());
                    break;
                case "right2":
                    InputControlsManager.ControlManager.right2 = newKey;
                    buttonText.text = InputControlsManager.ControlManager.right2.ToString();
                    PlayerPrefs.SetString("rightKey2", InputControlsManager.ControlManager.right2.ToString());
                    break;
                case "left1":
                    InputControlsManager.ControlManager.left1 = newKey;
                    buttonText.text = InputControlsManager.ControlManager.left1.ToString();
                    PlayerPrefs.SetString("leftKey1", InputControlsManager.ControlManager.left1.ToString());
                    break;
                case "left2":
                    InputControlsManager.ControlManager.left2 = newKey;
                    buttonText.text = InputControlsManager.ControlManager.left2.ToString();
                    PlayerPrefs.SetString("leftKey2", InputControlsManager.ControlManager.left2.ToString());
                    break;
                case "shoot":
                    InputControlsManager.ControlManager.shoot = newKey;
                    buttonText.text = InputControlsManager.ControlManager.shoot.ToString();
                    PlayerPrefs.SetString("shootKey", InputControlsManager.ControlManager.shoot.ToString());
                    break;
                case "switchHero":
                    InputControlsManager.ControlManager.switchHero = newKey;
                    buttonText.text = InputControlsManager.ControlManager.switchHero.ToString();
                    PlayerPrefs.SetString("switchHeroKey", InputControlsManager.ControlManager.switchHero.ToString());
                    break;
                case "attack":
                    InputControlsManager.ControlManager.attack = newKey;
                    buttonText.text = InputControlsManager.ControlManager.attack.ToString();
                    PlayerPrefs.SetString("attackKey", InputControlsManager.ControlManager.attack.ToString());
                    break;
                case "pause":
                    InputControlsManager.ControlManager.pause = newKey;
                    buttonText.text = InputControlsManager.ControlManager.pause.ToString();
                    PlayerPrefs.SetString("pauseKey", InputControlsManager.ControlManager.pause.ToString());
                    break;
                case "restartGame":
                    InputControlsManager.ControlManager.restartGame = newKey;
                    buttonText.text = InputControlsManager.ControlManager.restartGame.ToString();
                    PlayerPrefs.SetString("restartGameKey", InputControlsManager.ControlManager.restartGame.ToString());
                    break;
            }

            yield return null;
        }


    }
}

