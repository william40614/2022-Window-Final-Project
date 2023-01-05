using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class dialogue_box : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button continueButton;
    public Image bg;

    private string[] dialogueLines;
    private int currentLine;

    void Start()
    {
        bg.enabled = true;
        continueButton.gameObject.SetActive(true);
        continueButton.onClick.AddListener(ShowNextLine);

        dialogueLines = new string[]
        {
            "Line 1",
            "Line 2",
            "Line 3",
        };

        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }


    public void ShowNextLine()
    {
        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            // End of dialogue
            continueButton.gameObject.SetActive(false);
            bg.enabled = false;
        }
        else
        {
            dialogueText.text = dialogueLines[currentLine];
        }
    }
}
