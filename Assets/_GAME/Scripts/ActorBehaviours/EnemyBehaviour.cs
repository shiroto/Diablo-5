using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public int level;

    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            DropLoot();
            Destroy(gameObject);
        }
    }

    private void DropLoot()
    {

    }

    public void SetLevel(int lvl)
    {
        health += 5 * lvl;
        damage += 2 * lvl;
    }
}
