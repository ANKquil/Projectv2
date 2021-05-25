using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public float smooth = 0.1f;
    private Vector3 offset = new Vector3(5, 3, -1.2f);
    Quaternion offsetRt = Quaternion.Euler(15, -55, 0);

    private void Start()
    {
        offset = new Vector3(transform.position.x - target.position.x,
            transform.position.y - target.position.y,
            transform.position.z - target.position.z);

        StartCoroutine(MoveCoroutine(offsetRt));
    }

    bool IsMoving = true;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * smooth);
    }

    IEnumerator MoveCoroutine(Quaternion moveRt)
    {
        while (transform.rotation != moveRt)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, moveRt, Time.fixedDeltaTime * 0.2f);
            yield return null;
        }

        IsMoving = false;
    }
}