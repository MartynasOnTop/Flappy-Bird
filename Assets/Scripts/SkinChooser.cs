using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChooser : MonoBehaviour
{
    public GameObject blueBird;
    public GameObject redBird;
    public GameObject yellowBird;

    public GameObject day;
    public GameObject night;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, transform.childCount);
        transform.GetChild(i).gameObject.SetActive(true);


    }
}
