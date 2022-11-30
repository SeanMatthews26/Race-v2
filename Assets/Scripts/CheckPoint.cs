using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
