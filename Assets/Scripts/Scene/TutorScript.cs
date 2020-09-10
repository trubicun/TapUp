/*
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorScript : MonoBehaviour
{
    DialogSystem dialogue;
    public GameObject playerPrefab;
    GameObject player;
    public GameObject playerSphere;
    public GameObject StartPlatform;
    public GameObject Floor;
    public CinemachineVirtualCamera cam;
    public GameObject BackGround;
    int progress;
    private IEnumerator waiting;
    // Start is called before the first frame update
    void Start()
    {
        waiting = wait(5f);
        progress = 0;
        dialogue = GameObject.FindObjectOfType<DialogSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        progress = dialogue.getProgress();
        switch (progress)
        {
            case 4:
                player = Instantiate(playerPrefab);
                break;
            case 6:
                StartPlatform.gameObject.tag = "StartPlatform";
                if (player.transform.position.y > 2)
                {
                    StartCoroutine(waiting);
                    break;
                }
                break;
            case 10:
                GameObject.Destroy(Floor);
                cam.Follow = player.transform;
                break;
        }
    }
    private IEnumerator wait(float value)
    {
        yield return new WaitForSeconds(value);
        trigger.TriggerDialogue();
        yield return new WaitForSeconds(value);
        trigger.TriggerDialogue();
        yield return new WaitForSeconds(value);
        trigger.TriggerDialogue();
        yield return new WaitForSeconds(value);
        trigger.TriggerDialogue();
        yield return new WaitForSeconds(value);
        yield return new WaitForSeconds(value/4f);
        //trigger.TriggerDialogue();
        dialogue.EndDialogue();
        StopCoroutine(waiting);

    }
    private IEnumerator wait2(float value)
    {
        // Do something before
        yield return new WaitForSeconds(value);

        progress = 9;
        // Do something after
    }
}
*/