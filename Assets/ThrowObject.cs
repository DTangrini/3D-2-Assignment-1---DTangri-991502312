using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject prop;
    private GameObject proj;
    public GameObject prop2;
    private GameObject proj2;
    public Vector3 posOffset;
    public Vector3 force;
    public Vector3 force2;
    public Transform hand;
    public float compensationYAngle = 0f;
    public void Prepare()
    {
        proj = Instantiate(prop, hand.position, hand.rotation) as
       GameObject;
        if (proj.GetComponent<Rigidbody>())
            Destroy(proj.GetComponent<Rigidbody>());
        proj.GetComponent<SphereCollider>().enabled = false;
        proj.name = "Shuriken";
        proj.transform.parent = hand;
        proj.transform.localPosition = posOffset;
        proj.transform.localEulerAngles = Vector3.zero;
    }
    public void Throw()
    {
        Vector3 dir = transform.rotation.eulerAngles;
        dir.y += compensationYAngle;
        proj.transform.rotation = Quaternion.Euler(dir);
        proj.transform.parent = null;
        proj.GetComponent<SphereCollider>().enabled = true;
        Rigidbody rig = proj.AddComponent<Rigidbody>();
        Collider projCollider = proj.GetComponent<Collider>();
        Collider col = GetComponent<Collider>();
        Physics.IgnoreCollision(projCollider, col);
        rig.AddRelativeForce(force);
    }

    public void Chamber()
    {
        proj2 = Instantiate(prop2, hand.position, hand.rotation) as
       GameObject;
        if (proj2.GetComponent<Rigidbody>())
            Destroy(proj2.GetComponent<Rigidbody>());
        proj2.GetComponent<SphereCollider>().enabled = false;
        proj2.name = "Missile";
        proj2.transform.parent = hand;
        proj2.transform.localPosition = posOffset;
        proj2.transform.localEulerAngles = Vector3.zero;
    }

    public void Launch()
    {
        Vector3 dir = transform.rotation.eulerAngles;
        dir.y += compensationYAngle;
        proj2.transform.rotation = Quaternion.Euler(dir);
        proj2.transform.parent = null;
        proj2.GetComponent<SphereCollider>().enabled = true;
        Rigidbody rig = proj2.AddComponent<Rigidbody>();
        Collider projCollider = proj2.GetComponent<Collider>();
        Collider col = GetComponent<Collider>();
        Physics.IgnoreCollision(projCollider, col);
        rig.AddRelativeForce(force2);
    }

}
