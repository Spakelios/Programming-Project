using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displau : MonoBehaviour {

    public NUMBERS card;
    public Image artworkImage;
    public Image panel;
    

    // Use this {for initialization
    void Start()
    {
        artworkImage.sprite = card.Character;
        panel.sprite = card.panel;

    }
	
}
