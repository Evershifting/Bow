using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryProjection : MonoBehaviour
{
    public GameObject trajectoryPointerPrefab;
    public Transform trajectoryStart, trajectoryParent;
    List<GameObject> trajectory = new List<GameObject>();
    public int pointNumber = 30; //количество "точек" в траектории

    //расчет позиции каждого из идикаторов траектории и добавление их в список
    public void DrawTrajectory(float angle, float baseForce, float bowstringTension, Vector3 arrowPosition)
    {
        float force = baseForce * bowstringTension;
        for (int i = 0; i < pointNumber; i++)
        {
            Vector3 location = Vector3.zero;
            float t = 0.1f * i;
            location.x = t * force * Mathf.Cos(angle * Mathf.Deg2Rad);
            location.y = t * force * Mathf.Sin(angle * Mathf.Deg2Rad) - 9.81f * t * t / 2;
            GameObject instance = Instantiate(trajectoryPointerPrefab, trajectoryParent);
            instance.transform.position = trajectoryStart.position + location;
            trajectory.Add(instance);
        }
    }

    //очистка траектории
    public void CleanTrajectory()
    {
        if (trajectory != null)
        {
            if (trajectory.Count > 0)
                for (int i = pointNumber - 1; i >= 0; i--)
                {
                    Destroy(trajectory[i]);
                }
            trajectory.Clear();
        }
    }
}
