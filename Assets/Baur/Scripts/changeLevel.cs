using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    bool m_SceneLoaded;
    public bool changeLevelbool;
    public Vector3 reset;
    public GameObject Player;
    // Start is called before the first frame update

    private void Awake()
    {
        reset = new Vector3(0, 0, 0);
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.transform.position = reset;
            changeLevelbool=true;
        }
    }
    void Update()
    {
        if (changeLevelbool)
        {
            Player.transform.position = reset;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}