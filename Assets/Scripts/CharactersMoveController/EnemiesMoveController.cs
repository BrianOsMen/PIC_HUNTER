using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesMoveController : MonoBehaviour
{

    private PlayerMoveController d;
    private Transform player;
    private Transform me;
    private Vector3 runTo;

    [SerializeField]
    private float xPlayerPos, yPlayerPos, xMePos, yMePos, distanceX,
                    distanceY, denominador;

    [SerializeField]
    private double linelDistance;

    public float enemySpeed;
    public SpriteRenderer enemyImage;
    // Start is called before the first frame update
    void Start()
    {
        me = this.GetComponent<Transform>();
        player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcDistance();
        if (linelDistance < 8)
            WalkAway();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Peos");
    }

    private void CalcDistance()
    {

        xPlayerPos = player.position.x;
        yPlayerPos = player.position.y;

        xMePos = me.position.x;
        yMePos = me.position.y;

        distanceX = xPlayerPos - xMePos;
        distanceY = yPlayerPos - yMePos;

        linelDistance = Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2);
        linelDistance = Math.Sqrt(linelDistance);

        if (Mathf.Abs(distanceX) > Mathf.Abs(distanceY))
            denominador = distanceX;
        else
            denominador = distanceY;

        distanceX = distanceX / denominador;
        distanceY = distanceY / denominador;

    }

    private void WalkAway()
    {
        runTo = new Vector3(distanceX, distanceY, 0);

        if (distanceX < 0)
            enemyImage.flipX = true;
        if (distanceX > 0)
            enemyImage.flipX = false;

        me.transform.Translate(runTo * enemySpeed * Time.deltaTime);
    }


}
