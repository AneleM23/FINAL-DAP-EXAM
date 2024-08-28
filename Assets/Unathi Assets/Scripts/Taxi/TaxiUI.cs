using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiUI : MonoBehaviour
{
    [SerializeField] GameObject taxiUI;

    // Start is called before the first frame update
    void Start()
    {
        taxiUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {                   if(col.tag == "Player")
        taxiUI.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            taxiUI.SetActive(false);
    }
}
