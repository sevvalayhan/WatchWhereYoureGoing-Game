using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;

    public float speed=15;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var followDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(followDirection.normalized * speed);
        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
