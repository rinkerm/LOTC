using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private int health = 3;
    private Animator animator;
    private int i = 90;
    private Vector2 dir;
    private bool combat=false;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (combat)
        {
            if (transform.rotation.eulerAngles.z != 0 || transform.rotation.eulerAngles.y != 0 || transform.rotation.eulerAngles.x != 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            transform.Translate(dir * speed * Time.deltaTime);
            if (i > 30)
                    {
                        int rand = Random.Range(0, 4);
                        switch (rand)
                        {
                            case 0:
                                animator.SetInteger("dir", 0);
                                dir = new Vector2(-1, 0);
                                break;
                            case 1:
                                animator.SetInteger("dir", 1);
                                dir = new Vector2(0, 1);
                                break;
                            case 2:
                                animator.SetInteger("dir", 2);
                                dir = new Vector2(1, 0);
                                break;
                            case 3:
                                animator.SetInteger("dir", 3);
                                dir = new Vector2(0, -1);
                                break;
                        }
                        i = 0;
                    }
            if(health == 0)
            {
                die();
            }
            i++;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Magic>() != null)
        {
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        health--;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(.005f);
        yield return new WaitForSeconds(.005f);
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
        
    }

    private void die()
    {
        Destroy(this.gameObject);
    }

    public void move()
    {
        combat = true;
    }
}
