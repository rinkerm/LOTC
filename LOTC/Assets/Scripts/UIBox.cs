using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBox : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    void OnGUI()
    {
        this.transform.LookAt(hero.transform);
        if (transform.rotation.eulerAngles.z != 0 || transform.rotation.eulerAngles.y != 0 || transform.rotation.eulerAngles.x != 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
