using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaTrap1 : MonoBehaviour
{
    private float clock = 0;
    private float speed = 4;
    public GameObject lightbeam;
    Vector2 originalPos;
    private Vector2 offset;
    private float countdown = 1.4f;
    private float delay = 1.4f;
    private bool readyBool = false;
    private bool shoot = false;
    private bool hide = false;

    /*void shoot()
    {
        Instantiate(lightbeam, new Vector2(-6.46f, 0), Quaternion.Euler(0, 0, 0));
        delay -= Time.deltaTime;
    }*/

   
    void Start()
    {
        originalPos = transform.position;
        offset = Vector2.up * 0.3f;
    }

    void Update()
    {
        clock += Time.deltaTime;

        if (readyBool)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos + offset, speed * Time.deltaTime);
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyBool = false;
            shoot = true;
        }

        if (shoot)
        {
            Instantiate(lightbeam, new Vector2(-6.46f, 0), Quaternion.Euler(0, 0, 0));
            countdown = 2;
            hide = true;
        }

        if (hide)
        {
            shoot = false;
            transform.position = Vector3.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            hide = false;
            delay = 2;
        }

        if (clock > 5 && clock < 6) //first trigger
            readyBool = true;
        if (clock > 17 && clock < 18) //second trigger
            readyBool = true;
        if (clock > 30 && clock < 31) //third trigger
            readyBool = true;
        if (clock > 57.5 && clock < 59) //fourth trigger
            readyBool = true;
        if (clock > 80 && clock < 81) //fifth trigger
            readyBool = true;
        if (clock > 100 && clock < 101) //sixth trigger
            readyBool = true;
    }
}