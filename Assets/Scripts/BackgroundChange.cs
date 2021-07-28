using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    public SpriteRenderer BGimage;
    public int BGid;
    // Update is called once per frame

    public void RandomSprite()
    {
        ModularSystem.instance.RandomImageSelect();
        BGimage.sprite = ModularSystem.instance.currentBG.sprite;
    }
    public void UpdateBGimage()
    {
        ModularSystem.instance.BackgroundChooseFromList(BGid); 
        BGimage.sprite = ModularSystem.instance.currentBG.sprite;
    }
}
