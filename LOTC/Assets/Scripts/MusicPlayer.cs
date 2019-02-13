using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] music;
    [SerializeField] AudioSource mplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            AudioSource source = mplayer.GetComponent<AudioSource>();
            source.clip =music[1];
            source.volume = 0.2f;
            source.Play();
            Destroy(this);
        }
    }
}
