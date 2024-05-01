using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2.0f;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,newpos,FollowSpeed*Time.deltaTime);
        
    }
}
