using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyCoordinator))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 5;

    [Tooltip("Adds amouint to maxHitPoints when enemy dies")]
    [SerializeField] int dificultyRamp = 2;

    float currentHitPoints = 0;

    EnemyCoordinator enemy;
    [SerializeField] Slider slider;
    [SerializeField] GameObject SliderAsObject;
    [SerializeField] ParticleSystem deadParticles;
    [SerializeField] GameObject enemyMesh;
    [SerializeField] AudioSource explosionSound;
    

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        slider.value = CalculateHealth();
        SliderAsObject.SetActive(true);
        enemyMesh.SetActive(true);
        gameObject.SetActive(true);
    }

    void Start()
    {
        enemy = GetComponent<EnemyCoordinator>();
    }

    private void Update()
    {
        slider.value = CalculateHealth();
    }

    private void OnParticleCollision(GameObject other)
    {
        HitProcess();
    }

    void HitProcess()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            SliderAsObject.SetActive(false);
            enemyMesh.SetActive(false);
            deadParticles.Play();
            explosionSound.Play();
            Invoke(nameof(DeadSequence), 0.5f);
            
        }
    }

    float CalculateHealth()
    {
        return currentHitPoints / maxHitPoints;
    }

    void DeadSequence()
    {
        gameObject.SetActive(false);
        maxHitPoints += dificultyRamp;
        enemy.RewardPoint();
        explosionSound.Stop();
    }
}
