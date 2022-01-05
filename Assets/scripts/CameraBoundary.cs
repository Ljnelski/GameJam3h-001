using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float riseSpeed;    
    [SerializeField]
    private Transform player;

    private float currentSpeed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player.position.y > transform.position.y)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, Mathf.Max(player.position.y - transform.position.y, 1f) * 3f, 1f);
            transform.Translate(new Vector3(0.0f, currentSpeed) * Time.fixedDeltaTime, 0.0f);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, riseSpeed, 0.1f);
            transform.Translate(new Vector3(0.0f, currentSpeed * Time.fixedDeltaTime, 0.0f));
        }
    }
}
