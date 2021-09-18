using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public partial class PlayerArchive
{
    public string Name;
    public PetData[] PetDataArray;
    public Backpack Backpack;

    public int LevelId;
    public Vector3 Position;
    public float X;
    public float Y;

    private PlayerArchive()
    {
        PetDataArray = new PetData[6];
        Backpack = new Backpack();

        LevelId = 1001;
        Position = new Vector3(0.5f, 0f, 0f);
        X = 0f;
        Y = -1f;
    }
}