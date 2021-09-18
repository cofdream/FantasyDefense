using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public partial class PlayerArchive
{
    private static string archivePath;

    static PlayerArchive()
    {
#if UNITY_EDITOR
        archivePath = Directory.GetParent(Application.dataPath).FullName + "/Archives/";
#else
        archivesRootPath = Application.persistentDataPath + "Archives/";
#endif
        Directory.CreateDirectory(archivePath);
    }
    //public static long GetArchiveName()
    //{
    //    TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
    //    return Convert.ToInt64(timeSpan.TotalSeconds);
    //}

    public static PlayerArchive Load(string fileName)
    {
        PlayerArchive playerArchive;
        string filePath = archivePath + fileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerArchive = JsonUtility.FromJson<PlayerArchive>(json);
        }
        else
        {
            playerArchive = new PlayerArchive();
        }
        return playerArchive;
    }
    public static void Save(PlayerArchive playerArchive, string fileName)
    {
        string filePath = archivePath + fileName;
        string json = JsonUtility.ToJson(playerArchive);
        File.WriteAllText(filePath, json);
    }
}