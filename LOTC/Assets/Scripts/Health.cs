using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Sprite[] hearts;
    [SerializeField] private Sprite image;
    public void ChangeHealth(int newlvl)
    {
        switch (newlvl)
        {
            case 0:
                image = hearts[0];
                GetComponent<SpriteRenderer>().sprite = image;
                break;
            case 1:
                image = hearts[1];
                GetComponent<SpriteRenderer>().sprite = image;
                break;
            case 2:
                image = hearts[2];
                GetComponent<SpriteRenderer>().sprite = image;
                break;
        }
    }
}
