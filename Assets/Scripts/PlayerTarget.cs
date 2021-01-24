using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] float maxDistance;
    private GameObject target;
    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            if ( value == null || Vector2.Distance(transform.position, value.transform.position) <= maxDistance )
            {
                target = value;
            }
        }
    }
}
