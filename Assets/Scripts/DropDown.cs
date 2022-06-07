using UnityEngine;

public class DropDown : MonoBehaviour
{
    private void Start()
    {

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
           // playerHP.health--;
            Destroy(gameObject);
        }
    }
}

