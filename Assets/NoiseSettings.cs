using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings{

    [Range(1, 10)]
    public int layers = 1;
    public float strength = 1;
    public float baseRoughness = 1;
    public float roughness = 2;
    public float persistence = .5f;
    public Vector3 center;
}
