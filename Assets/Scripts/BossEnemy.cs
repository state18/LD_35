using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {
    public static int spawnsRemaining;
    [SerializeField]
    private BossEnemy bossPrefab;
    [SerializeField]
    Transform bossBattleBeginning;
    [SerializeField]
    Transform bossBattleLeftBounds;
    [SerializeField]
    Transform bossBattleRightBounds;
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private float bulletLifetime;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    private float maxCooldown;
    private float cooldown;
    [SerializeField]
    private float shotMagnitude;
    [SerializeField]
    LayerMask playerMask;
    [SerializeField]
    private float speed = 3;

    private int direction = 1;
    private int maxHealth = 50;

    // Use this for initialization
    void Start() {
        spawnsRemaining++;
    }

    void Initialize(Vector3 parentScale, int direction, float parentSpeed, int maxHealth) {
        transform.localScale =  parentScale * .5f;
        this.direction = direction;
        speed = parentSpeed * 1.5f;
        this.maxHealth = maxHealth / 2;
        GetComponent<EnemyHealthManager>().Health = this.maxHealth;
        
    }

    // Update is called once per frame
    void Update() {
        if (cooldown >= 0)
            cooldown -= Time.deltaTime;

        if (transform.position.y <= bossBattleBeginning.position.y) {
            transform.position = new Vector3(transform.position.x, bossBattleBeginning.position.y);
            transform.parent = null;
        }

        if (transform.position.x > bossBattleRightBounds.position.x)
            direction = -1;
        else if (transform.position.x < bossBattleLeftBounds.position.x)
            direction = 1;

        transform.position += new Vector3(speed * Time.deltaTime * direction, 0f);

        if (cooldown <= 0)
            Fire();
    }

    void Fire () {
        cooldown = maxCooldown;
        var projectile = (Projectile)Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.Initialize(new Vector2(0f, -shotMagnitude), bulletLifetime);
    }

    void OnDestroy() {
        spawnsRemaining--;
        if (spawnsRemaining <= 0 && GameManager.Instance != null)
            GameManager.Instance.BossDefeated();
    }

    public void Spawn() {
        if (transform.localScale.x >= .5) {
            var spawn = (BossEnemy)Instantiate(bossPrefab, transform.position - Vector3.right, transform.rotation);
            spawn.Initialize(transform.localScale, -1, speed, maxHealth);
            spawn = (BossEnemy)Instantiate(bossPrefab, transform.position + Vector3.right, transform.rotation);
            spawn.Initialize(transform.localScale, 1, speed, maxHealth);
        }
    }

    void LateUpdate() {
        
    }

}
