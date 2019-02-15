using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] GameObject mplayer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            StartCoroutine(End());
            
        }
    }

    IEnumerator End()
    {
            AudioSource source = mplayer.GetComponent<AudioSource>();
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            source.volume = 0.2f;
            yield return new WaitForSeconds(1f);
            source.volume = 0.1f;
            yield return new WaitForSeconds(1f);
            source.volume = 0.05f;
            yield return new WaitForSeconds(1f);
            source.volume = 0.01f;
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("winner");
    }
}
