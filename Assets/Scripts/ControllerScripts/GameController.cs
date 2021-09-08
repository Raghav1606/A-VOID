using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public Sprite[] sprites;

    private GameData data;

    public int currentLevel = -1;

    public int currentScore;

    public int currentLives;

    public bool IsMusicOn;

    public bool isGameStartedFromLevelMenu;

    public bool isGameStartedFirstTime;

    public bool doubleCoins;

    public bool gamemode;
    public bool canShowAds;
    public bool showRulesFirst;

    public int selectedPlayer;
    public int coins;
    public int highScore;

    public int[] levelHighScore;
    public bool[] players;
    public bool[] levelcoinsreceived;
    public bool[] levels;

    void Awake()
    {
        MakeSingleton();
        InitializeGameVariables();
    }

    // Use this for initialization
    void Start()
    {

    }

    void MakeSingleton()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeGameVariables()
    {

        Load();

        if (data != null)
        {
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
        }
        else
        {
            isGameStartedFirstTime = true;
        }

        if (isGameStartedFirstTime)
        {
            // the game is started for the first time
            showRulesFirst = true;
            highScore = 0;
            coins = 500;
            gamemode = false;
            selectedPlayer = 0;
            canShowAds = true;

            IsMusicOn = true;
            isGameStartedFirstTime = false;

            players = new bool[10];
            levels = new bool[25];
            levelcoinsreceived = new bool[25];
            levelHighScore = new int[25];

            players[0] = true;
            for (int i = 1; i < players.Length; i++)
            {
                players[i] = false;
            }

            levels[0] = true;
            levelcoinsreceived[0] = false;
            for (int i = 1; i < levels.Length; i++)
            {
                levels[i] = false;
                levelcoinsreceived[i] = false;
                levelHighScore[i] = 0; 
            }
            
            data = new GameData();

            data.setHighScore(highScore);
            data.setCoins(coins);
            data.setSelectedPlayer(selectedPlayer);
            data.setIsGameStartedFirstTime(isGameStartedFirstTime);
            data.setPlayers(players);
            data.setLevels(levels);
            data.setlevelcoinsreceived(levelcoinsreceived);
            data.setlevelHighScore(levelHighScore);
            data.setgamemode(gamemode);
            data.setcanShowAds(canShowAds);
            data.setShowRulesFirst(showRulesFirst);
            data.setIsMusicOn(IsMusicOn);

            Save();

            Load();

        }
        else
        {
            // the game has been played already so load 

            highScore = data.getHighScore();
            coins = data.getCoins();
            selectedPlayer = data.getSelectedPlayer();

            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
            players = data.getPlayers();
            levels = data.getLevels();
            levelcoinsreceived = data.getlevelcoinsreceived();
            levelHighScore = data.getlevelHighScore();
            gamemode = data.getgamemode();
            canShowAds = data.getcanShowAds();
            showRulesFirst = data.getShowRulesFirst();
            IsMusicOn = data.getIsMusicOn();

        }


    } // initialize variables

    public void Save()
    {

        FileStream file = null;

        try
        {

            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + "/GameData.dat");

            if (data != null)
            {

                data.setHighScore(highScore);
                data.setCoins(coins);
                data.setIsGameStartedFirstTime(isGameStartedFirstTime);
                data.setPlayers(players);
                data.setLevels(levels);
                data.setSelectedPlayer(selectedPlayer);
                data.setlevelcoinsreceived(levelcoinsreceived);
                data.setlevelHighScore(levelHighScore);
                data.setgamemode(gamemode);
                data.setcanShowAds(canShowAds);
                data.setShowRulesFirst(showRulesFirst);
                data.setIsMusicOn(IsMusicOn);
                bf.Serialize(file, data);

            }

        }
        catch (Exception e)
        {

        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }

    } // save data

    public void Load()
    {

        FileStream file = null;

        try
        {

            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);

            data = (GameData)bf.Deserialize(file);

        }
        catch (Exception e)
        {

        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    } // load data

} // game controller

[Serializable]
class GameData
{

    private bool isGameStartedFirstTime;
    private bool canShowAds;
    private bool showRulesFirst;
    private bool[] levelcoinsreceived;

    private bool gamemode;
    private int selectedPlayer;
    private int coins;
    private int highScore;
    private int[] levelHighScore;

    private bool[] players;
    private bool[] levels;
    private bool IsMusicOn;

    public void setShowRulesFirst(bool showRulesFirst)
    {
        this.showRulesFirst = showRulesFirst;
    }

    public bool getShowRulesFirst()
    {
        return this.showRulesFirst;
    }

    public void setcanShowAds(bool canShowAds)
    {
        this.canShowAds = canShowAds;
    }

    public bool getcanShowAds()
    {
        return this.canShowAds;
    }

    public void setgamemode(bool gamemode)
    {
        this.gamemode = gamemode;
    }

    public bool getgamemode()
    {
        return this.gamemode;
    }

    public void setlevelHighScore(int[] levelHighScore)
    {
        this.levelHighScore = levelHighScore;
    }

    public int[] getlevelHighScore()
    {
        return this.levelHighScore;
    }

    public void setlevelcoinsreceived(bool[] levelcoinsreceived)
    {
        this.levelcoinsreceived = levelcoinsreceived;
    }

    public bool[] getlevelcoinsreceived()
    {
        return this.levelcoinsreceived;
    }

    public void setIsGameStartedFirstTime(bool isGameStartedFirstTime)
    {
        this.isGameStartedFirstTime = isGameStartedFirstTime;
    }

    public bool getIsGameStartedFirstTime()
    {
        return this.isGameStartedFirstTime;
    }

    public void setSelectedPlayer(int selectedPlayer)
    {
        this.selectedPlayer = selectedPlayer;
    }

    public int getSelectedPlayer()
    {
        return this.selectedPlayer;
    }

    public void setCoins(int coins)
    {
        this.coins = coins;
    }

    public int getCoins()
    {
        return this.coins;
    }

    public void setHighScore(int highScore)
    {
        this.highScore = highScore;
    }

    public int getHighScore()
    {
        return this.highScore;
    }

    public void setPlayers(bool[] players)
    {
        this.players = players;
    }

    public bool[] getPlayers()
    {
        return this.players;
    }

    public void setLevels(bool[] levels)
    {
        this.levels = levels;
    }

    public bool[] getLevels()
    {
        return this.levels;
    }

    public void setIsMusicOn(bool IsMusicOn)
    {
        this.IsMusicOn = IsMusicOn;
    }

    public bool getIsMusicOn()
    {
        return this.IsMusicOn;
    }

} // game data