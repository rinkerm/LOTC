using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool combat;
    private Vector2 dir;
    private float speed = 1;
    private int health;
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        combat = false;
        dir = new Vector2(0, 1);
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
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

        }
    }
    public void StartCombat()
    {
        combat = true;
    }

}
