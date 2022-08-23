using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    private float travelDistance = 0;
    private float maxDistance = 15;
    private float speed = 5;

    private Coroutine reverseCoroutine;

    private Rigidbody rb;

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody>();

        enabled = false;

        yield return new WaitForSeconds(3f);

        enabled = true;
    }

    void FixedUpdate()
    {
        if(travelDistance >= maxDistance)
        {
            if (reverseCoroutine == null)
            {
                reverseCoroutine = StartCoroutine(nameof(reverseLift));
            }
        } 
        else
        {
            float distance = speed * Time.fixedDeltaTime;
            travelDistance += Mathf.Abs(distance);

            Vector3 liftPos = rb.position;
            liftPos.y += distance;

            rb.MovePosition(liftPos);
        }
    }

    private IEnumerator reverseLift()
    {
        yield return new WaitForSeconds(3.0f);
        travelDistance = 0;
        speed = -speed;
        reverseCoroutine = null;
    }
}
