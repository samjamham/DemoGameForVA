using System;
using UnityEngine;
using dialoguetree;

public class NPC : MonoBehaviour, Iinteractable
{
    [SerializeField] protected bool CanInteract;
    //[SerializeField] protected string[] MyLines;
    [SerializeField] protected DialogueTree[] MyLines;
    [SerializeField] protected GameObject Dialogbox;
    [SerializeField] protected int ID;
    protected GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        FindGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool canInteract()
    {
        return CanInteract;
    }

    virtual public void interact()
    {
        Debug.Log($"Blleeehhhh im an {this.name}!");
        Dialogbox.GetComponent<Dialogue>().lines = MyLines;
        Dialogbox.GetComponent<Dialogue>().NPCID = ID;
        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
    }
    protected void FindGameManager()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
}
