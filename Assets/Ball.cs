using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject labelTarget = null;
    public GameObject labelOwn = null;
    int goalsScoredTarget = 0;
    int goalsScoredOwn = 0;
    public AudioClip kick;
    public AudioClip goal;
    AudioSource audioSource;
    public Player player = null;
    private BounceBall bounceBall = new BounceBall();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // float x = Random.Range(0.1f, 2);
        // float y = Random.value * -1;
        // float z = Random.Range(0.1f, 2);
        
        // Vector3 defaultForce = new Vector3 (x, y, z);
        // gameObject.transform.GetComponent<Rigidbody>().AddForce(defaultForce * speed);
    }


    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided with: " + col.gameObject.name);
        switch(col.gameObject.name)
        {
            case "Goal_Target":
                goalsScoredTarget += 1;
                labelTarget.GetComponent<TextMesh>().text = goalsScoredTarget.ToString();
                audioSource.PlayOneShot(goal, 0.7F);
                player.ResetWithWait();
                break;
            case "Goal_Own":
                goalsScoredOwn += 1;
                labelOwn.GetComponent<TextMesh>().text = goalsScoredOwn.ToString();
                audioSource.PlayOneShot(goal, 0.7F);
                player.ResetWithWait();
                break;
            case "Guard":
                // float x = Random.Range(1, 2);
                // float y = Random.value * -1;
                // float z = Random.Range(1, 2);
                // Vector3 movement = new Vector3 (x, y, z);
                // gameObject.transform.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, movement, explosionRadius, 10, ForceMode.Impulse);
                bounceBall.useExplosiveForce = true;
                bounceBall.speed = 10;
                bounceBall.explosionForce = 10;
                bounceBall.explosionRadius = 10;
                bounceBall.AddForceToBall(gameObject);
                audioSource.PlayOneShot(kick, 0.7F);
                break;
            default:
                break;
        }
    }
}
