using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Sprite[] hearts;
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject hero;
    void Update()
    {
        this.transform.LookAt(hero.transform);
        if (transform.rotation.eulerAngles.z != 0 || transform.rotation.eulerAngles.y != 0 || transform.rotation.eulerAngles.x != 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
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
