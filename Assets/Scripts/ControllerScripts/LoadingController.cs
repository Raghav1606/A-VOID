using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {

	void Start () {
        
       StartCoroutine(LoadingScreen());

	}
	
    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("Mainmenu");
    }
}
