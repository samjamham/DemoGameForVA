using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private bool CanInteract;
    [SerializeField]
    private string DestinationName;
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
        throw new System.NotImplementedException();
    }

    public void interact()
    {
        SceneManager.LoadScene(DestinationName);
        return;
        throw new System.NotImplementedException();
    }
}
