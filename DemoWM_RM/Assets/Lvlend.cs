using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using cambiarTexto;

public class lvlEnd : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
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
                // if the object contains lvl then disable collision of the child objects
                if (lvl.name.Contains("lvl"))
                {
                    foreach (Transform child in lvl.transform)
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
            // get the last digit of the level name
            int lvlNum = int.Parse(level.Substring(level.Length - 1));



            // get the UI object
            GameObject ui = GameObject.Find("UI");

            // start the animation
            ui.GetComponent<Animator>().SetTrigger("completo");


            if (lvlNum == 5)
            {
                // wait for the animation to finish
                System.Threading.Thread.Sleep(2000);


                // if the last level is reached then show the end screen
                // get the end screen as a button
                UnityEngine.UI.Button restart = ui.transform.Find("back").GetComponent<UnityEngine.UI.Button>();
                // simulate a click on the end screen button
                restart.onClick.Invoke();
            }
            else
            {

                // trigger the change to the next level with the button on UI.lvl*
                // get the next level button as a button
                UnityEngine.UI.Button nextLvl = ui.transform.Find("lvl" + (lvlNum + 1)).GetComponent<UnityEngine.UI.Button>();

                // simulate a click on the next level button
                nextLvl.onClick.Invoke();
            }
        }
    }
}
