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
    public GameObject pipetack;
    public GameObject NERIPE;
    public float tid;
    public AudioSource ljud;
    /*
    public Text points;
    public float pointsIgen;
    public float pointsPerSecond;
    */

    public List<GameObject> backGrounds;
    public GameObject backGroundtest;
   
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
        points.text = "Score: " + pointsIgen.ToString("F0");
        
        yta += tid;
        tid -= Time.deltaTime;
        if (tid <= 0)
        {
            GameObject typ = new GameObject();
            GameObject bGAmount = new GameObject();
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                typ = Instantiate(pipetack, new Vector3(4, 2.5f, 0), Quaternion.identity);
                //bGAmount = Instantiate(backGroundtest, new Vector3(0, 2, 0), Quaternion.identity);
            }
            if (r == 1)
            {
                yta = transform.position.y;
                typ = Instantiate(NERIPE, new Vector3(4, 0.6f, 0), Quaternion.identity);
                //bGAmount = Instantiate(backGroundtest, new Vector3(0, 2, 0), Quaternion.identity);
            }
            ajj.Add(typ);
            //backGrounds.Add(bGAmount);
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
            pointsIgen += pointsPerSecond * Time.deltaTime;
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
            pointsPerSecond = 0;
        }

        if (ajj.Count > 10)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        /*if (backGrounds.Count > 3)
        {
            Destroy(backGrounds[0]);
            backGrounds.RemoveAt(0);
        }
        for (int i = 0; i < backGrounds.Count; i++)
        {
            backGrounds[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }*/
        

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
