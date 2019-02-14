using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] zombies;
    [SerializeField] GameObject trigger;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            for (int i = 0; i < 6; i++)
            {
                zombies[i].GetComponent<Zombie>().move();
            }
            Destroy(trigger.GetComponent<BoxCollider2D>());
        }
    }
}
