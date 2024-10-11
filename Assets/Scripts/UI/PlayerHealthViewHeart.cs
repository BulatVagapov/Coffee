using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthViewHeart : MonoBehaviour
{
    private Image heartImage;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;

    void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetFullSprite()
    {
        heartImage.sprite = fullHeartSprite;
    }

    public void SetEmptySprite()
    {
        heartImage.sprite = emptyHeartSprite;
    }
}
