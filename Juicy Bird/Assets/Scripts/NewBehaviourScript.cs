using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    

    public GameObject player;
    public Rigidbody fysik;
    public bool lose;
    public float yta;
    public bool start;
    public List<GameObject> ajj;
    public GameObject pipeDown;
    public GameObject pipeUp;
    public float tid;
    public AudioSource ljud;
    /*
    public Text points;
    public float pointsIgen;
    public float pointsPerSecond;
    */

    // Start is called before the first frame update
    void Start()
    {
        yta = gameObject.transform.GetSiblingIndex();
        tid = 3;
        //pointsPerSecond = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //points.text = "Score: " + pointsIgen.ToString("F0");
        //pointsIgen += pointsPerSecond * Time.deltaTime;
        yta += tid;
        tid -= Time.deltaTime;
        if (tid <= 0)
        {
            GameObject typ = new GameObject();
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                typ = Instantiate(pipeDown, new Vector3(3, 2f, 0), Quaternion.identity);

            }
            if (r == 1)
            {
                yta = transform.position.y;
                typ = Instantiate(pipeUp, new Vector3(3, 1f, 0), Quaternion.identity);
            }
            ajj.Add(typ);
            tid = 3;
        }

        if (start == true)
        {
            if (lose != true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fysik.AddForce(Vector3.up * 250);
                }
            }
        }

        if (lose == true)
        {
            if (ljud.isPlaying == false)
            {
                if (yta == 13)
                {
                    yta = yta / yta;
                }
                ljud.Play();
                Invoke("RestartScene", 4);
            }
            
            fysik.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("lost");
        }

        if (ajj.Count > 10)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        if (start == true)
        {
            if (lose == false)
            {
                
                //pointsIgen += 1 * Time.time;
            }
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (start == false)
        {
            fysik.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (lose == false)
            {
                fysik.constraints = RigidbodyConstraints.None;
                fysik.constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("started");
            }
            
        }

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                fysik.AddForce(Vector3.up * 250);
            }
        }

    }

    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "DONTTOUCH")
        {
            lose = true;
        }
    }
}
