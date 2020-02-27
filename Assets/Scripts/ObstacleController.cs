using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float speed = -0.5f;
    private Transform target;
    float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeDif = Time.time - startTime; ;
        if ( timeDif > 5)
        {
            transform.Translate(0,0,Time.deltaTime * speed, Space.Self);

            if (transform.localPosition.z  < -0.7f)
            {
                //Destroy(this.gameObject);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.4f);
               
            }
        }
    }
}
