using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Command
{
    public static void EnterGame()
    {
        // Ñ¡Ôñ½ÇÉ«

    }
    public static void ContuinGame()
    {
        
    }
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}