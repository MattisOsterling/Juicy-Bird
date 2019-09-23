using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public List<GameObject> backGrounds;
    public GameObject backGroundtest;

    public bool hasMadeNewBG;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* GameObject.Find("Player").GetComponent<NewBehaviourScript>().yta += bGroundTime;
         

         if (bGroundTime <= 0)
         {
             GameObject bGAmount = new GameObject();
             bGAmount = Instantiate(backGroundtest, new Vector3(3, 2, 0), Quaternion.identity);
             backGrounds.Add(bGAmount);
             bGroundTime = 4;
         }

         for (int i = 0; i < backGrounds.Count; i++)
         {
             backGrounds[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
         }

         if (backGrounds.Count > 3)
         {
             Destroy(backGrounds[0]);
             backGrounds.RemoveAt(0);
         }*/

        if (GameObject.Find("Player").GetComponent<NewBehaviourScript>().bGroundTime <= 0)
        {
            Instantiate(backGroundtest, new Vector3(6,2,0), Quaternion.identity);
            GameObject.Find("Player").GetComponent<NewBehaviourScript>().bGroundTime = 5;
        }

        backGroundtest.transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        if (backGroundtest.transform.position.x < GameObject.Find("Player").transform.position.x - 5.2)
        {
            Destroy(gameObject);
        }
    }
}
