using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lvlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // get all the cylinders with tags from cylinder1 to cylinder5 and enable them
        GameObject[] cylinders = GameObject.FindGameObjectsWithTag("cylinder1");
        for (int i = 2; i < 6; i++)
        {
            GameObject[] cylinders2 = GameObject.FindGameObjectsWithTag("cylinder" + i);
            cylinders = CreateCombinedArrayFrom(cylinders, cylinders2);
        }

        foreach (GameObject cylinder in cylinders)
        {
            cylinder.SetActive(true);
        }

        // get all the levels and disable collision
        GameObject[] levels = GameObject.FindGameObjectsWithTag("lvl1");
        // add the levels with the tag "level2" to "level5"
        for (int i = 2; i < 6; i++)
        {
            GameObject[] levels2 = GameObject.FindGameObjectsWithTag("lvl" + i);
            levels = CreateCombinedArrayFrom(levels, levels2);
        }
        // disable collision for child objects
        foreach (GameObject lvl in levels)
        {
            // if the object contains lvl then enable collision of the child objects
            if (lvl.name.Contains("lvl"))
            {
                foreach (Transform child in lvl.transform)
                {
                    if (!child.name.Contains("inicio")){
                    // check if the child object has a collider or mesh collider
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
            }
            else
            {
                // check if the object has a collider or mesh collider
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

    }


    public static T[] CreateCombinedArrayFrom<T>(T[] first, T[] second)
    {
        T[] result = new T[first.Length + second.Length];
        Array.Copy(first, 0, result, 0, first.Length);
        Array.Copy(second, 0, result, first.Length, second.Length);
        return result;
    }


}
