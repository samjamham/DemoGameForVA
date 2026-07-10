using UnityEngine;

public class NPC_Red : NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        setUpDialogBox();

        if (!gameManager.GetHeardClip("11_1"))
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        }
        else
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(3);
        }
        return;
        
    }
}
