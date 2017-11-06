using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryProjection : MonoBehaviour
{
    public GameObject trajectoryPointerPrefab;
    public Transform trajectoryStart, trajectoryParent;
    public List<GameObject> trajectory;
    public int pointNumber = 10;

    public void DrawTrajectory(float angle, float baseForce, float forceCoefficient, Vector3 arrowPosition)
    {
        CleanTrajectory();
        float force = baseForce * forceCoefficient;
        for (int i = 0; i < pointNumber; i++)
        {
            //расчет позиции каждого идикатора траектории
            Vector3 location = Vector3.zero;
            float t = 0.1f * i;
            location.x = t * force * Mathf.Cos(angle * Mathf.Deg2Rad);
            location.y = t * force * Mathf.Sin(angle * Mathf.Deg2Rad) - 9.81f * t * t / 2;
            GameObject instance = Instantiate(trajectoryPointerPrefab, trajectoryParent);
            instance.transform.position = trajectoryStart.position + location;
            trajectory.Add(instance);
        }
    }

    public void CleanTrajectory()
    {
        if (trajectory.Count > 0)
            for (int i = pointNumber - 1; i >= 0; i--)
            {
                Destroy(trajectory[i]);
            }
        trajectory.Clear();
    }
}
