using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneController : MonoBehaviour {

    public GameObject BackButton;
	public void OnAnimationEnded()
    {
        BackButton.SetActive(true);
    }
}
