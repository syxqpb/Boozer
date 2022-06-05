using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public WindowController instance { get; private set; }
    private HashSet<Window> openTab;
    private void Awake()
    {
        openTab = new HashSet<Window>();
        instance = this;
    }

    public void OnWindowOpen(Window window)
    {
        if(openTab.Count == 0)
        {
            Time.timeScale = 0.0f;
        }
        openTab.Add(window);
    }
    public void OnWindowClosed(Window window)
    {
        openTab.Remove(window);
        if(openTab.Count == 0)
        {
            Time.timeScale = 1.0f;
        }
    }
}
public class Window : MonoBehaviour
{
    [SerializeField] protected WindowController controller;
}
