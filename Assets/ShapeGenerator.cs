using UnityEngine;
using System.Collections;

public class ShapeGenerator{

    ShapeSettings settings;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
    }

    public Vector3 CalcPointOnPlanet(Vector3 PointOnSphere)
    {
        return PointOnSphere * settings.planetRadius;
    }
}
