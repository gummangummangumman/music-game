using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaTrap4 : MonoBehaviour
{
    private float clock = 0;
    private float speed = 6;
    public GameObject lightbeam;
    public GameObject prebeam;
    Vector2 originalPos;
    private Vector2 offset;
    private float countdown = 1.7f;
    private float delay = 1.7f;
    private bool readyBool = false;
    private bool shoot = false;
    private bool hide = false;
    private int spawnPrebeam = 0;


    void Start()
    {
        originalPos = transform.position;
        offset = Vector2.up * 1.14f;
    }

    void Update()
    {
        clock += Time.deltaTime;

        if (readyBool)
        {
            spawnPrebeam++;
            // transform.position = Vector3.MoveTowards(transform.position, originalPos + offset, speed * Time.deltaTime); 
            countdown -= Time.deltaTime;
        }

        if (spawnPrebeam == 1)
        {
            Instantiate(prebeam, new Vector2(1.79f, 0), Quaternion.Euler(0, 0, 0));
        }

        if (countdown <= 0)
        {
            readyBool = false;
            spawnPrebeam = 0;
            shoot = true;
        }

        if (shoot)
        {
            Instantiate(lightbeam, new Vector2(1.79f, 0), Quaternion.Euler(0, 0, 0));
            countdown = 1.7f;
            hide = true;
        }

        if (hide)
        {
            shoot = false;
            // transform.position = Vector3.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            hide = false;
            delay = 1.7f;
        }

        if (clock > 9 && clock < 10) //first trigger
            readyBool = true;
        if (clock > 13 && clock < 14) //second trigger
            readyBool = true;
        if (clock > 36 && clock < 37) //third trigger
            readyBool = true;
        if (clock > 47 && clock < 48) //fourth trigger
            readyBool = true;
        if (clock > 57.4 && clock < 58.4) //fourth trigger
            readyBool = true;
        if (clock > 90 && clock < 91) //fifth trigger
            readyBool = true;
        if (clock > 94 && clock < 95) //sixth trigger
            readyBool = true;
    }
}