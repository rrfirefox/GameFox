using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float lifeTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
