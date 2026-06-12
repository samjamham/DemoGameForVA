using System;
using UnityEngine;
using dialoguetree;

public class NPC : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private bool CanInteract;
    [SerializeField]
    //private string[] MyLines;
    private DialogueTree[] MyLines;
    [SerializeField]
    GameObject Dialogbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool canInteract()
    {
        return CanInteract;
    }

    public void interact()
    {
        Debug.Log($"Blleeehhhh im an {this.name}!");
        Dialogbox.GetComponent<Dialogue>().lines = MyLines;
        Dialogbox.GetComponent<Dialogue>().StartDialogue();
        return;
    }
}
