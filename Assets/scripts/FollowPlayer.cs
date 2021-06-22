using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length == 0)
            {
                Destroy(gameObject);
            }
            player = players[0].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x - 6.88f, player.position.y + 10, player.position.z - 6.88f);
    }
}
