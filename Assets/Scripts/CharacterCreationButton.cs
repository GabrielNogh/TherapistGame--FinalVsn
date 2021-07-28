using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationButton : MonoBehaviour
{
    public GameObject CharacterToSetActive;

    // Active characters that are chosen to be on scene
    public void CharacterClickedSelection()
    {
        if(CharacterToSetActive.gameObject.activeSelf == false)
        CharacterToSetActive.gameObject.SetActive(true);
        else
            CharacterToSetActive.gameObject.SetActive(false);

    }
}
