/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdController : MonoBehaviour {

    public static AdController instance;
    public int flag = 0;

    private const string app_id = "1581459";  

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void LoadUnityAds()
    {
        if(Advertisement.isSupported)
        {
            //Advertisement.allowPrecache = true;
            Advertisement.Initialize("1581459", true);
        }
    }

    public void ShowAdVideo()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }


    public void ShowAdRewarded()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult});
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:

                if(flag==1)
                {
                    GameController.instance.Load();
                    GameController.instance.coins += 15;
                    GameController.instance.Save();
                    ShopController.instance.coinText.text = "" + GameController.instance.coins;
                    flag = 0;

                }

                if (flag == 2)
                {
                    GameController.instance.Load();
                    GameController.instance.coins += 20;
                    GameController.instance.Save();
                    ShopController.instance.coinText.text = "" + GameController.instance.coins;
                    flag = 0;
                }

                break;

            case ShowResult.Skipped:
                Debug.Log("video skipped, no prize earned");
                break;

            case ShowResult.Failed:
                Debug.Log("ad could not be loaded , internet ??");
                break;
                
        }
    }
}
*/