using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    private bool combat;
    private Vector2 dir;
    private float speed = 1.1f;
    private int health;
    private GameObject _spell;
    private int lastshot = 0;
    private int rate = 25;
    private bool initphase;
    private int zombies;
    private bool vulnerable;
    private bool[] spawned = { false, false, false };
    [SerializeField] GameObject boss;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject z;
    [SerializeField] private GameObject firewall;
    [SerializeField] private GameObject endflame;
    private GameObject _z0;
    private GameObject _z1;
    private GameObject _z2;
    // Start is called before the first frame update
    void Start()
    {
        vulnerable = true;
        endflame.SetActive(false);
        animator = GetComponent<Animator>();
        animator.SetBool("alive", true);
        combat = false;
        dir = new Vector2(0, 1);
        health = 15;
        initphase = false;
        zombies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (initphase)
        {
            if(spawned[0]==true && _z0 == null)
            {
                zombies++;
                spawned[0] = false;
            }
            if (spawned[1] == true && _z1 == null)
            {
                zombies++;
                spawned[1] = false;
            }
            if (spawned[2] == true && _z2 == null)
            {
                zombies++;
                spawned[2] = false;
            }
            if(zombies == 0 && spawned[0] == false)
            {
                spawned[0] = true;
                _z0 = Instantiate(z, transform.position + (new Vector3(-1f, 0, 0)), transform.rotation) as GameObject;
                _z0.GetComponent<Zombie>().move();
            }
            if (zombies == 1 && spawned[0] == false && spawned[1] == false)
            {
                spawned[0] = true;
                _z0 = Instantiate(z, transform.position + (new Vector3(-1f, .25f, 0)), transform.rotation) as GameObject;
                _z0.GetComponent<Zombie>().move();

                spawned[1] = true;
                _z1 = Instantiate(z, transform.position + (new Vector3(-1f, -.25f, 0)), transform.rotation) as GameObject;
                _z1.GetComponent<Zombie>().move();
            }
            if (zombies == 3 && spawned[0] == false && spawned[1] == false && spawned[2] == false)
            {
                spawned[0] = true;
                _z0 = Instantiate(z, transform.position + (new Vector3(-1f, 0, 0)), transform.rotation) as GameObject;
                _z0.GetComponent<Zombie>().move();

                spawned[1] = true;
                _z1 = Instantiate(z, transform.position + (new Vector3(-1f, .5f, 0)), transform.rotation) as GameObject;
                _z1.GetComponent<Zombie>().move();

                spawned[2] = true;
                _z2 = Instantiate(z, transform.position + (new Vector3(-1f, -.5f, 0)), transform.rotation) as GameObject;
                _z2.GetComponent<Zombie>().move();
            }
            if(zombies == 6)
            {
                initphase = false;
                firewall.SetActive(false);
                if (health < 5)
                {
                    StartCoroutine(secondStage());
                }
                else
                {
                    StartCoroutine(startCombat());
                }
                
            }
        }
        if (combat)
        {
            if(boss.transform.position.y > 12.35f)
            {
                dir = new Vector2(0, -1);
            }
            else if (boss.transform.position.y < 10.8f)
            {
                dir = new Vector2(0, 1);
            }
            transform.Translate(dir * speed * Time.deltaTime);
            if (health == 5)
            {
                health--;
                combat = false;
                rate = 17;
                speed = 1.7f;

                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                combat = false;
                sprite.color = Color.black;
                initphase = true;
                zombies = 0;
                firewall.SetActive(true);
                boss.transform.position = new Vector3(boss.transform.position.x, 11.775f, boss.transform.position.z);
            }
            Shoot();
            if(health < 0)
            {
                combat = false;
                StartCoroutine(die());
            }
        }
    }

    public void Shoot()
    {
        if (lastshot > rate)
        {
            _spell = Instantiate(fire, transform.position + (new Vector3(-.3f, 0, 0)), transform.rotation) as GameObject;
            lastshot = 0;
        }
        lastshot++;
    }

    public void startPhase()
    {
        initphase = true;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(combat)
        {
            if (other.GetComponent<Magic>() != null)
                    {
                        if (vulnerable)
                        {
                            StartCoroutine(hurt());
                        }
                        
                    }
        }
        
    }

    IEnumerator hurt()
    {
        vulnerable = false;
        health--;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;

        vulnerable = true;

        if (health == 10)
        {
            combat = false;
            sprite.color = Color.black;
            initphase = true;
            zombies = 0;
            firewall.SetActive(true);
            boss.transform.position = new Vector3(boss.transform.position.x, 11.775f, boss.transform.position.z);
        }
    }

    IEnumerator startCombat()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
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
        combat = true;
    }

    IEnumerator secondStage()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.black;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(0.9f, 0.9f, 1f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.black;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(0.9f, 0.9f, 1f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.white;
        combat = true;
    }

    IEnumerator die()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(1f, 1f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        transform.localScale = new Vector3(1f, 1f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        boss.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        yield return new WaitForSeconds(0.1f);
        boss.transform.localScale = new Vector3(0.75f, 0.75f, 1f);

        animator.SetBool("alive", false);
        Destroy(this.GetComponent<BoxCollider2D>());
        Destroy(this.GetComponent<Rigidbody2D>());
        endflame.SetActive(true);
    }

}
