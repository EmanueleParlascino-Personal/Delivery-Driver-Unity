using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Counter : MonoBehaviour
{
    // Start is called before the first frame update public Text t1;
    public static int packsDelivered;
    public TextMeshProUGUI t1;
    // Use this for initialization
    void Start () {
        t1 = GetComponent<TextMeshProUGUI> ();
    }
    
    // Update is called once per frame
    void Update () {
        t1.text = " Packs Delivered: " + packsDelivered;
    }
}


