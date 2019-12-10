using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            
            player.MyGround = true;

        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            player.MyGround = true;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

        player.MyGround = false;

    }
}
