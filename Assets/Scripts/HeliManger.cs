using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeliManger : MonoBehaviour
{
    public ETCButton button;
    public GameObject endLevel;
    Image butImage;
    public float speed;
    public float minDistPos;
    public float landingSpeed;
    public GameObject bombPlace;
    //public GameObject message;
    int maxEdge;
    int deltaEdge;
    int dir;
    public GameObject landingPositionObj;
    Vector3 landingPosition;
    int landing;
    public ETCJoystick joystick;
    public GameObject bomb;
    public float bombDistanceTime = 1;
    float timer;
    public float minDistBomb;

    float maxX;
    float minX;
    float maxY;
    float minY;
    // Use this for initialization
    void Start()
    {
        timer = minDistBomb;
        dir = 1;
        maxEdge = 12;
        landing = 0;
        landingPosition = landingPositionObj.transform.position;
        maxX = 8f;
        minX = -8f;
        maxY = 4f;
        minY = 0f;
        butImage = button.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (landing == 0)
        {
            butImage.fillAmount = timer / minDistBomb;
            HeliMove();
        }
        else if (landing == 1)
        {
            Land();
        }
        Vector3 dist = landingPosition - gameObject.transform.position;
        if (SizeofVec(dist) < minDistPos)
        {
            endLevel.SetActive(true);
            landing = 2;
            //Instantiate(message, transform.position, Quaternion.identity);
        }
    }
    public void HeliMove()
    {
        Vector3 movement = new Vector3(joystick.axisX.axisValue, joystick.axisY.axisValue, 0) * speed;
        float joystickX = movement.x;
        if (joystickX < 0 && dir == 1)
        {
            transform.Rotate(0, 180, 0);
            dir = -1;
            movement.x = -movement.x;
        }
        if (joystickX > 0 && dir == -1)
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
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }

    public void MakeBomb()
    {
        if (timer >= minDistBomb)
        {
            timer = 0;
            Vector3 bombPosition = bombPlace.transform.position;
            Object.Instantiate(bomb, bombPosition, Quaternion.identity);
        }
    }
    float SizeofVec(Vector3 n)
    {
        return Mathf.Sqrt(Mathf.Pow(n.x, 2) + Mathf.Pow(n.y, 2) + Mathf.Pow(n.z, 2));
    }
    void Land()
    {
        Vector3 movement = landingPosition - gameObject.transform.position;
        float moveX = movement.x;
        if (moveX < 0 && dir == 1)
        {
            transform.Rotate(0, 180, 0);
            dir = -1;
            movement.x = -movement.x;
        }
        if (moveX > 0 && dir == -1)
        {
            transform.Rotate(0, 180, 0);
            dir = 1;
            movement.x = -movement.x;
        }
        movement = movement / SizeofVec(movement) * landingSpeed;
        gameObject.transform.position += movement;
    }
    void LandOrder()
    {
        landing = 1;
    }
}
