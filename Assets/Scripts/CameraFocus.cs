using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public float MoveSpeed = 35.0f;

    private bool movingTowardsTarget = false;

    public void CameraMove(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);
    }
}

//Временно бесполезен