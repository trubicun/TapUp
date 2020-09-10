using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorGameplay : MonoBehaviour
{
    public GameObject[] walls;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 101; i++)
        {
            Instantiate(walls[Random.Range(0, walls.Length)], new Vector3(Random.Range(-2.5f,2.5f), 10 * i - Random.Range(0,5)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
