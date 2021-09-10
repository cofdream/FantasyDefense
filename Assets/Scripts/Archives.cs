using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Archives
{
    static string archivesRootPath;
    public static List<Archive> AllArchive { get; private set; }
    static Archives()
    {
#if UNITY_EDITOR
        archivesRootPath = Directory.GetParent(Application.dataPath).FullName + "/Archives/";
#else
        archivesRootPath = Application.persistentDataPath + "Archives/";
#endif

        LoadArchives();
    }

    private static void LoadArchives()
    {
        AllArchive = new List<Archive>();

        if (Directory.Exists(archivesRootPath) == false)
        {
            Directory.CreateDirectory(archivesRootPath);
            return;
        }

        string[] archivePaths = Directory.GetFiles(archivesRootPath);
        int length = archivePaths.Length;
        for (int i = 0; i < length; i++)
        {
            string[] archiveInfo = archivePaths[i].Split('_');
            if (archiveInfo.Length != 2)
            {
                Debug.LogError("Archive file path error. path : " + archivePaths[i]);
                continue;
            }

            if (long.TryParse(archiveInfo[0], out long ticks) == false)
            {
                Debug.LogError("Time tick error. ticks : " + archiveInfo[0]);
                continue;
            }
            Archive archive = new Archive(ticks, archiveInfo[1]);
            AllArchive.Add(archive);
        }
    }
    static long GetTimeStamp()
    {
        TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(timeSpan.TotalSeconds);
    }

    public static T Load<T>(string path) where T : IArchive
    {
        T t;
        string filePath = archivesRootPath + path;
        if (File.Exists(filePath) == false)
        {
            t = default(T);
            t.InitArchives();
        }
        else
        {
            string json = File.ReadAllText(filePath);
            t = JsonUtility.FromJson<T>(json);
        }
        return t;
    }

    public static void CreateArchive(string name)
    {
        Archive archive = new Archive(GetTimeStamp(), name);
        AllArchive.Add(archive);
    }
}
public interface IArchive
{
    void InitArchives();
}

public struct Archive
{
    public DateTime DateTime;
    public string Name;

    public Archive(long ticks, string name)
    {
        DateTime = new DateTime(ticks, DateTimeKind.Local);
        Name = name;
    }
}