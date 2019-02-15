using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float fspeed = 1.7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, -90));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * fspeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
