using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform targetLeft, targetRight, startPosition;
    public TextMeshProUGUI health_text, gameOver_text, startGame_text;
    [SerializeField]internal int health = 3;
    public float playerSpeed = 5.0f;

    Vector3 startMousePos;
    Vector3 currentMousePos;

    private void Start()
    {
        gameOver_text.gameObject.SetActive(false);
        startGame_text.gameObject.SetActive(true);
        startPosition.position = transform.position;
       // spawnManager.StartGame();
    }

    private void Update()
    {         
            CurrentHealth();

            //ÍÓ ÒÈÏ ÐÅÉÊÀÑÒ
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

    private void CurrentHealth()
    {
        health_text.text = $"HEALTH: {health}";
        if(health == 0)
        {
            gameOver_text.gameObject.SetActive(true);          
        }
    }
    

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottles"))
        {
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Heart"))
        {
            health++;
            Destroy(other.gameObject);
        }
    }
    

   
}
