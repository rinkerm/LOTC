using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private float mspeed = 2f;
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
        if (other.GetComponent<Player>() == null || other.GetComponent<BossTrigger>() == null || other.GetComponent<MusicPlayer>() == null || other.GetComponent<ZombieTrigger>() == null)
        {
            Destroy(this.gameObject);
            if (other.GetComponent<Mage>() != null)
            {
                other.GetComponent<Mage>().die();
            }
        }
    }
    public void setDir(Vector2 dir)
    {
        direction = dir;
    }
}

