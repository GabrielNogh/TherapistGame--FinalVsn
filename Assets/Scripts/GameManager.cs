using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas CreationPanels;
    public Canvas ModeSelectorCanvas;
    public List<GameObject> DialogueBoxes;
    public GameObject SaveAndLoadButtons;
    public int bgID;
    public AudioSource bgm;
    public enum GameMode { Creation, Play }
    public GameMode game;
    void Start()
    {
        bgm = FindObjectOfType<AudioSource>();
        SaveAndLoadButtons = GameObject.Find("SaveAndLoadButtons");
        instance = this;
        game = GameMode.Creation;
    }
    public void ChangeToPlayMode()
    {
        game = GameMode.Play;
        CreationPanels.gameObject.SetActive(false);
        SaveAndLoadButtons.SetActive(false);
        bgm.Stop();
    }
    public void ChangeToCreateMode()
    {
        game = GameMode.Creation;
        CreationPanels.gameObject.SetActive(true);
        SaveAndLoadButtons.SetActive(true);
        if(bgm.isPlaying == false)
        {
            bgm.Play();
        }
    }
}
