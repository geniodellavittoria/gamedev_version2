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
        HeroSelector selector = (HeroSelector)HeroMenu.transform.GetComponentInChildren(typeof(HeroSelector));
        selector.ResetHeroes();
        HeroMenu.SetActive(true);
    }

}
