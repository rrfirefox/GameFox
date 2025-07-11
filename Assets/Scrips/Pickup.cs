using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour
{

    public bool isGem;
    public bool isHeal;
    private bool isCollected;

    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;

                UIController.instance.UpdateGemCount();

                Instantiate(pickupEffect, transform.position, transform.rotation);

                AudioManager.instance.PlaySFX(6);

                isCollected = true;
                Destroy(gameObject);
            }

            if(isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    
                    AudioManager.instance.PlaySFX(7);

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
