using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 60 * Time.deltaTime);
    }
}
