using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("alive", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void die()
    {
        animator.SetBool("alive", false);
        Destroy(gameObj.GetComponent<BoxCollider2D>());
        Destroy(gameObj.GetComponent<Rigidbody2D>());
    }
}
