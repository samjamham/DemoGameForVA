using UnityEngine;

public class NPC_Shepherd : NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        setUpDialogBox();

        if (gameManager.GetHeardClip("11_1"))
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(3);
            return;
        }
        if (gameManager.GetHeardClip("ChangeMe")) //Has told the kids to apologise
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(5);
            return;
        }

        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
        
    }
}
