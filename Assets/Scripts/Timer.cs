using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public float damageInterval = 0.1f;

    private void Start()
    {
        InvokeRepeating("DamagePlayer", damageInterval, damageInterval);
    }

    private void DamagePlayer()
    {
        playerManager.TakeDamage(0.28f);
    }
}