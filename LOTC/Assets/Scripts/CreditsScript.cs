using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsScript : MonoBehaviour
{
    [SerializeField] Color highlightColor = Color.blue;

    void Start()
    {
        highlightColor.a = 1f;
    }

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        SceneManager.LoadScene("credits");
    }
}