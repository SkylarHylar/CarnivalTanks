using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    Complete.TankMovement tank;
    public float speed = 720f;
    // Start is called before the first frame update
    void Start()
    {
        tank = transform.parent.gameObject.GetComponent<Complete.TankMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * tank.m_curSpeed, 0);
    }
}
