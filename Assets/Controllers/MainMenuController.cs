using Assets.Controllers;
using Assets.ScriptableObjects;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject HeroMenu;
	public void OnPlayClick()
    {
        MainMenu.SetActive(false);
        var setup = MainMenu.GetComponent<GameSetup>();
        setup.ResetHeroes();
        HeroMenu.SetActive(true);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

}
