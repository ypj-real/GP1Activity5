using UnityEngine;
using UnityEngine.SceneManagement;

// Needs a Collider with Is Trigger ON.
[RequireComponent(typeof(Collider))]
public class ExitPortal : MonoBehaviour
{
    public string winSceneName = "WinScene";
    public bool requireAllOrbs = true;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (requireAllOrbs && GameManager.Instance != null && !GameManager.Instance.AllCollected)
        {
            GameManager.Instance.ShowMessage("Collect all the energy orbs first!");
            return;
        }
        SceneManager.LoadScene(winSceneName);
    }
}
