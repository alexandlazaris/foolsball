using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform resetBallTransform = null;
    public GameObject ball = null;
    public List<Camera> cameras = null; 
    
    //add two player, with different settings/types of players for each

    void Start()
    {
        ResetBall();
    }

    void UpdateCamera()
    {
        Camera camEnabled = null;
        Camera camDisabled = null;
        foreach(Camera cam in cameras)
        {  
            if(cam.enabled == true)
                camEnabled = cam;
                
            if(cam.enabled == false)
                camDisabled = cam;
        }
        camEnabled.enabled = false;
        camDisabled.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResetBall();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateCamera();
        }
    }

    public void ResetBall()
    {
        ball.transform.position = resetBallTransform.position;
        ball.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    public void ResetWithWait()
    {
        StartCoroutine("Wait");
        ResetBall();
    }
}

