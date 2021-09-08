using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuController : MonoBehaviour {

    public Text coinText, ScoreText;
    public GameObject rulesfirst;
    public GameObject coin1;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if(GameController.instance.showRulesFirst == true)
        {
            GameController.instance.showRulesFirst = false;
            SceneManager.LoadScene("RulesFirst");
        }
    }

    void Update()
    {
        coinText.text = " " + GameController.instance.coins;
        ScoreText.text = " " + GameController.instance.highScore + " %";
    }

    

    public void ScoreMenu()
    {
        SceneManager.LoadScene("Scores");
    }

    public void ShopMenu()
    {
        SceneManager.LoadScene("Shop");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void MaximMenu()
    {
        SceneManager.LoadScene("Maxim");
    }

    public void RulesMenu()
    {
        SceneManager.LoadScene("Rules");
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void InfoMenu()
    {
        SceneManager.LoadScene("Aboutus");
    }

    /*public void IAPNoAds()
    {
        IAPController.instance.BuyNoAds();
    }*/
}