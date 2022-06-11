using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //Logic will be added here later. Now this script needed to interacting with trigger system.
    [SerializeField]private PlayerController _controller;
    [SerializeField] private GameObject _gameObject;
    private int brokenBottlesCount = 0;
    private void Awake()
    {
        _controller = _gameObject.GetComponent<PlayerController>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out DropDown bottleGround))
        {
            if(bottleGround != null)
            {
                GlobalEventManager.SendBottleBroken(brokenBottlesCount);                
                GetPlayerController();
            }            
        }
    }

    private void GetPlayerController()
    {
        if (_controller != null)
        {
            GlobalEventManager.SendHealthChanged(_controller.health);
        }
        else print("PlayerController not found");
    }
}
