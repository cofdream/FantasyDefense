public static class Command
{
    public static void EnterGame()
    {
        // 选择角色

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