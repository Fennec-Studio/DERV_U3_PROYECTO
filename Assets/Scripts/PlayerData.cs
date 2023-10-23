using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int mLifes = 0;
    public int mCoins = 0;
    public int mLevel = 0;

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
        }
    }

    void LoadInitialData()
    {
        if(!PlayerPrefs.HasKey("mLifes"))
        {
            PlayerPrefs.SetInt("mLifes", 3);
            PlayerPrefs.SetInt("mCoins", 0);
            PlayerPrefs.SetInt("mLevel", 1);
        }
        mLifes = PlayerPrefs.GetInt("mLifes");
        mCoins = PlayerPrefs.GetInt("mCoins");
        mLevel = PlayerPrefs.GetInt("mLevel");
    }   
}
