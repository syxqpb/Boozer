using UnityEngine;

public class DropDown : MonoBehaviour
{
    private Player _player;
    private PlayerController player;

    private void Awake()
    {

    }
    private void Start()
    {
        //GlobalEventManager.bottleBroken.AddListener(_player.DamagedByMissedBottle);
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
        if (other.gameObject.TryGetComponent(out PlayerController playerController))
        {
            if (playerController != null)
            {
                Debug.Log("бутылка разбилась о player");
                //SCORE INCREASE
                Destroy(gameObject);
            }
        }
        if(other.gameObject.TryGetComponent(out Ground ground))
        {
            if(ground != null)
            {
                Debug.Log("бутылка разбилась о ground");
                //PLAYER DAMAGED
                Destroy(gameObject);
            }
        }
    }
}

