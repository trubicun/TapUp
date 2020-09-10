using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Button start;
    public Text text;
    int isFirstTime;
    // Start is called before the first frame update
    void Start()
    {
        isFirstTime = 0;
        //isFirstTime = PlayerPrefs.GetInt("isFirstTime");
        if (isFirstTime == 0)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Tutor");
        }
        start.onClick.AddListener(StartGame);
        text.text = PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isFirstTime);
        Debug.Log(PlayerPrefs.GetInt("Score").ToString());
    }

    void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    void OpenShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
    }
}
