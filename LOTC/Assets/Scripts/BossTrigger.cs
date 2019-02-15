using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject boss;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {

            boss.GetComponent<Boss>().startPhase();
            Destroy(this.gameObject);


        }
    }
    
}
