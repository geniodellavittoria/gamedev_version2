using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public Text HighScoreName;
    public Text HighScoreValue;
    public Text HighScoreDate;

    void Update()
    {
        HighScoreName.text = PlayerPrefs.GetString("HighScoreName");
        HighScoreValue.text = PlayerPrefs.GetInt("HighScoreValue").ToString();
        HighScoreDate.text = PlayerPrefs.GetString("HighScoreDate");
    }

}
