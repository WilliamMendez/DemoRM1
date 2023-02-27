using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lvlManager : MonoBehaviour
{
    float tilling = 1;


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
                    if (!child.name.Contains("inicio"))
                    {
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
        // set the skybox material X tilling to 1
        RenderSettings.skybox.SetFloat("_TilingX", 1);

    }


    public static T[] CreateCombinedArrayFrom<T>(T[] first, T[] second)
    {
        T[] result = new T[first.Length + second.Length];
        Array.Copy(first, 0, result, 0, first.Length);
        Array.Copy(second, 0, result, first.Length, second.Length);
        return result;
    }

    // method for changing the skybox material tilling to the next stage
    // it adds 0.3 to the X tilling
    public void changeSkyboxTilling()
    {
        // get the skybox material
        GameObject skybox = GameObject.Find("SkyDome");
        Material skyboxMaterial = skybox.GetComponent<Renderer>().material;
        // add 0.3 to the tilling smootly
        for (int i = 0; i < 60; i++)
        {
            tilling += 0.005f;
            // set the new tilling
            skyboxMaterial.mainTextureScale = new Vector2(tilling, 1);
            // wait for 0.01 seconds
            System.Threading.Thread.Sleep(10);
        }

        // tilling += 0.3f;
        // Debug.Log("New tilling: " + tilling);
        // // set the new tilling
        // skyboxMaterial.mainTextureScale = new Vector2(tilling, 1);
    }

    // close the application on escape key press
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        // get key press for changing the level by calling the button click method
        GameObject ui;
        ui = GameObject.Find("UI");

        if (Input.GetKey("1"))
        {
            UnityEngine.UI.Button button = ui.transform.Find("lvl1").GetComponent<UnityEngine.UI.Button>();
            button.onClick.Invoke();
        }
        else if (Input.GetKey("2"))
        {
            UnityEngine.UI.Button button = ui.transform.Find("lvl2").GetComponent<UnityEngine.UI.Button>();
            button.onClick.Invoke();
        }
        else if (Input.GetKey("3"))
        {
            UnityEngine.UI.Button button = ui.transform.Find("lvl3").GetComponent<UnityEngine.UI.Button>();
            button.onClick.Invoke();
        }
        else if (Input.GetKey("4"))
        {
            UnityEngine.UI.Button button = ui.transform.Find("lvl4").GetComponent<UnityEngine.UI.Button>();
            button.onClick.Invoke();
        }
        else if (Input.GetKey("5"))
        {
            UnityEngine.UI.Button button = ui.transform.Find("lvl5").GetComponent<UnityEngine.UI.Button>();
            button.onClick.Invoke();
        }


    }
}
