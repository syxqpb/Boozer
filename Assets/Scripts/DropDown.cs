using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public GameObject player;
    
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        //сделать прерывистое вращение пропов дотвином
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Бутылка разбилась о Player");
            
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Бутылка разбилась о Ground");
            Destroy(gameObject);
        }
    }
}
