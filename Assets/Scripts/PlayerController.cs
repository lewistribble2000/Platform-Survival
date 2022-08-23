using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    public Camera followCamera;

    private GameObject lift;
    private float liftOffsetY;
    private Vector3 cameraPos;
    private float speedModifier;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        liftOffsetY = 0;
        speedModifier = 1;
        cameraPos = followCamera.transform.position - rigidBody.position;
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerPosition = rigidBody.position;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if(movement == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        if(lift != null)
        {
            playerPosition.y = lift.transform.position.y + liftOffsetY;
        }

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        rigidBody.MovePosition(playerPosition + movement * speedModifier * speed * Time.fixedDeltaTime);
        rigidBody.MoveRotation(targetRotation);
    }

    private void LateUpdate()
    {
        followCamera.transform.position = rigidBody.position + cameraPos;
    }

    private IEnumerator speedBonusRemoval()
    {
        yield return new WaitForSeconds(3);
        speedModifier = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lift"))
        {
            lift = other.gameObject;
            liftOffsetY = transform.position.y - lift.transform.position.y;
        }

        if(other.CompareTag("Powerup"))
        {
            Debug.Log("Hit");
            Destroy(other.gameObject);
            speedModifier = 2;
            StartCoroutine(nameof(speedBonusRemoval));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Lift"))
        {
            lift = null;
            liftOffsetY = 0;
        }
    }
}
