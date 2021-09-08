using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //WatchVideoToEarnExtraCircles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void WatchVideoToEarnExtraCircles()
    {
        AdController.instance.ShowAdVideo();
    }
}
