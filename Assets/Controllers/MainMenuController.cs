using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject HeroMenu;
	public void OnPlayClick()
    {
        MainMenu.SetActive(false);
        HeroMenu.SetActive(true);
    }
}
