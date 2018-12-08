using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour  {

	public void LoadByIndex(int index)
    {
        if (index == 1)
        {

        }
        SceneManager.LoadScene(index);
    }
}
