﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidNoiseFilter : INoiseFilter{


    NoiseSettings.RigidNoiseSettings settings;
    Noise noise = new Noise();

    public RigidNoiseFilter(NoiseSettings.RigidNoiseSettings settings)
    {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;
        float weight = 1;

        for (int i = 0; i < settings.layers; i++)
        {
            float noiseEval = 1 - Mathf.Abs(noise.Evaluate(point * frequency + settings.center));
            noiseEval *= noiseEval;// square
            noiseEval *= weight;
            weight = Mathf.Clamp01(noiseEval * settings.weightMultiplier);
            noiseValue += noiseEval * amplitude;
            frequency += settings.roughness;
            amplitude *= settings.persistence;
        }

        noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
        return noiseValue * settings.strength;
    }
}
