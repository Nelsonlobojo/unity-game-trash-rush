using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MoverLevelTwo : MonoBehaviour
{
    //Initilaize gameobjects
    public GameObject rb;
    public GameObject cheeseBurger;
    public GameObject sodaCan;
    public GameObject fishBone;
    public GameObject redBin;
    public GameObject blueBin;
    //public Color goodColor;
    //public Color badColor;

    public TMP_Text textDisplay;

    int points = 0;

    // Start is called before the first frame update

    void Start()
    {
         textDisplay.text = "Points:"+ points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the main character
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(0f, 0f, 0.05f);
        }
         if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(0f, 0f, -0.05f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate(-0.05f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate(0.05f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.transform.Rotate(0f, 0.25f, 0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.transform.Rotate(0f, -0.25f, 0f);
        }

        PointsAdding();
        
    }
    //collision function
    void OnCollisionEnter(Collision collision)
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-2F,2F),0F,Random.Range(-2F,2F));
        Vector3 newPost = cheeseBurger.transform.position + randomSpawn;
        Vector3 newPost1 = sodaCan.transform.position + randomSpawn;
        Vector3 newPost2 = fishBone.transform.position + randomSpawn;
        
    
        if (collision.gameObject == cheeseBurger)
        {
            // add points if the player collides with the cheese burger
            points += 1;
            var clone = Instantiate(cheeseBurger, newPost, Quaternion.identity);
            Destroy(cheeseBurger);
            //rb.GetComponent<SkinnedMeshRenderer>().material.color = goodColor;

            clone.name = "cheeseBurger";
            cheeseBurger = clone;

        }
        else if (collision.gameObject == sodaCan)
        {
            // add points if the player collides with the soda can
            points += 2;
            var clone1 =Instantiate(sodaCan, newPost1, Quaternion.identity);
            Destroy(sodaCan);
            //rb.GetComponent<SkinnedMeshRenderer>().material.color = goodColor;

            clone1.name = "sodaCan";
            sodaCan = clone1;
        }
        else if (collision.gameObject == fishBone)
        {
            // add points if the player collides with the fish bone
            points += 5;
            var clone2 = Instantiate(fishBone, newPost2, Quaternion.identity);
            Destroy(fishBone);
            //rb.GetComponent<SkinnedMeshRenderer>().material.color = goodColor;

            clone2.name = "fishBone";
            fishBone = clone2;
        }
        else if (collision.gameObject == redBin)
        {
            // remove points if the player collides with the red bin
            points -= 1;
            //rb.GetComponent<SkinnedMeshRenderer>().material.color = badColor;
        }
        else if (collision.gameObject == blueBin)
        {
            // remove points if the player collides with the blue bin
            points -= 1;
            //rb.GetComponent<SkinnedMeshRenderer>().material.color = badColor;
        }
        
    }
    public void PointsAdding(){
        textDisplay.text = "Points:"+ points.ToString();
    }
}
