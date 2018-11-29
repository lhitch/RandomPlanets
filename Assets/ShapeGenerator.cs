using UnityEngine;
using System.Collections;

public class ShapeGenerator{

    ShapeSettings settings;
    NoiseFilter[] noiseFilters;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilters = new NoiseFilter[settings.noiseLayers.Length];
        for(int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = new NoiseFilter(settings.noiseLayers[i].noiseSettings);
        }
    }

    public Vector3 CalcPointOnPlanet(Vector3 PointOnSphere)
    {
        float firstLayerVal = 0;
        float elevation = 0;

        if(noiseFilters.Length > 0)
        {
            firstLayerVal = noiseFilters[0].Evaluate(PointOnSphere);
            if(settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerVal;
            }
        }

        for(int i = 1; i < noiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerVal : 1;
                elevation += noiseFilters[i].Evaluate(PointOnSphere) * mask;
            }
        }
        return PointOnSphere * settings.planetRadius * (1 + elevation);
    }
}
