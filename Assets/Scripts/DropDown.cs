using UnityEngine;

public class DropDown : MonoBehaviour
{
      //make choppy rotation of props dotwin with coroutine

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController))
        {
            if (playerController != null)
            {
                Debug.Log("the bottle broke on the player");
                //SCORE INCREASE
                Destroy(gameObject);
            }
        }
        if(other.gameObject.TryGetComponent(out Ground ground))
        {
            if(ground != null)
            {
                Debug.Log("the bottle broke on the ground");
                //PLAYER DAMAGED
                Destroy(gameObject);
            }
        }
    }
}

