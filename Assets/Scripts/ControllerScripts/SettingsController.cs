using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    private int Musicbool = 0;

    [SerializeField]
    private Button musicButton1 , musicButton2;

    [SerializeField]
    private Sprite[] musicIcons;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void MusicOn()
    {
        MusicController.instance.PlayMusic(true);
        musicButton1.interactable = false;
        musicButton2.interactable = true;
    }

    public void MusicOff()
    {
        MusicController.instance.PlayMusic(false);
        musicButton2.interactable = false;
        musicButton1.interactable = true;
    }

    /*public void Music()
    {
        if (GameController.instance.IsMusicOn == false)
        {
            GameController.instance.IsMusicOn = true;
            GameController.instance.Save();
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[0];
        }

        else if (GameController.instance.IsMusicOn == true)
        {
            GameController.instance.IsMusicOn = false;
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[1];
        }
    }*/

    public void RateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.gameaddict.avoid");
    }

    public void ConnectToFB()
    {
        Application.OpenURL("https://www.facebook.com/Gameaddictgames/");
    }
}
