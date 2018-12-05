using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenuController : MonoBehaviour {
    private LoadSceneOnClick loadScene = new LoadSceneOnClick();
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
