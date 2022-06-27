using UnityEngine;

public class Ground : MonoBehaviour
{
    // Now this script needed to interacting with trigger system.
    [SerializeField] private PlayerController _controller;
    private int brokenBottlesCount = 0;

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
            _controller.collectedBottles = 0;
            GlobalEventManager.SendHealthChanged(_controller.health, _controller.ScoreCounter.totalScore);
        }
        else print("PlayerController not found");
    }
}
