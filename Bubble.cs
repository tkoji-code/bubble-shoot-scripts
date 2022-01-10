using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //config param
    [SerializeField] GameObject devidedBubblePrefab;
    [SerializeField] float devidedBubbleSpeed = 100f;
    [SerializeField] int numberOfDevides = 4;
    [SerializeField] float invicibleTime = 0.5f;
    [SerializeField] int scoreValue = 100;

    private void Start()
    {
        StartCoroutine(ActivateCollider());
    }

    private IEnumerator ActivateCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(invicibleTime);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player Laser")
        {
            //Destroy(collision.gameObject);
            if (numberOfDevides <= 0)
            {
                Burst();
            }
            else
            {
                Devide();
            }

            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
        }

    }
    private void Burst()
    {
        //effects
    }

    private void Devide()
    {
        for (int count = 0; count < numberOfDevides; count++)
        {
            var devidedBubble = Instantiate(devidedBubblePrefab, transform.position, Quaternion.identity);
            float rotAng = count * 2 * Mathf.PI / numberOfDevides + Mathf.PI / numberOfDevides;
            devidedBubble.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(rotAng), Mathf.Sin(rotAng)) * devidedBubbleSpeed * Time.deltaTime;
        }
    }

}
