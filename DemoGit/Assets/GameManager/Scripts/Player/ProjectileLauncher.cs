using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    //arrow
    public GameObject projectilePrefab;
    public Transform launcherPoint;
    //bomb
    public Transform bombPoint;
    public GameObject bombPrefabs;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BombProtectile();
        }
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launcherPoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;
            audioManager.PlaySFX(audioManager.rangedAttack);
        //flip
        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z
            );
        
    }
    public void BombProtectile()
    {
        ///bomb
        GameObject projectBomb = Instantiate(bombPrefabs, bombPoint.position, bombPrefabs.transform.rotation);
        Vector3 origScaleBomb = projectBomb.transform.localScale;
        audioManager.PlaySFX(audioManager.dash);

        //flip
        projectBomb.transform.localScale = new Vector3(
            origScaleBomb.x * transform.localScale.x > 0 ? 1 : -1,
            origScaleBomb.y,
            origScaleBomb.z
            );
    }
}
