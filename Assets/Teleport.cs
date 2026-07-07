using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private bool CanInteract;
    [SerializeField]
    private string DestinationName;
    [SerializeField]
    private Vector2 DestinationVector;
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
        //Load new area
        SceneManager.LoadScene(DestinationName);

        //Move the player character to the right XY pos
        Vector2 Dest;
        if (DestinationVector == null)
            Dest = Vector2.zero;
        else
            Dest = DestinationVector;
        GameObject.FindWithTag("Player").transform.position = new Vector2(Dest.x, Dest.y);
        return;
    }
}
