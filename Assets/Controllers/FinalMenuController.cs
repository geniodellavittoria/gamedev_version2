using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenuController : MonoBehaviour {
    public GameObject FinalMenu;
    private SceneController loadScene = new SceneController();
	public void OnBackButtonClick()
    {
        // load main menu scene
        loadScene.LoadByIndex(0);
    }

    public void OnHighscoreButtonClick()
    {
        // load highscore scene
        loadScene.LoadByIndex(0);
    }
}
