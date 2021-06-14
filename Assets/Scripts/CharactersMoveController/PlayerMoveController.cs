using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveController : MonoBehaviour
{
    private Vector3 playerInput;
    private float verticalMove, horizontalMove;
    private Transform player;
    public float playerSpeed;
    public SpriteRenderer playerImage;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if(horizontalMove < 0)
        {
            playerImage.flipX = true;
        }
        if (horizontalMove > 0)
        {
            playerImage.flipX = false;
        }

        playerInput = new Vector3(horizontalMove, verticalMove, 0);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);


        player.Translate(playerInput * playerSpeed * Time.deltaTime);
    }
}
