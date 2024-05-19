using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlusPoint : MonoBehaviour
{
    //public ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Destroy PlusPoint if it touches the ground
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddPoints(4);
            }

            PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();

            playerMove.isGrounded = true;

            Debug.Log($"{playerMove.isGrounded}");


            //// Add points to the score and destroy PlusPoint
            //if (scoreManager != null)
            //{
            //    scoreManager.AddPoints(3); // Assuming score is incremented by 1 point
            //}
            Destroy(gameObject);
        }
    }
}
