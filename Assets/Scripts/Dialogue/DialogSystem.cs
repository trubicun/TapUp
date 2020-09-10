using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Queue<string> _sentences;
    [SerializeField] private Queue<Sprite> _emotions;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    [SerializeField] public Animator _animator;
    [SerializeField] private Dialogue _dialogue;
    private int _currentSentence;
    private int _currentEmotion;
    void Start()
    {

        //Transorm Translate???
        //События (EVENTS)
        //RequedComponent
        _currentSentence = 0;
        _currentEmotion = 0;
        _sentences = new Queue<string>();
        _emotions = new Queue<Sprite>();
        StartDialogue(_dialogue);
    }


    public void StartDialogue(Dialogue dialogue)
    {
        _animator.SetBool("isOpen",true);

        _sentences.Clear();
        _emotions.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        foreach (Sprite sprite in dialogue.emotions)
        {
            _emotions.Enqueue(sprite);
        }

        DisplayNextSentence();
    }
    public void UpDialogue()
    {
        _animator.SetBool("isUp", true);
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("Sentence " + _currentSentence);
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        IncCurrentSentence();
        string sentence = _sentences.Dequeue();
        Sprite sprite = _emotions.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        _image.sprite = sprite;
    }

    IEnumerator TypeSentence (string sentence)
    {
        _text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _text.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        _animator.SetBool("isOpen", false);
        _animator.SetBool("isUp", false);

    }

    public bool isEnd()
    {
        return !_animator.GetBool("isOpen");
    }

    public int GetCurrentSentence()
    {
        return _currentSentence;
    }
    public void IncCurrentSentence()
    {
        _currentSentence++;
    }
    private void IncUrrentEmotion()
    {
        _currentEmotion++;
    }

    public void OpenDialogue()
    {
        _animator.SetBool("isOpen", true);
    }
}
