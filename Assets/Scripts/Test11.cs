using DA.AssetLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test11 : MonoBehaviour
{
    public AssetLoader assetLoader;
    public AssetBundle assetBundle;
    public PetBase moveBase;
    public string res;
    public string res2;
    void Start()
    {
        assetLoader = new AssetLoader();

        moveBase = assetLoader.LoadAsset<PetBase>(res);

        Debug.Log(moveBase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        assetLoader.UnloadAll();
    }
}