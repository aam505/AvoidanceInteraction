using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public Transform end;
    public Transform [] obstacles;
    // Start is called before the first frame update
    public float speed = 1.0f;


    private void Awake()
    {
        obstacles = this.transform.GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
