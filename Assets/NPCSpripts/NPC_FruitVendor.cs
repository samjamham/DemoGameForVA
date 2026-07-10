using UnityEngine;

public class NPC_FruitVendor: NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        setUpDialogBox();

        if (gameManager.GetHeardClip("ChangeMe", "helpme")) //IF PLAYER VISITS FRUIT VENDOR AND DELIVERS PIE
        {
            Dialogbox.GetComponent<Dialogue>().StartDialogue(10);
            return;
        }

        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
        
    }
}
