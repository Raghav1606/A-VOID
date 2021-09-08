using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if(GameController.instance.canShowAds == true)
        {
            WatchVideoToEarnExtraCircles();
        }
        
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
