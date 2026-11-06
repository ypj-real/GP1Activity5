using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text orbCounterText;
    public Text messageText;

    int collected;
    int total;

    public bool AllCollected => total > 0 && collected >= total;

    void Awake() { Instance = this; }

    public void SetTotal(int count)
    {
        total = count;
        UpdateUI();
    }

    public void OrbCollected()
    {
        collected++;
        UpdateUI();
        if (AllCollected) ShowMessage("All orbs collected! Head to the portal!");
    }

    public void ShowMessage(string msg)
    {
        if (messageText != null) messageText.text = msg;
    }

    void UpdateUI()
    {
        if (orbCounterText != null) orbCounterText.text = "Orbs: " + collected + " / " + total;
    }
}
