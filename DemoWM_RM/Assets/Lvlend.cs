using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvlend : MonoBehaviour
{
    private void onTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision with " + other.gameObject.name);
            string level = transform.parent.name;
            GameObject[] levels = GameObject.FindGameObjectsWithTag(level);
            foreach (GameObject lvl in levels)
            {
                if (lvl.name.Contains("lvl"))
                {
                    foreach (Transform child in lvl.transform)
                    {
                        if (child.GetComponent<Collider>() != null)
                        {
                            child.GetComponent<Collider>().enabled = false;
                        }
                        else if (child.GetComponent<MeshCollider>() != null)
                        {
                            child.GetComponent<MeshCollider>().enabled = false;
                        }
                    }
                }
                else
                {
                    if (lvl.GetComponent<Collider>() != null)
                    {
                        lvl.GetComponent<Collider>().enabled = false;
                    }
                    else if (lvl.GetComponent<MeshCollider>() != null)
                    {
                        lvl.GetComponent<MeshCollider>().enabled = false;
                    }
                }
            }

            // get the last character of the name of the parent
            char lvlNumber = transform.parent.name[transform.parent.name.Length - 1];
            // trigger the lvlEnd animation of the lvl+i
            GameObject.Find("lvl" + lvlNumber).GetComponent<Animator>().SetTrigger("2");



        }
    }
}
