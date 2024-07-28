using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sara McHattie
// Galaxy Ball - Camera settings, so that camera follows player position without rotating 

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame, but will only occure once other updates have completed
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
