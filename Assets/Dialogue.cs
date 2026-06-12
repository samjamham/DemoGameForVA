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
    public float textSpeed;
    private int index;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDialogue();
    }

    // Display the DialoguePanel and refresh back to clear 
    public void StartDialogue()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        NextLine(index);
        InputSystem.actions.Disable();
    }

    // Type each line letter by letter 
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].Line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextButtonPressed(int i)
    {
        // Line of text has finnished typing
        if (textComponent.text == lines[index].Line)
        {
            NextLine (i);
        }
        // Line of text has not finished typing
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index].Line;
        }
    }

    void NextLine(int i)
    {
        // The current line of text is not an end line (Terminator / end of array)
        if (index < lines.Length - 1 && !lines[index].Terminator)
        {
            index = i;
            // Clear the panel and remove any buttons
            textComponent.text = string.Empty;
            foreach (Transform child in buttonsLayout.transform)
            {
                Destroy(child.gameObject);
            }

            StartCoroutine (TypeLine());
            // Create buttons to take the dialogue to the index specified 
            if (lines[index].Choises.Length == 0)
            {
                GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform);
                string Text = lines[index].Terminator || !(index < lines.Length - 1) ? "Close" : "Next";
                choiseButton.GetComponentInChildren<TMP_Text>().text = Text;
                choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(index + 1));

            }
            else
            {
                int k = 0;
                foreach (int j in lines[index].NextLines)
                {
                    GameObject choiseButton = Instantiate(ButtonPrefab, buttonsLayout.transform);
                    choiseButton.GetComponentInChildren<TMP_Text>().text = lines[index].Choises[k++];
                    choiseButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => this.NextButtonPressed(j));
                }
            }
        }
        else
        {
            index = 0;
            gameObject.SetActive(false);
            InputSystem.actions.Enable();
        }
        return;
    }
}
