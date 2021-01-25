using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObjectsHolder : MonoBehaviour
{
    List<GameObject> targetableObjectsInScene = new List<GameObject>();

    private void Start()
    {
        TargetableObject[] objs = FindObjectsOfType<TargetableObject>();
        foreach (var obj in objs)
        {
            targetableObjectsInScene.Add(obj.gameObject);
            Debug.Log(obj.name);
        }

    }

    public GameObject GetClosestObject(Transform playerPosition)
    {
        GameObject closestObject = targetableObjectsInScene[0];

        float closestDistance = Vector2.Distance(playerPosition.position, closestObject.transform.position);

        foreach (var obj in targetableObjectsInScene)
        {
            float distance = Vector2.Distance(playerPosition.position, obj.transform.position);
            if (distance < closestDistance) // other object is closer
            {
                closestObject = obj;
                closestDistance = distance;
            }
        }

        return closestObject;  
    }
}
