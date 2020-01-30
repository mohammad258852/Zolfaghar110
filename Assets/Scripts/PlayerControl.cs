using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    public ETCJoystick joystick;
    public GameObject bullet;
    public GameObject bullPos;
    public float speed;
    int dir;
    float timer;
    public float minX;
    public float maxX;
    // Use this for initialization
    void Start()
    {
        dir = 1;
        anim = gameObject.GetComponent<Animator>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AnimHandle();
    }
    void AnimHandle()
    {
        if (joystick.axisX.axisValue == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }
    void Move()
    {
        float joyX = joystick.axisX.axisValue;
        Vector3 movement = new Vector3(joyX, 0, 0) * speed * Time.deltaTime;
        if (joyX < 0 && dir == 1)
        {
            transform.Rotate(0, 180, 0);
            dir = -1;
            movement.x = -movement.x;
        }
        if (joyX > 0 && dir == -1)
        {
            transform.Rotate(0, 180, 0);
            dir = 1;
            movement.x = -movement.x;
        }
        transform.position += movement;
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }

    public void Shoot()
    {
        GameObject bul = Object.Instantiate(bullet, bullPos.transform.position, Quaternion.identity);
        bul.SendMessage("SetDir", dir);
    }
}
