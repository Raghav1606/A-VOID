using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePasserScript : MonoBehaviour {

    public GameObject coin1, rulesFirstPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RulesFirst()
    {
        GameController.instance.showRulesFirst = false;
        SceneManager.LoadScene("Mainmenu");
    }
}
