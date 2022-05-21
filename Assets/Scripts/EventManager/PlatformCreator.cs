using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : Singleton<PlatformCreator>
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform finishTransform;
    public void CreatePlatform()
    {
        var level = Instantiate(platformPrefab, finishTransform);
        level.transform.localScale = Vector3.one;
    }
}
