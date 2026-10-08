using System;
using System.Collections.Generic;
using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceController : MonoBehaviour
{
    [SerializeField] private Button choicePrefab;
    [SerializeField] private GameObject choicePanel;
    private List<Button> buttons = new List<Button>();
    
    private void Awake()
    {
        choicePanel.SetActive(false);
    }

    public void InstantiateChoices(DialogueChoice[] choices)
    {
        choicePanel.SetActive(true);
        foreach (var choice in choices)
        {
            Button newButton = Instantiate(choicePrefab, transform);
            buttons.Add(newButton);
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = choice.Choice;

            newButton.onClick.AddListener(() =>
            {
                choicePanel.SetActive(false);
                DialogueManager.Instance.StartDialogue(choice.NextDialogue);
                DestroyAllButtons();
            });
        }
    }

    private void DestroyAllButtons()
    {
        foreach (Button button in buttons)
        {
            if(button != null)
                Destroy(button.gameObject);
        }
        buttons.Clear(); // IMPORTANT - Garbage collection
    }
}