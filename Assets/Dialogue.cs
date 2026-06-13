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
using UnityEditor.PackageManager;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public VerticalLayoutGroup buttonsLayout;
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
        //TODO move vvvv
        NPCID = 10;
        StartDialogue(0);
        //TODO move ^^^^
    }

    // Display the DialoguePanel and refresh back to clear 
    public void StartDialogue(int index)
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        myIndex = 0;
        NextLine(index);
        InputSystem.actions.Disable();
    }

    // Type each line letter by letter 
    IEnumerator TypeLine()
    {
        foreach (char c in lines[myIndex].Line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextButtonPressed(int i)
    {
        // Line of text has finnished typing
        if (textComponent.text == lines[myIndex].Line)
        {
            NextLine (i);
            VLPlayer.StopClip();
        }
        // Line of text has not finished typing
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[myIndex].Line;
        }
    }

    void NextLine(int i)
    {
        // The current line of text is not an end line (Terminator / end of array)
        if (myIndex < lines.Length - 1 && !lines[myIndex].Terminator)
        {
            myIndex = i;
            // Clear the panel and remove any buttons
            textComponent.text = string.Empty;
            foreach (Transform child in buttonsLayout.transform)
            {
                Destroy(child.gameObject);
            }

            StartCoroutine (TypeLine());
            VLPlayer.PlayClip(NPCID.ToString() + "_" + i.ToString());
            // Create buttons to take the dialogue to the index specified 
            if (lines[myIndex].Choises.Length == 0)
            {
                string Text = lines[myIndex].Terminator || !(myIndex < lines.Length - 1) ? "Close" : "Next";
                createChoiceButtons(Text, myIndex +1);
                //TODO Remove Below, only here if something breaks in future 
                /*
                 * GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform);                
                 * choiseButton.GetComponentInChildren<TMP_Text>().text = Text;
                 * choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(myIndex + 1));
                 * choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => gameManager.AddHeardClip(ToString() + "." + myIndex.ToString()));
                 */

            }
            else
            {
                int k = 0;
                foreach (int j in lines[myIndex].NextLines)
                {
                    string Text = lines[myIndex].Choises[k++];
                    createChoiceButtons(Text, j);
                    //TODO Remove Below, only here if something breaks in future 
                    /*
                     * GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform);
                     * choiseButton.GetComponentInChildren<TMP_Text>().text = lines[myIndex].Choises[k++];
                     * choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(j));
                     * choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => gameManager.AddHeardClip(NPCID.ToString() + "." + myIndex.ToString()));
                     */
                }
            }
        }
        else
        {
            myIndex = 0;
            gameObject.SetActive(false);
            InputSystem.actions.Enable();
        }
        return;
    }

    void createChoiceButtons(string text, int index)
    {
        GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform);
        choiseButton.GetComponentInChildren<TMP_Text>().text = text;
        choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(index));
        choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => gameManager.AddHeardClip(NPCID.ToString() + "." + myIndex.ToString()));
    }
}
