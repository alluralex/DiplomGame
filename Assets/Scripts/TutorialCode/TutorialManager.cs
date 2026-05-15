using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    [TextArea(3, 5)]
    public List<string> tutorialSteps;
    public InputActionReference nextStepAction;

    [SerializeField] private GameObject InventoryZone;
    [SerializeField] private GameObject CraftZone;
    [SerializeField] private GameObject BakeZone;
    [SerializeField] private GameObject UpgradeZone;
    [SerializeField] private GameObject BuyPlaceZone;
    [SerializeField] private GameObject ShopZone;

    private int currentStep = 0;
    private PlayerInput playerInput;

    void Start()
    {
        if (nextStepAction != null)
            nextStepAction.action.performed += OnNextStep;

        playerInput = FindFirstObjectByType<PlayerInput>();
        ShowStep(currentStep);
    }

    void OnDestroy()
    {
        if (nextStepAction != null)
            nextStepAction.action.performed -= OnNextStep;
    }

    void OnNextStep(InputAction.CallbackContext context)
    {
        NextStep();
    }

    public void NextStep()
    {
        currentStep++;
        if (currentStep < tutorialSteps.Count)
            ShowStep(currentStep);
        else
            EndTutorial();
    }

    void ShowStep(int index)
    {
        tutorialText.text = tutorialSteps[index];
        tutorialPanel.SetActive(true);
    }

    void EndTutorial()
    {
        tutorialPanel.SetActive(false);
        this.enabled = false;
    }
}