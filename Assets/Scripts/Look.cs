using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject face;
    [SerializeField] GameObject nearestObject;

    [SerializeField] float smoothTime;
    [HideInInspector] Vector3 currentVelocity;

    [SerializeField] List<GameObject> objectInSight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTargetLookAt();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Ignore Specific Tag
        if (other.CompareTag("Wall"))
        {
            return;
        }

        //Jika tidak ada Neares Object Maka
        if (nearestObject == null)
        {
            //Lihat ke Object Tersebut
            nearestObject = other.gameObject;
        }

        //Prevent Object yg sudah ada di List dimasukan lagi kedalam List
        if (!objectInSight.Contains(other.gameObject))
        {
            //Add kedalam List
            objectInSight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectInSight.Contains(other.gameObject))
        {
            objectInSight.Remove(other.gameObject);
        }

        if (other.gameObject == nearestObject)
        {
            FindNearestObject();
        }
    }

    private void FindNearestObject()
    {
        if (objectInSight.Count == 0)
        {
            nearestObject = null;
        }else if (objectInSight.Count == 1)
        {
            nearestObject = objectInSight[0];
        }
        else
        {
            nearestObject = objectInSight[0];
            var nearestObjectDistance = getDistance(face.transform.position, nearestObject.transform.position);
            for (int i = 0; i < objectInSight.Count; i++)
            {
                if (getDistance(face.transform.position, objectInSight[i].transform.position) < nearestObjectDistance)
                {
                    nearestObject = objectInSight[i];

                    nearestObjectDistance = getDistance(face.transform.position, nearestObject.transform.position);
                }
            }
        }
    }

    public void MoveTargetLookAt()
    {
        if (nearestObject != null)
        {
            //SmoothDamp, MoveToward, Lerp
            target.transform.position = Vector3.SmoothDamp(target.transform.position, nearestObject.transform.position, ref currentVelocity, smoothTime * Time.deltaTime);
        }
        else
        {
            target.transform.position = Vector3.SmoothDamp(target.transform.position, face.transform.position + new Vector3(0, 1.6f, -0.5f), ref currentVelocity, smoothTime * Time.deltaTime);
        }
    }

    private float getDistance(Vector3 a, Vector3 b)
    {
        return (a - b).sqrMagnitude;
    }


}
