using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModularSystem : MonoBehaviour 
{
    public static ModularSystem instance;
    public BackgroundChange BGchange;
    [Header("Characters")]
    public GameObject CharacterClicked;
    public List<DialogueManager> CharactersInScene;
    public DialogueManager[] charsDialogueManager;
    public List<GameObject> charsInScene;

    [Header("Backgrounds")]
    public BackgroundClass[] backgrounds;
    public BackgroundClass currentBG;
    private GameHandler handler;

    // Prefab to store;
    private void Awake()
    {
        instance = this;
        BGchange = FindObjectOfType<BackgroundChange>();
        handler = FindObjectOfType<GameHandler>();
        DeactivateAllChars();
    }
    public void GetCharsAndDialogue()
    {
        charsDialogueManager = FindObjectsOfType<DialogueManager>();
        foreach (var charDialogueManager in charsDialogueManager)
        {
            charsInScene.Add(charDialogueManager.transform.parent.gameObject);
        }
    }
    private void DeactivateAllChars()
    {
        foreach(var obj in handler.charToSave)
        {
            obj.SetActive(false);
        }
    }

    public void RandomCharSelect()
    {
        //RANDOM BUTTON on Panel
        foreach(var obj in handler.charToSave)
        {
            obj.SetActive(RandomBool());
        }
    }
    public bool RandomBool()
    {
        // randomizing bool number to randomly activate characters when needed
        float boolValue = Random.value;
        if (boolValue > 0.5f)
            return true;
        else return false;
    }
    public void RandomImageSelect()
    {
        currentBG = backgrounds[Random.Range(0, backgrounds.Length)];
    }
    public void BackgroundChooseFromList(int bgID)
    {
        currentBG = backgrounds[bgID];
    }

    private Vector3 RandomCharPos()
    {
        //Fix random values
        return new Vector3(Random.Range(-1, 545), Random.Range(-5, 274)); 
    }
    }


