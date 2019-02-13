using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject gameObj;
    private List<GameObject> _shots = new List<GameObject>();
    [SerializeField] private GameObject spellPrefab;
    [SerializeField] private GameObject h0;
    [SerializeField] private GameObject h1;
    [SerializeField] private GameObject h2;
    private Vector2 facing;
    private Animator animator;
    private GameObject _spell;
    private int i = 0;
    private int lastshot;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        facing = Vector2.down;
        lastshot = 21;
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.rotation.eulerAngles.z != 0 || transform.rotation.eulerAngles.y != 0 || transform.rotation.eulerAngles.x != 0)
            {
            gameObj.transform.eulerAngles = new Vector3(0, 0, 0);
        }
            if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("attack", true);
            Shoot();
        }
        GetDir();
        lastshot++;

        switch (health)
        {
            case 0:
                h0.GetComponent<Health>().ChangeHealth(2);
                break;
            case 1:
                h0.GetComponent<Health>().ChangeHealth(1);
                break;
            case 2:
                h1.GetComponent<Health>().ChangeHealth(2);
                break;
            case 3:
                h1.GetComponent<Health>().ChangeHealth(1);
                break;
            case 4:
                h2.GetComponent<Health>().ChangeHealth(2);
                break;
            case 5:
                h2.GetComponent<Health>().ChangeHealth(1);
                break;
            default:
                //do nothing
                break;
        }
    }

    public void Move()
    {
        transform.Translate(facing*speed*Time.deltaTime);
        AnimateMovement(facing);
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    private void GetDir()
    {

        if (Input.GetKey(KeyCode.W))
        {
            facing = Vector2.up;
            Move();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            facing = Vector2.left;
            Move();
        }

        else if (Input.GetKey(KeyCode.S))
        {
            facing = Vector2.down;
            Move();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            facing = Vector2.right;
            Move();
        }
        else
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }
        if(i == 35)
        {
            animator.SetBool("attack", false);
            i = 0;
        }
            
        i = i + 1;
    }
    public void Shoot()
    {
        if (lastshot > 20)
        {
            _spell = Instantiate(spellPrefab,transform.position+ (new Vector3(facing.x,facing.y,0)/5),transform.rotation) as GameObject;
            _spell.GetComponent<Magic>().setDir(facing);
            lastshot = 0;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mage>() != null)
        {
            StartCoroutine(Bounce());
            health--;
        }
    }

    IEnumerator Bounce()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        transform.Translate(facing * (-speed * 10) * Time.deltaTime);
        yield return new WaitForSeconds(.005f);
        transform.Translate(facing * (-speed * 10) * Time.deltaTime);
        yield return new WaitForSeconds(.005f);
        transform.Translate(facing * (-speed * 10) * Time.deltaTime);
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;

    }

}
