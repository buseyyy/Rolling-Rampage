using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject focalPoint;

    [Header("Player")]
    [SerializeField] float playerSpeed;

    [Header("PowerUP")]
    [SerializeField] bool hasPowerup = false;
    [SerializeField] GameObject powerupIndicator;
    float powerupStrength = 15;





    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float vertical = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * vertical * playerSpeed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.4f, 0);

        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }


    } 

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup == true)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayForPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayForPlayer * powerupStrength, ForceMode.Impulse);

        }
    }
}
