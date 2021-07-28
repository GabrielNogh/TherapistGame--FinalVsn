using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Characters : MonoBehaviour 
{
    public string name;
    public int id;
    public Sprite sprite;
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }
    private void OnMouseDrag()
    {
        if (GameManager.instance.game == GameManager.GameMode.Creation)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mouseWorldPosition);
        }
    }
}
