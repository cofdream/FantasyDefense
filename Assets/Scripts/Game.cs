using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    void Awake()
    {

    }
    private void Start()
    {
        UIPanelFactory.GetPanel(UIPanelType.MainPanel).Show();
    }

    void Update()
    {

    }

    public static void EnterGame(int selectArchive)
    {

    }
}