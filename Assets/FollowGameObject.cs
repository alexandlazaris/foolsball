using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    //if out of bounds, reset ball!
    public Transform target = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion _lookRotation = Quaternion.LookRotation((target.transform.localPosition - transform.position).normalized);
        gameObject.transform.rotation = _lookRotation;
    }
}
