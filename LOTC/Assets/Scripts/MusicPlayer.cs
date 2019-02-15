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

            StartCoroutine(FadeOut());
            

        }
    }

    IEnumerator FadeOut()
    {
        AudioSource source = mplayer.GetComponent<AudioSource>();
        source.volume = 0.1f;
        yield return new WaitForSeconds(1f);
        source.volume = 0.05f;
        yield return new WaitForSeconds(1f);
        source.volume = 0.01f;
        yield return new WaitForSeconds(1f);
        source.clip = music[1];
        source.volume = 0.3f;
        source.Play();
        Destroy(this);
    }
}
