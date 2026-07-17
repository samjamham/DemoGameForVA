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

    public int getID()
    {
        return ID;
    }


    virtual public void interact()
    {
        Debug.Log($"Blleeehhhh im an {this.name}!");
        Debug.LogError($"Implement override for interact on {this.name}!");
        return;
    }

    protected void setUpDialogBox()
    {
        Dialogbox.GetComponent<Dialogue>().lines = MyLines;
        Dialogbox.GetComponent<Dialogue>().NPCID = ID;
    }

    virtual public bool SwapChecker(int CurrentIndex)
    {
        return false;
    }
    virtual public bool SwapChecker(int CurrentIndex, int Choise)
    {
        return false;
    }

    virtual public void DialogueSwap(int Index) 
    {
        setUpDialogBox();
        Dialogbox.GetComponent<Dialogue>().StartDialogue(Index);
        return;
    }

    protected NPCBase FindNPCByID(int ID)
    {
        foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (NPC.GetComponent<NPCBase>().getID() == ID)
                return NPC.GetComponent<NPCBase>();
        }
        return null;
    }
   
}
