using System;
using UnityEngine;
using dialoguetree;

public abstract class NPCBase : MonoBehaviour, Iinteractable
{
    [SerializeField] protected bool CanInteract;    
    [SerializeField] protected DialogueTree[] MyLines;     //[SerializeField] protected string[] MyLines;
    [SerializeField] protected int ID;

    protected GameManager gameManager;
    protected GameObject Dialogbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Setup();
    }
    protected void Setup()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Dialogbox = gameManager.GetComponent<GameManager>().DialogBox;
    }

    public bool canInteract()
    {
        return CanInteract;
    }

    virtual public void interact()
    {
        Debug.Log($"Blleeehhhh im an {this.name}!");
        //setUpDialogBox();
        //Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
    }

    protected void setUpDialogBox()
    {
        Dialogbox.GetComponent<Dialogue>().lines = MyLines;
        Dialogbox.GetComponent<Dialogue>().NPCID = ID;
    }
   
}
