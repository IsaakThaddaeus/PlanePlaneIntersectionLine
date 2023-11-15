using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaneIntersector
{
    // For an explanation of the code, please refer to my LinkedIn article:
    // https://www.linkedin.com/pulse/robust-algorithm-determining-intersection-line-between-johann-hotzel-dqcze%3FtrackingId=bsymw5fITbaRmQpV8JMZUg%253D%253D/?trackingId=bsymw5fITbaRmQpV8JMZUg%3D%3D
  
    public static bool getIntersectionLineOfPlanes(Vector3 p1, Vector3 n1, Vector3 p2, Vector3 n2, out Vector3 o, out Vector3 d){
       
        Vector3 p3 = Vector3.zero;
        Vector3 n3 = Vector3.Cross(n1, n2);
        d = n3.normalized;
        o = Vector3.zero;

        float det = det3x3(n1, n2, n3);
        if (det == 0){
            return false;
        }

        o = (Vector3.Dot(p1, n1) * Vector3.Cross(n2, n3) +
             Vector3.Dot(p2, n2) * Vector3.Cross(n3, n1) +
             Vector3.Dot(p3, n3) * Vector3.Cross(n1, n2)) / det;

        return true;
    }

    private static float det3x3(Vector3 a, Vector3 b, Vector3 c){
        float detA = a.x * (b.y * c.z - b.z * c.y);
        float detB = a.y * (b.x * c.z - b.z * c.x);
        float detC = a.z * (b.x * c.y - b.y * c.x);
        return  detA - detB + detC;
    }
}
