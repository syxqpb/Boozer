using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelSC : Window
{
    public void Show()
    {
        gameObject.SetActive(true);
        controller.OnWindowOpen(this);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
        controller.OnWindowClosed(this);
    }
    public void Restart()
    {

    }
}
