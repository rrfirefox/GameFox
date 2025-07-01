using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject deathEffect;

    [Range(0,100)]public float chanceToDrop;

    public GameObject collectible;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            
            Instantiate(deathEffect,other.transform.position, other.transform.rotation); //Muerte de enemigos
            PlayerController.instance.Bounce(); //Impulso al matar
            float dropSelect = Random.Range(0,100f); // Probabilidadde botar items al matar enemigos
            
            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
            AudioManager.instance.PlaySFX(3);
        }
    }
}
