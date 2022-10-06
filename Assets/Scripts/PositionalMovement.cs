using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionalMovement : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float xMotion = Input.GetAxisRaw("Horizontal");
        float yMotion = Input.GetAxisRaw("Vertical");

        Vector3 xVector = Vector2.right * xMotion * Time.deltaTime * speed;
        Vector3 yVector = Vector2.up * yMotion * Time.deltaTime * speed;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mouseScreenPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 difference = new Vector2(mouseScreenPos.y - transform.position.y, mouseScreenPos.x - transform.position.x);
        float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

        transform.position += xVector + yVector;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
