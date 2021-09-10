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
        FindObjectOfType<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().deselectOnBackgroundClick = false;

        FindObjectOfType<UIStart>(true).Show();
    }

    void Update()
    {

    }

}