using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button gameOverCloseButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [SerializeField] private PlayerController playerController;

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0 && startButton != null)
            startButton.onClick.AddListener(StartGame);

        else if (currentSceneIndex == 1)
        {
            if (pauseButton != null) pauseButton.onClick.AddListener(TogglePause);
            if (exitButton != null) exitButton.onClick.AddListener(ExitGame);
            if (gameOverCloseButton != null) gameOverCloseButton.onClick.AddListener(CloseButton);

            if (playerController != null)
            {
                if (leftButton != null)
                {
                    EventTrigger trigger = leftButton.gameObject.AddComponent<EventTrigger>();
                    AddEventTrigger(trigger, EventTriggerType.PointerDown, () => playerController.MoveLeft(true));
                    AddEventTrigger(trigger, EventTriggerType.PointerUp, () => playerController.MoveLeft(false));
                }

                if (rightButton != null)
                {
                    EventTrigger trigger = rightButton.gameObject.AddComponent<EventTrigger>();
                    AddEventTrigger(trigger, EventTriggerType.PointerDown, () => playerController.MoveRight(true));
                    AddEventTrigger(trigger, EventTriggerType.PointerUp, () => playerController.MoveRight(false));
                }
            }
            else
            {
                Debug.LogError("PlayerController not added to ButtonManager on the scene.");
            }
        }
        else
        {
            Debug.LogError("Some Button is not assigned in the Inspector.");
        }
    }

    private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction action)
    {
        EventTrigger.Entry entry = new() { eventID = eventType };
        entry.callback.AddListener((eventData) => action());
        trigger.triggers.Add(entry);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1f) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void CloseButton()
    {
        SceneManager.LoadScene(0);
    }
}
