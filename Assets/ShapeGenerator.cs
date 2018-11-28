using UnityEngine;
using System.Collections;

public class ShapeGenerator{

    ShapeSettings settings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter(settings.noiseSettings);
    }

    public Vector3 CalcPointOnPlanet(Vector3 PointOnSphere)
    {
        float elevation = noiseFilter.Evaluate(PointOnSphere);
        return PointOnSphere * settings.planetRadius * (1 + elevation);
    }
}
