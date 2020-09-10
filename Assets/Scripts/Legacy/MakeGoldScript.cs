using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGoldScript : MonoBehaviour
{
    GameObject player;
    public Material gold;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.gameObject == player)
        {
            GetComponent<Renderer>().material = gold;
        }
    }
}
