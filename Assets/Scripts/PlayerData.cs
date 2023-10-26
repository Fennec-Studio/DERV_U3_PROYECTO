using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public int mLifes = 0;
    public int mCoins = 0;
    public int mLevel = 0;
    public int mBonus = 0;
    public int mGiant = 0;

    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI coinText;

    void Start()
    {
        LoadInitialData();
    }

    void Update()
    {
        lifeText.text = mLifes.ToString();
        coinText.text = PlayerPrefs.GetInt("mCoins").ToString("D3");
        if (mLifes <= 0)
        {
            //Mostrar pantalla GameOver
            mLifes = 3; //Borrar esto 
            PlayerPrefs.SetInt("mLifes", mLifes);
            PlayerPrefs.SetInt("mCoins", 0);
        }
    }

    void LoadInitialData()
    {
        if(!PlayerPrefs.HasKey("mLifes"))
        {
            PlayerPrefs.SetInt("mLifes", 3);
            PlayerPrefs.SetInt("mCoins", 0);
            PlayerPrefs.SetInt("mLevel", 1);
            PlayerPrefs.SetInt("mBonus", 0);
            PlayerPrefs.SetInt("mGiant", 0);
        }
        mLifes = PlayerPrefs.GetInt("mLifes");
        mCoins = PlayerPrefs.GetInt("mCoins");
        mLevel = PlayerPrefs.GetInt("mLevel");
        mBonus = PlayerPrefs.GetInt("mBonus");
        mGiant = PlayerPrefs.GetInt("mGiant");

        if (mBonus == 1 && SceneManager.GetActiveScene().name != "PipeBonus")
        {
            GameObject player = GameObject.Find("Mario");
            GameObject bonusExit = GameObject.Find("BonusExit");
            Vector3 posCamera = new Vector3(19.14f, 12.13f, 948.2928f);

            player.transform.position = bonusExit.transform.position;
            GameObject.Find("MainCamera").transform.position = posCamera;

            PlayerPrefs.SetInt("mBonus", 0);
        }
    }   
}
