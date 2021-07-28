using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameHandler : MonoBehaviour
{
    // handling JSON serialization & Deserialization
    // problem with TEXTMESHPRO and JSON :(
    public static GameHandler instance;
    BackgroundChange bgToLoad;
    public int charsInScene;
    public List<GameObject> charToSave = new List<GameObject>();
    public List<bool> charsActivated = new List<bool>();
    public List<Vector3> runtimePosition = new List<Vector3>();
    public static List<TextMeshProUGUI> charsTalking = new List<TextMeshProUGUI>();
    PlayerData playerData = new PlayerData();
 
    private void Awake()
    {
        charsInScene = charToSave.Count;
        instance = this;
        bgToLoad = FindObjectOfType<BackgroundChange>();
    }
    public void Save()
    {
        GetCharsPosition();
        GetCharsActivity();
        GetDialogueListAndPos();

        playerData.positionToLoad = runtimePosition;
        playerData.charsActivityToLoad = charsActivated;
        playerData.bgToLoad = ModularSystem.instance.currentBG;
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }
    public void Load()
    {

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);

        #region LoadBG
        ModularSystem.instance.currentBG = loadedPlayerData.bgToLoad;
        bgToLoad.BGimage.sprite = loadedPlayerData.bgToLoad.sprite;
        #endregion

        #region Load Position
        for (int i = 0; i < charsInScene; i++) //Load Position
        {
            charToSave[i].transform.position = loadedPlayerData.positionToLoad[i];
        }
        #endregion

        #region Loading active chars
        for (int i = 0; i < charsInScene; i++)
        {
            charToSave[i].SetActive(loadedPlayerData.charsActivityToLoad[i]);
        }
        #endregion

        DialogueManager.sentences = new Queue<string>();

        for (int i = 0; i < loadedPlayerData.sentencesToLoad.Count; i++)
        {
            DialogueManager.sentences.Enqueue(loadedPlayerData.sentencesToLoad[i]);
            Debug.Log("Sentances Loaded back to Queue:" + loadedPlayerData.sentencesToLoad[i]);
           // DialogueManager.characterTalking[i].text = DialogueManager.sentences.Dequeue(); // Dequee text according to textMeshPro List
        }
    }
    public void GetDialogueListAndPos()
    {
       // playerData.sentancesPos = DialogueManager.characterTalking; //Get TextMeshPro List to insert text
        if (DialogueManager.sentences != null)   //Get Sentances
        {
            string[] sentancesArray = DialogueManager.sentences.ToArray();
            for (int i = 0; i < DialogueManager.sentences.Count; i++)
            {
                playerData.sentencesToLoad.Add(sentancesArray[i]);
                Debug.Log("Sentances Saved:" + sentancesArray[i]);
                
            }
        }
    }

    private void GetCharsPosition()
    {
        runtimePosition.Clear();
        for (int i = 0; i < charsInScene; i++)
        {
            runtimePosition.Add(charToSave[i].transform.position);
        }
    }
    private void GetCharsActivity()
    {
        charsActivated.Clear();
        foreach (var obj in charToSave)
        {
            charsActivated.Add(obj.activeSelf);
        }
    }
    public class PlayerData
    {
        public List<bool> charsActivityToLoad = new List<bool>();
        public List<Vector3> positionToLoad = new List<Vector3>();
        public BackgroundClass bgToLoad;
        public List<string> sentencesToLoad = new List<string>();
        public List<TextMeshProUGUI> sentancesPos = new List<TextMeshProUGUI>();
    }
}