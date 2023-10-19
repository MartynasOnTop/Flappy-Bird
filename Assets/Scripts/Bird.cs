using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public int score = 0;
    Rigidbody2D rb;
    public GameObject endScreen;

    public GameObject blueBird;
    public GameObject redBird;
    public GameObject yellowBird;

    public GameObject day;
    public GameObject night;

    public GameObject flash;

    public float speed;

    public AudioSource die;
    public AudioSource hit;
    public AudioSource flap;
    public AudioSource swoosh;
    public AudioSource point;

    public TMP_Text Points;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        endScreen.SetActive(false);
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
            flap.Play();
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;

        Invoke("ShowMenu", 1f);
        //var sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName);

        PlayerPrefs.SetInt("Score", score);

        flash.SetActive(true);

        die.Play();
        hit.Play();
    }

    void ShowMenu()
    {
        print("The End");
        endScreen.SetActive(true);
        Points.ClearMesh(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        point.Play();
        Points.text = score.ToString();
    }
}
