using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
        {
            LevelManager.instance.RespawnPlayer();
        }
        }


}
