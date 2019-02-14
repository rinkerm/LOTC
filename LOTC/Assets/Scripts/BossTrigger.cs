using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject trigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {

            StartCoroutine(StartCombat());


        }
    }
    IEnumerator StartCombat()
    {
        SpriteRenderer sprite = boss.GetComponent<SpriteRenderer>();
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        sprite.color = Color.black;
        
        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.white;
        
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.black;
        boss.transform.localScale = new Vector3(0.9f, 0.9f, 1f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.white;
        boss.GetComponent<Boss>().StartCombat();
        Destroy(trigger.GetComponent<BoxCollider2D>());
    }
}
