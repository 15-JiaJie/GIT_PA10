using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     private float _velocity = 200f;
    private Rigidbody _rb;

    private Animation thisAnimation;

    private float MaxY = 3.55f;
    private float MinY = -5.0f;

    public GameManager gm;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();


            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _velocity);
        }
        if (_rb.position.y <= -4.5)
        {
            SceneManager.LoadScene("GameOver");
        }

        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, MinY, MaxY), 0);
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Obstacles")
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreSense")
        {
            //print("Yes");
            GameManager.Score++;
        }
    }
}
