using UnityEngine;

public class NPC_Red : NPC
{
    public override void interact()
    {
        Dialogbox.GetComponent<Dialogue>().NPCID = ID;
        Dialogbox.GetComponent<Dialogue>().lines = MyLines;
        if (!gameManager.GetHeardClip(111))
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
            //gameManager.AddHeardClip(1);
        }
        else
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(3);
        }
        return;
        
    }
}
