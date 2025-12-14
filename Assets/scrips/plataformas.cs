using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 2;
    int index = 0;

    public GameObject[] Waypoints { get => Waypoints2; set => Waypoints2 = value; }
    public GameObject[] Waypoints1 { get => Waypoints2; set => Waypoints2 = value; }
    public GameObject[] Waypoints2 { get => waypoints; set => waypoints = value; }

    void Update()
    {

        MovimientoP();
    }

    void MovimientoP()
    {
        if (Vector3.Distance(transform.position, Waypoints[index].transform.position) < 0.1f)
        {
            index++;
            if (index >= Waypoints.Length)
            {
                index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[index].transform.position, speed * Time.deltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}