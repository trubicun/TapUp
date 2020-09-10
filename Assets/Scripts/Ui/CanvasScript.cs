using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public Button restart;
    public Button menu;
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(ToMenu);
        restart.onClick.AddListener(Restart);
        textScore.text = "Your Score:  " + GameObject.FindGameObjectWithTag("GamePlay").GetComponent<GamePlay>().getProgress().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    void ToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
