using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonDialogueTrigger : MonoBehaviour
{

 

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    // Start is called before the first frame update
    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().DialogueIsPlaying)
        {
           
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                Debug.Log(inkJSON.text);
            

        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;

            Destroy(gameObject);
        }
    }
}
