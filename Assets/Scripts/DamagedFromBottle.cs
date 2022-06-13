using UnityEngine;

public class DamagedFromBottle : MonoBehaviour
{
    [SerializeField] private PlayerController playerHP;
    private void Awake()
    {
        playerHP = GetComponent<PlayerController>();
    }

    
}
