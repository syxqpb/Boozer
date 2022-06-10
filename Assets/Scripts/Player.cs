using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : PlayerController
{
    private PlayerController controller;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        controller = this;
    }

    private int Health { get => controller.health; set => controller.health = value; }

    private void Update()
    {
        //Update must been empty here! Rework this stuff to Event or smth!
        CurrentHealth();
    }

    public void CurrentHealth()
    {
        if (Health == 0)
        {
            Debug.Log("Player was dead by alkogolism");
            gameManager.GameOver();
        }
    }

    public void DamagedByMissedBottle()
    {
        Health--;
    }
}

