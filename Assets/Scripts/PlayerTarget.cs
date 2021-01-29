using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] float maxDistance;
    public SpriteRenderer target;
    [SerializeField] float drainSpeed;

    public GameObject Target
    {
        get
        {
            return target.gameObject;
        }
        set
        {
            if (value == null || Vector2.Distance(transform.position, value.transform.position) <= maxDistance)
            {
                if (target != null)
                {
                    target.GetComponent<SpriteRenderer>().color = Color.white;
                    target = value.GetComponent<SpriteRenderer>();
                    target.color = Color.red;
                }
                else
                {
                    target = null;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (target != null)
            {
                int column = GetAngleSegment();
                int row = Mathf.FloorToInt(column / 4);
                column -= row * 4;

                switch (column)
                {
                    case 0:
                        target.material.SetVector("_Quad" + row, target.material.GetVector("_Quad" + row) - new Vector4(drainSpeed, 0, 0, 0));
                        break;
                    case 1:
                        target.material.SetVector("_Quad" + row, target.material.GetVector("_Quad" + row) - new Vector4(0, drainSpeed, 0, 0));
                        break;
                    case 2:
                        target.material.SetVector("_Quad" + row, target.material.GetVector("_Quad" + row) - new Vector4(0, 0, drainSpeed, 0));
                        break;
                    case 3:
                        target.material.SetVector("_Quad" + row, target.material.GetVector("_Quad" + row) - new Vector4(0, 0, 0, drainSpeed));
                        break;
                    default:
                        break;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Beginning the fade");
            Fader.instance.FadeToNextScene();
        }
    }

    public float GetAngleInRadians()
    {
        if (target != null)
        {

            Vector3 difference = target.transform.position - transform.position;
            float angle = Mathf.Atan2(difference.y, difference.x);

            if (angle < 0)
            {
                angle += Mathf.PI * 2;
            }
            else if (angle > Mathf.PI * 2)
            {
                angle -= Mathf.PI * 2;
            }

            return angle;
        }
        else return 0;
    }

    public int GetAngleSegment()
    {
        float angle = GetAngleInRadians();

        int segment = Mathf.FloorToInt((float)(angle / (3.1415 / 2)));
        for (int i = 0; i < segment; i++)
        {
            angle -= Mathf.PI / 2;
        }

        segment *= 4;
        
        if (angle <= Mathf.PI / 24) //segment 1
        {
            segment += 0;
        }
        else if (angle > Mathf.PI / 24 && angle <= Mathf.PI * 3 / 24) //segment 2 
        {
            segment += 1;
        }
        else if (angle > Mathf.PI * 3 / 24 && angle <= Mathf.PI * 6 / 24) //segment 3
        {
            segment += 2;
        }
        else if (angle > Mathf.PI * 3 / 24 && angle <= Mathf.PI * 10 / 24) //segment 4
        {
            segment += 3;
        }
        else //segment 1 but at the next quadrant
        {
            segment += 4;
        }
        if (segment >= 16)
        {
            segment -= 16;
        }

        
        
        return segment;
    }


}
