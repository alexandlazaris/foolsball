using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject row = null;
    public float defaultX = 0.0f;
    public float maxLeftX = 0.0f;
    public float maxRightX = 0.0f;
    public float spinSpeed = 0.0f;
    public float moveSpeed = 0.0f;

    // Update is called once per frame
    void Start()
    {
        row.transform.localPosition = new Vector3 (0,0,0);
        row.transform.Rotate(Vector3.up);
    }

    void Update()
    {
        if(Input.GetAxis("Vertical") > 0)
            UpArrow();
        if(Input.GetAxis("Vertical") < 0)
            DownArrow();
        if(Input.GetAxis("Horizontal") > 0)
            RightArrow();
        if(Input.GetAxis("Horizontal") < 0)
            LeftArrow();
        else
        {
                // t.GetComponent<Rigidbody>().velocity = Vector3.zero; 
                // t.GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(t.localEulerAngles, Vector3.zero, 100.0f);
                // Vector3 current = row.transform.localEulerAngles;
                // row.transform.localEulerAngles = Vector3.Lerp(current, Vector3.zero, 1);
                // t.localEulerAngles = Vector3.Lerp(t.localEulerAngles, Vector3.zero, 1);
                //move rotation
                // t.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                
                //add code to slowly reset the rotation back to 0
        }
    }

    public void LeftArrow()
    {
        float posX = row.transform.localPosition.x;
        Debug.Log(posX);
        if (posX <= maxLeftX)
            Debug.Log ("Cannot move anymore");
        else
            row.transform.Translate((Time.deltaTime * moveSpeed * -1), 0, 0);
    }

    public void RightArrow()
    {
        float posX = row.transform.localPosition.x;
        Debug.Log(posX);
        if (posX >= maxRightX)
            Debug.Log ("Cannot move anymore");
        else
            row.transform.Translate((Time.deltaTime * moveSpeed * 1), 0, 0);
    }

    public void UpArrow()
    {
        row.transform.Rotate(Vector3.right, spinSpeed);
    }

    public void DownArrow()
    {
        row.transform.Rotate(Vector3.right, spinSpeed * -1);
    }
}