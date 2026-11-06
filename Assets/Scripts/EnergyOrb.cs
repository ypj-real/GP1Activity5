using UnityEngine;

// Prefab setup: Collider (Is Trigger ON) + Rigidbody (kinematic, no gravity).
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class EnergyOrb : MonoBehaviour
{
    public float spinSpeed = 90f;

    void Update() { transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World); }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance != null) GameManager.Instance.OrbCollected();
        Destroy(gameObject); // disappears when collected
    }
}
