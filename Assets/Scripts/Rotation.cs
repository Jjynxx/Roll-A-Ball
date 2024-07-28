using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sara McHattie
// Galaxy Ball - Rotation settings for pickup objects

public class Rotation : MonoBehaviour
{
   
    // Update frame to allow pickup pieces to rotate, deltaTime allows for smoother rotation
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45)  * Time.deltaTime);
    }
}
