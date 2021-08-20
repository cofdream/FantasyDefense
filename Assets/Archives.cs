using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Archives
{
    static string archivePath;

    static Archives()
    {
#if UNITY_EDITOR
        archivePath = Directory.GetParent(Application.dataPath).FullName + "/";
#else
        archivePath = Application.persistentDataPath + "Archives/";
#endif
    }

    public static T Load<T>(string path, bool notExistCreate = true) where T : IArchives
    {
        string filePath = archivePath + path;
        if (File.Exists(filePath) == false)
        {
            if (notExistCreate)
            {
                var t = default(T);
                t.InitArchives();
                return t;
            }
            else
            {
                return default(T);
            }
        }
        return default;
        // tood Load

    }
}
public interface IArchives
{
    void InitArchives();
}