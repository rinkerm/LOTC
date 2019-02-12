using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private float mspeed = 1.5f;
    public int damage = 1;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*mspeed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        Mage mage = other.GetComponent<Mage>();
        if (player == null)
        {
            Destroy(this.gameObject);
            if (mage != null)
            {
                mage.die();
            }
        }

        



        Destroy(this.gameObject);
    }
    public void setDir(Vector2 dir)
    {
        direction = dir;
    }
}

