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

    public static Vector3 GetSpawnCoordOutRange(Vector3 position, float range)
    {
        Vector3 retVector = new Vector3(range* position.x, 0);
        retVector.y = Mathf.Sqrt(450-(retVector.x*retVector.x));
        if(position.y < 0)
            retVector.y *= -1;
        return retVector;
    }
}
