using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[] { };
    public float distanceBetweenObst = 10;
    public Canvas canvas;
    public Material[] colors;
    public Material[] playerColors;
    public GameObject trail;
    public Light playerLight;

    private GameObject player;
    private int progress;
    private int color;
    // Start is called before the first frame update
    void Start()
    {
        color = UnityEngine.Random.Range(0, colors.Length);
        player = GameObject.FindGameObjectWithTag("Player");
        progress = 1;
        trail.GetComponent<Renderer>().material = colors[color];
        player.GetComponent<Renderer>().material = playerColors[color];
        playerLight.color = colors[color].color;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y - progress * 10 > 0)
        {
            progress++;
            addObstacle();
            if (PlayerPrefs.GetInt("Score") < progress)
            {
                PlayerPrefs.SetInt("Score", progress);
            }
        }
    }

    void addObstacle()
    {
        if (UnityEngine.Random.Range(-1, 1) < 0)
        {
            Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], new Vector3(UnityEngine.Random.Range(-5.5f, -2f), progress * distanceBetweenObst, 0), Quaternion.identity);
        } else
        {
            Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], new Vector3(UnityEngine.Random.Range(5.5f, 2f), progress * distanceBetweenObst, 0), Quaternion.identity);
        }
    }
    void saveProgress()
    {

    }
    public void Die()
    {
        player.GetComponent<Collider>().isTrigger = true;
        Instantiate(canvas);
    }
    public int getProgress()
    {
        return progress;
    }
}
