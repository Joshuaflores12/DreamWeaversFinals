using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject DialogueSystem;
    public GameObject InteractButton;   
    //Interact Buttons
    public void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (GameObject.FindWithTag("NPC_1"))
                InteractButton.SetActive(true);
        }
    } 
    public void OnTriggerExit2D(Collider2D collision)
    {
        InteractButton.SetActive(false);
    }

    public void DialogueSystemOpen()
    // Interact Button
    {
    DialogueSystem.SetActive(true);

    }
    // Back Button
    public void DialogueSystemClose() 
    {
    DialogueSystem.SetActive(false);
    }

}
