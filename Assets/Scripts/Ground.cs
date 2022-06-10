using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //Logic will be added here later. Now this script needed to interacting with trigger system.
    [SerializeField]private PlayerController _controller;
    private int brokenBottlesCount = 0;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out DropDown bottleGround))
        {
            if(bottleGround != null)
            {
                GlobalEventManager.SendBottleBroken(brokenBottlesCount);
                brokenBottlesCount++;
                _controller.health--;
            }            
        }
    }
}
