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
            if (value == null || Vector2.Distance(transform.position, value.transform.position) <= maxDistance)
            {
                if (target != null)
                    target.GetComponent<SpriteRenderer>().color = Color.white;

                target = value;

                if (target != null)
                    target.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(GetAngleInRadians());
        }
    }

    public float GetAngleInRadians()
    {
        Vector3 difference = target.transform.position - transform.position;
        float angle = Mathf.Atan2(difference.y, difference.x);

        if (angle < 0)
        {
            angle += Mathf.PI * 2;
        } else if (angle > Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }

        return angle;
    }

    public int GetAngleSegment()
    {
        float angle = GetAngleInRadians();

        int quadrant = (int)(angle % (Mathf.PI / 2));

        for (int i = 0; i < quadrant; i++)
        {
            angle -= Mathf.PI / 2;
        }




        return 0;
    }


}
