using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour  {

	public void LoadByIndex(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
}
