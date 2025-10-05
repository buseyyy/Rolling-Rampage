using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject playerPosition;

    [Header("Enemy")]
    [SerializeField] float enemySpeed;

    float positionY = -10;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        playerPosition = GameObject.Find("Player");
    }


    private void FixedUpdate()
    {
        Vector3 lookDirection = (playerPosition.transform.position - transform.position).normalized;

        rigidbody.AddForce(lookDirection * enemySpeed);

        if (gameObject.transform.position.y < positionY)
        {
            Destroy(gameObject);
        }
    }
}
