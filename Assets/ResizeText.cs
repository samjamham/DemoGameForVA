using TMPro;
using UnityEngine;

public class ResizeText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().enableAutoSizing = false;
        GetComponent<TextMeshProUGUI>().fontSize = 20;
        GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
    }
}
