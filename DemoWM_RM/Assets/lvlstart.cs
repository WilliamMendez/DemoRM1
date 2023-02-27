using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlstart : MonoBehaviour
{
    // on collide remove the cilinder and make the level start
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // show the collision on console
            Debug.Log("Collision with " + other.gameObject.name);
            // get the level number from the name of parent
            string level = transform.parent.name;
            // get the level and enable collision

            GameObject[] levels = GameObject.FindGameObjectsWithTag(level);
            foreach (GameObject lvl in levels)
            {
                // if the object contains lvl then enable collision of the child objects
                if (lvl.name.Contains("lvl"))
                {
                    foreach (Transform child in lvl.transform)
                    {
                        // check if the child object has a collider or mesh collider
                        if (child.GetComponent<Collider>() != null)
                        {
                            child.GetComponent<Collider>().enabled = true;
                        }
                        else if (child.GetComponent<MeshCollider>() != null)
                        {
                            child.GetComponent<MeshCollider>().enabled = true;
                        }
                    }
                }
                else
                {
                    // check if the object has a collider or mesh collider
                    if (lvl.GetComponent<Collider>() != null)
                    {
                        lvl.GetComponent<Collider>().enabled = true;
                    }
                    else if (lvl.GetComponent<MeshCollider>() != null)
                    {
                        lvl.GetComponent<MeshCollider>().enabled = true;
                    }
                }
            }
        }
    }
}
