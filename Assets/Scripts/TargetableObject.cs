using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{

    PlayerTarget player;
    Material mat;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerTarget>(); //gets the player
        mat = GetComponent<SpriteRenderer>().material;
        if (player == null) //checks if it was a success
        {
            throw new System.Exception();
        }

        Matrix4x4 m = new Matrix4x4();
        m = Matrix4x4.identity;
        mat.SetMatrix("_SaturationMatrix", m);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == player.gameObject) //collided with the player
        {
            //tries to set the player's target to the closest object
            player.Target = FindObjectOfType<TargetableObjectsHolder>().GetClosestObject(player.transform); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            var obj = FindObjectOfType<TargetableObjectsHolder>().GetClosestObject(player.transform);
            if (obj != gameObject)
            {
                player.Target = obj;
            }
            else
            {
                player.Target = null;
            }
        }
    }

    public void SetInternalMatrix(Matrix4x4 matrix)
    {
        mat.SetMatrix("_SaturationMatrix", matrix);
    }

    public Matrix4x4 GetInternalMatrix()
    {
        return mat.GetMatrix("_SaturationMatrix");
    }
}
