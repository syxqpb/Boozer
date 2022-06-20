using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform targetLeft, targetRight, startPosition;
    [SerializeField]internal int health = 3;
    public float playerSpeed = 5.0f;
    private int collectedBottles = 0;

    private ScoreCounter scoreCounter;

    Vector3 startMousePos;
    Vector3 currentMousePos;

    private void Start()
    {       
        startPosition.position = transform.position;
        GlobalEventManager.onHealthChanged.AddListener(HealthDamaged);       
    }

    private void Update()
    {                   
            #region RAYCAST INPUT
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Input.mousePosition;
            }
            else if(Input.GetMouseButton(0))
            {
                currentMousePos = Input.mousePosition;

                Vector3 direction = (startMousePos - currentMousePos).normalized;
                Ray ray = Camera.main.ViewportPointToRay(Input.mousePosition.normalized);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Background")
                    {
                        if(direction.x > 0)
                        {
                            transform.DOLookAt(targetRight.position, 0.25f);
                            transform.position = Vector3.Lerp(transform.position, new Vector3(targetRight.position.x, transform.position.y, transform.position.z), Time.deltaTime * 1f);
                        }
                        else if (direction.x < 0)
                        {
                            transform.DOLookAt(targetLeft.position, 0.25f); 
                            transform.position = Vector3.Lerp(transform.position, new Vector3(targetLeft.position.x, transform.position.y, transform.position.z), Time.deltaTime * 1f);
                        }                       
                    }
                }
            }
            else
            {
                transform.DOLookAt(Camera.main.transform.position, 0.25f);
            }
            #endregion     
    }

    public void HealthDamaged(int brokenBottlesCountInWave)
    {
        if(health > 0)
        {
            health--;
            if (health == 0)
            {
                GlobalEventManager.SendGameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DropDown bottleGround))
        {
            if (bottleGround != null)
            {
                //GlobalEventManager.SendBottleCollected(scoreCounter.collectedBottles);
                //SCORE INCREASE
            }
        }
    }

    



}
