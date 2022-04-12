using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDeath : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.EndGame();
        }
        else if(other.tag == "Box")
        {
            Destroy(other.gameObject);
        }
    }
}
