using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysMoveController : MonoBehaviour
{
    private PlayerMoveController d;
    private Transform player;
    private Transform me;
    private Vector3 distancInit, runTo, distance;
    private float xPlayerPos, yPlayerPos;
    public float enemySpeed;
    private double distInit, dist;
    // Start is called before the first frame update
    void Start()
    {
        me = this.GetComponent<Transform>();
        player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
        distancInit = me.transform.position - player.transform.position;
        distInit = VectorResult(distancInit);
    }

    // Update is called once per frame
    void Update()
    {
    }

    double VectorResult(Vector3 vector)
    {
        double result = 0;
        result = Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2);
        result = Math.Sqrt(result);
        return result;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        d = other.GetComponent<PlayerMoveController>();
        if (other.name == "Player(Clone)" && me != null)
        {
            Debug.Log(me.name + " colisionado con el jugador " + other.name);
        }
        Debug.Log("Colision");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(d != null)
        {
            d = null;
            Debug.Log("Salio de la colision ");
        }
    }

}
