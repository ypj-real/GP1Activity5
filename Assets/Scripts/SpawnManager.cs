using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject orbPrefab;
    public Transform spawnPoint;
    public int orbCount = 5;
    public float spawnRadius = 6f;
    public float orbHeight = 0.8f;
    public float clearance = 0.6f;

    void Start()
    {
        int spawned = 0, attempts = 0;
        while (spawned < orbCount && attempts < 300)
        {
            attempts++;
            Vector2 c = Random.insideUnitCircle * spawnRadius;
            Vector3 pos = spawnPoint.position + new Vector3(c.x, 0f, c.y);
            pos.y = orbHeight;
            // skip positions inside obstacles / other orbs
            if (Physics.CheckSphere(pos, clearance, ~0, QueryTriggerInteraction.Collide)) continue;
            Instantiate(orbPrefab, pos, Quaternion.identity, transform);
            spawned++;
        }
        if (GameManager.Instance != null) GameManager.Instance.SetTotal(spawned);
    }
}
