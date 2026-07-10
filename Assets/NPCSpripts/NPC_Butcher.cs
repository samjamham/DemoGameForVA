using UnityEngine;

public class NPC_Butcher: NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        setUpDialogBox();

        if (gameManager.GetHeardClip("ChangeMe", "helpme")) // The fruit vendor made this for you. (Give smoothie)
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(10);
            return;
        }

        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
        
    }
}
