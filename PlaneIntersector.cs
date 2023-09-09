using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaneIntersector
{
    
    //Derived from Graphics Gems 1, this code snippet calculates the intersection of three planes, as described on page 305.    
    public static void findIntersectionLineBetweenPlanes(Vector3 pointOnPlaneA, Vector3 planeANormal, Vector3 pointOnPlaneB, Vector3 planeBNormal, out Vector3 point, out Vector3 direction)
    {
        //Introducing a third plane with its normal vector defined as the cross product of normalA and normalB.
        //The specific position of this third plane in space can be chosen freely.

        Vector3 pointOnPlaneC = Vector3.zero;
        Vector3 planeCNormal = Vector3.Cross(planeANormal, planeBNormal);
        direction = planeCNormal;

        float det = calculateMatrixDeterminant(planeANormal, planeBNormal, planeCNormal);
        if (det == 0.0f){
            point = Vector3.zero;
            return;
        }

        point = (Vector3.Dot(pointOnPlaneA, planeANormal) * Vector3.Cross(planeBNormal, planeCNormal) +
                 Vector3.Dot(pointOnPlaneB, planeBNormal) * Vector3.Cross(planeCNormal, planeANormal) +
                 Vector3.Dot(pointOnPlaneC, planeCNormal) * Vector3.Cross(planeANormal, planeBNormal)) / det;
    }

    private static float calculateMatrixDeterminant(Vector3 vectorA, Vector3 vectorB, Vector3 vectorC)
    {
        float detA = vectorA.x * (vectorB.y * vectorC.z - vectorB.z * vectorC.y);
        float detB = vectorA.y * (vectorB.x * vectorC.z - vectorB.z * vectorC.x);
        float detC = vectorA.z * (vectorB.x * vectorC.y - vectorB.y * vectorC.x);
        return  detA - detB + detC;
    }
}
