using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI TextPro;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Kick off at: " + System.DateTime.Now.ToShortTimeString(); //ToShortDateString();
    }
}
