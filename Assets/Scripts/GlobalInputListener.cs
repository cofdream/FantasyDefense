using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalInputListener : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    private InputAction inputAction;
    void Awake()
    {
        //FindObjectOfType<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().deselectOnBackgroundClick = false;
        //FindObjectOfType<UIStart>(true).Show();

        inputAction = inputActions.FindActionMap("Player").FindAction("Setting");
    }

    private void Start()
    {
        inputAction.started += InputAction_started;
    }

    private void InputAction_started(InputAction.CallbackContext context)
    {
        //Open setting window
        Debug.Log("Open SettingWindow");
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void OnDestroy()
    {
        inputAction.started -= InputAction_started;
    }
}