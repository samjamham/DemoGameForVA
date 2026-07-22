using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using dialoguetree;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;
using System.Data.SqlTypes;
using System.Linq;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI titleComponent;
    public HorizontalOrVerticalLayoutGroup buttonsLayout;
    public GameObject PortraitComponent;
    public GameObject ButtonPrefab;
    public DialogueTree[] lines;
    public int NPCID;
    public float textSpeed;
    public VoiceLinePlayer VLPlayer;

    private int myIndex;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Display the DialoguePanel and refresh back to clear 
    public void StartDialogue(int index)
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        PortraitComponent.GetComponent<Animator>().SetInteger("NPCID", NPCID);
        myIndex = 0;
        NextLine(index);
        InputSystem.actions.Disable();
    }

    // Type each line letter by letter 
    IEnumerator TypeLine()
    {
        int skips = 0;
        //int Pos = -1;
        foreach (var c in lines[myIndex].Line.ToCharArray().Select((value, i) => new {value, i}))
        {
            // Dont type out rich text elements 
            //Pos++;
            if (skips > 0)
            {
                skips--;
                continue;
            }
            if (c.value/*c*/ == '<')
            {
                int CharPos = lines[myIndex].Line.Substring(c.i/*Pos*/).IndexOf('>'); // Find the next instance of '>' after current character
                skips = CharPos;
                string richTextElement = lines[myIndex].Line.Substring(c.i/*Pos*/, CharPos + 1);
                textComponent.text += richTextElement;
                continue;
            }
            // Type current character then wait for a delay
            textComponent.text += c.value/*c*/;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextButtonPressed(int i)
    {
        if (FinishTyping())
            return;

        // Line of text has finnished typing
        gameManager.AddHeardClip(NPCID.ToString() + "_" + myIndex.ToString(), textComponent.text);
        VLPlayer.StopClip();

        foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (NPC.GetComponent<NPCBase>().getID() == NPCID)
            {
                if (lines[myIndex].Choises.Length > 0)
                {
                    if (NPC.GetComponent<NPCBase>().SwapChecker(myIndex, i))
                        return;
                }
                if (NPC.GetComponent<NPCBase>().SwapChecker(myIndex))
                    return;
            }
        }

        if (!IsLastLine())
        {
            NextLine(i);
            return;
        }
        return;
    }
    private bool FinishTyping()
    {
        if (textComponent.text != lines[myIndex].Line)
        {
            StopAllCoroutines();
            textComponent.text = lines[myIndex].Line;
            return true;
        }

        return false;
    }

    bool IsLastLine() // The current line of text is an end line (End of array / Terminator )
    {        
        if (myIndex >= lines.Length - 1 || lines[myIndex].Terminator)
        {
            myIndex = 0;
            gameObject.SetActive(false);
            InputSystem.actions.Enable();
            return true;
        }
        return false;
    }
    void NextLine(int i)
    { 
        myIndex = i;
        // Clear the panel and remove any buttons
        textComponent.text = string.Empty;
        foreach (Transform child in buttonsLayout.transform)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(TypeLine());
        VLPlayer.PlayClip(NPCID.ToString() + "_" + i.ToString());

        // Create buttons to take the dialogue to the index specified 
        if (lines[myIndex].Choises.Length == 0) //default option
        {
            string Text = lines[myIndex].Terminator || !(myIndex < lines.Length - 1) ? "Close" : "Next";
            createChoiceButton(Text, myIndex + 1);
        }
        else
        {
            //create a button for each option
            int k = 0;
            foreach (Choises j in lines[myIndex].Choises)
            {
                string Text = lines[myIndex].Choises[k++].Response;
                createChoiceButton(Text, j.NextLineID);
            }
        }
        return;
    }

    void createChoiceButton(string text, int index)
    {
        GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform); //create button from a prefab as a child of the layout group
        choiseButton.GetComponentInChildren<TMP_Text>().text = text;        
        choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(index)); 
        //choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => gameManager.AddHeardClip(NPCID.ToString() + "_" + myIndex.ToString()));
    }
}
