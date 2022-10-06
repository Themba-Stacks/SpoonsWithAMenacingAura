using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public float followFactor = 1;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.x != transform.position.x || player.position.y != transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, player.position - 10 * Vector3.forward, followFactor * Time.deltaTime);
        }
        
    }
}
