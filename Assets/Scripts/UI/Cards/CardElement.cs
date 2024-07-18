using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardElement : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    public string name;

    public void Setup(SkillElements card)
    {
        this.name = card.name;
        this.sprite.sprite = card.cardSprite;
        this.sprite.sortingOrder = 100;
    }
}
