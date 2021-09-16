using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LogoScene : MonoBehaviour
{
    // todo 使用ScriptableObjects来保存数据
    [SerializeField] InputAction enterInputAction;
    [SerializeField] Object mainScene;

    private void OnEnable()
    {
        enterInputAction.Enable();
    }
    private void OnDisable()
    {
        enterInputAction.Disable();
    }
    private void Start()
    {
        enterInputAction.canceled += OnCanceled;

        //enterInputAction.started += context => Debug.Log($"{context.action} started" + context.ReadValueAsButton());
        //enterInputAction.performed += context => Debug.Log($"{context.action} performed" + context.ReadValueAsButton());
        //enterInputAction.canceled += context => Debug.Log($"{context.action} canceled" + context.ReadValueAsButton());
    }

    private void OnDestroy()
    {
        enterInputAction.canceled -= OnCanceled;

        //enterInputAction.Dispose();
    }


    private void OnCanceled(InputAction.CallbackContext context)
    {
        StartCoroutine(OnEnterGame());
    }

    private IEnumerator OnEnterGame()
    {
#if UNITY_EDITOR
        var scene = UnityEditor.SceneManagement.EditorSceneManager.LoadSceneInPlayMode(UnityEditor.AssetDatabase.GetAssetPath(mainScene), new LoadSceneParameters() { loadSceneMode = LoadSceneMode.Additive, localPhysicsMode = LocalPhysicsMode.Physics2D });

        yield return null;

        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync("LogoScene", UnloadSceneOptions.None);
#else
        yield return null;
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
#endif
    }
}