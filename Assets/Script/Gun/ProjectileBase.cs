using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    public float timeToDestroy = 1.2f;
    public float speed = 50f;

    public int damageAmount = 1;

    public void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
