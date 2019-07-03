using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    public float speed;
    public bool useExplosiveForce = false;
    public float explosionForce, explosionRadius;
    void Start()
    {
        //set default values if they're false
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {       
        Debug.Log("Collided with: " + col.gameObject.name); 
        if(col.gameObject.name == "Ball")
            AddForceToBall(col.gameObject);
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Exiting collision with: " + col.gameObject.name); 
        if(col.gameObject.name == "Ball")
            AddForceToBall(col.gameObject);
    }

    public void AddForceToBall(GameObject objectToForce)
    {
        float x = Random.Range(0.1f, 2);
        float y = Random.value * -1;
        float z = Random.Range(0.1f, 2);
        Vector3 movement = new Vector3 (x, y, z);
        if (!useExplosiveForce)
            objectToForce.transform.GetComponent<Rigidbody>().AddForce(movement * speed);
        else
            objectToForce.transform.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, movement, explosionRadius, 10, ForceMode.Impulse);
    }
}
