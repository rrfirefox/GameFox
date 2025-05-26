using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class CameraControler : MonoBehaviour
{
    public Transform target;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    private Vector2 lastPos;
    void Start()
    {
        lastPos = transform.position;
    }
    void Update()
    {
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f)*.5f;
        lastPos = transform.position;
    }
}
