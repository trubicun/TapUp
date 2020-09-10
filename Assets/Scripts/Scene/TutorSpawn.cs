using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorSpawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Live>().SetSpawn(gameObject);
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
