using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 newPos = transform.position;
            newPos.x = player.position.x + offset.x;
            transform.position = newPos;
        }
    }
}
