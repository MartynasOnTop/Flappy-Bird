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

    public float speed;

    public TMP_Text Points;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        endScreen.SetActive(false);

        if (Random.Range(1, 3) == 1)
        {
            blueBird.SetActive(true);
            day.SetActive(true);
        }
        else if (Random.Range(1, 3) == 2)
        {
            redBird.SetActive(true);
            night.SetActive(true);
        }
        else
        {
            yellowBird.SetActive(true);
            day.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
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
        score = 0;
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
        Points.text = score.ToString();
    }
}
