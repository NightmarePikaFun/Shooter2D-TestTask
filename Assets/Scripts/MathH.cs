using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathH
{
    public static Vector3 RotatePositionOnCircle(Vector3 vector, float angle)
    {
        float x = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float y = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Vector3(x, y);
    }

    public static float GetSpawnCoordOutRange(float pos, float range)
    {
        float returnCoord = pos;
        if(returnCoord < 0)
            returnCoord -= range;
        else
            returnCoord += range;
        return returnCoord;
    }
}
