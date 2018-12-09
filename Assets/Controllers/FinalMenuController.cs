using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenuController : MonoBehaviour {
    public GameObject FinalMenu;
	public void OnBackButtonClick()
    {
        // load main menu scene
        SceneManager.LoadScene(0);
    }

    public void OnHighscoreButtonClick()
    {
        // load highscore scene
        SceneManager.LoadScene(0);
    }
}
