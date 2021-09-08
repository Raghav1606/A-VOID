using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

    public static ShopController instance;

    public GameObject CirclePanel,EarnPanel,WatchVideoPanel;

    public int flaggy = 0;

    //coin text
    public Text coinText,watchVideoText;

    public GameObject Circlemain; 

    // keeping track which player is unlocked
    public bool[] players;

    // Selected color changes to red
    public Image[] SelectedButtonColor; 

    // reference to price tags in scene
    public GameObject[] priceTags;

    // reference to buy player panel in scene
    public GameObject buyPlayerPanel;

    // reference to yes button from buy player panel
    public Button yesBtn;

    public Sprite[] sprites;

    // reference to buy player text in the scene
    public Text buyPlayerText;

    public GameObject coinShop;

    // Use this for initialization
    void Start()
    {
        InitializePlayerMenuController();
        //Debug.Log("1");
    }

    void InitializePlayerMenuController()
    {
        coinText.text = "" + GameController.instance.coins;

        players = GameController.instance.players;
        
        SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true ;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == true)
            {
                priceTags[i].gameObject.SetActive(false);
            }
        }
    }

    public void SpiralPlayerButton()
    {

        if (GameController.instance.selectedPlayer != 0)
        {
            SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
            GameController.instance.selectedPlayer = 0;
            GameController.instance.Save();
            SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
            Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[0];
            
        }
    }

    public void MoonPlayerButton()
    {

        if (players[1] == true)
        {

            if (GameController.instance.selectedPlayer != 1)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 1;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[1];
                 
            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(1));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // moon player

    public void FlowerPlayerButton()
    {

        if (players[2] == true)
        {

            if (GameController.instance.selectedPlayer != 2)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 2;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[2];

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(2));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // flower player

    public void SmileyPlayerButton()
    {

        if (players[3] == true)
        {

            if (GameController.instance.selectedPlayer != 3)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 3;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[3];

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(3));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // smiley player

    public void GearPlayerButton()
    {

        if (players[4] == true)
        {

            if (GameController.instance.selectedPlayer != 4)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 4;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[4];

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(4));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // gear player

    public void EarthPlayerButton()
    {

        if (players[5] == true)
        {

            if (GameController.instance.selectedPlayer != 5)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 5;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[5];
                

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(5));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // earth player

    public void FloaterPlayerButton()
    {

        if (players[6] == true)
        {

            if (GameController.instance.selectedPlayer != 6)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 6;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[6];
                

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(6));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // floater player

    public void BasketBallPlayerButton()
    {

        if (players[7] == true)
        {

            if (GameController.instance.selectedPlayer != 7)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 7;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[7];
                

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(7));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // basketball player

    public void FootBallPlayerButton()
    {

        if (players[8] == true)
        {

            if (GameController.instance.selectedPlayer != 8)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 8;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[8];

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(8));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // football player

    public void CoinPlayerButton()
    {

        if (players[9] == true)
        {

            if (GameController.instance.selectedPlayer != 9)
            {
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = false;
                GameController.instance.selectedPlayer = 9;
                GameController.instance.Save();
                SelectedButtonColor[GameController.instance.selectedPlayer].fillCenter = true;
                Circlemain.GetComponent<SpriteRenderer>().sprite = sprites[9];

            }
        }

        else
        {

            if (GameController.instance.coins >= 1200)
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do You Want To Purchase The Player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(9));

            }
            else
            {
                CirclePanel.SetActive(false);
                coinShop.SetActive(false);
                EarnPanel.SetActive(false);
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You Dont Have Enough Coins. Do You Want To Purchase Coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => CoinShopTab());

            }

        }

    } // coin player

    public void BuyPlayer(int index)
    {
        GameController.instance.players[index] = true;
        GameController.instance.coins -= 1200;
        GameController.instance.Save();
        InitializePlayerMenuController();
        buyPlayerPanel.SetActive(false);
        CirclePanel.SetActive(true);

    }

    /*public void IAP100Coins()
    {
        IAPController.instance.Buy100Coins();
    }

    public void IA200Coins()
    {
        IAPController.instance.Buy200Coins();
    }

    public void IAP500Coins()
    {
        IAPController.instance.Buy500Coins();
    }

    public void IAP1000Coins()
    {
        IAPController.instance.Buy1000Coins();
    }

    public void IAP2000Coins()
    {
        IAPController.instance.Buy2000Coins();
    }

    public void IAP4000Coins()
    {
        IAPController.instance.Buy4000Coins();
    }*/
    

    public void CloseBuyPlayerPanel()
    {
        buyPlayerPanel.SetActive(false);
        CirclePanel.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void CircleShopTab()
    {
        CirclePanel.SetActive(true);
        coinShop.SetActive(false);
        EarnPanel.SetActive(false);
        buyPlayerPanel.SetActive(false);
    }

    public void CoinShopTab()
    {
        CirclePanel.SetActive(false);
        coinShop.SetActive(true);
        EarnPanel.SetActive(false);
        buyPlayerPanel.SetActive(false);
    }

    public void EarnShopTab()
    {
        CirclePanel.SetActive(false);
        coinShop.SetActive(false);
        EarnPanel.SetActive(true);
        buyPlayerPanel.SetActive(false);
    }

    public void VideoNotLoadedOrUserSkippedTheVideo(string message)
    {
        WatchVideoPanel.SetActive(true);
        watchVideoText.text = message;
    }

    public void OKreturn()
    {
        WatchVideoPanel.SetActive(false);
    }

    /*public void WatchVideoToEarnExtraCoins()
    {
        AdController.instance.ShowAdRewarded();
        AdController.instance.flag = 1;
    }

    public void WatchVideoToEarnExtraCoins2()
    {
        AdController.instance.ShowAdRewarded();
        AdController.instance.flag = 2;
    }*/

    public void VideoWatchGiveUserCoins()
    {
        GameController.instance.Load();
        GameController.instance.coins += 20;
        GameController.instance.Save();
        coinText.text = "" + GameController.instance.coins;
    }
    
}