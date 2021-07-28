using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public static Queue<string> sentences; // static list for all sentences from all char's
   [SerializeField]
    public static List<TextMeshProUGUI> characterTalking; // static list for knowing who sayd what sentence
    public TMP_InputField newInputFieldText;
    public float timeForNewSentance;
    public int i = 0;

    void Start()
    {
        sentences = new Queue<string>();
        characterTalking = new List<TextMeshProUGUI>();
    }

    public void EnqueNewSentances()
    {
        // pressing enter in dialogue window of char inserts sentence to queue
        sentences.Enqueue(newInputFieldText.text); 
        // getting father component according to prefab -> knowing who'se saying what sentence ( 1st sentence.queue -> sayed by 1st chartalking.list)
        characterTalking.Add(gameObject.GetComponentInChildren<TextMeshProUGUI>()); 
    }
    public void DequeeNewSentances()
    {
        //extracting correct sentence to character talking accordingly.
       characterTalking[i].text = sentences.Dequeue();
    }
    public void ClearDialogueText()
    {
        sentences.Clear();
    }
    public void OnNameSelection()
    {
        nameText.text = newInputFieldText.text;
    }

    public IEnumerator ShowNextSentance()
    {
        //ienumerator allows to stop the process at a specific moment, return the part of object (or none) and gets back that point when ever needed 
      //exactly what we need for showing each sentence from queue without halting all program
        while (sentences.Count != 0)
        {
            Debug.Log("NEW SENTANCE HAS ARRIVED");

            DequeeNewSentances();
            i++;
            yield return new WaitForSeconds(timeForNewSentance);
            if (sentences.Count == 0)
            {
                Debug.Log("BREAK");
                break;
            }
        }
    }
    public void StartSentanceCourutine()
    {
        Debug.Log("CORUTINE HAS STARTED");
        StartCoroutine(ShowNextSentance());
    }
}

