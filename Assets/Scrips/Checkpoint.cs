using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            CheckpointController.instance.DeactivateCheckpoints();

            theSR.sprite = cpOn;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }

    }
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
