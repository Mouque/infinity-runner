using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;

    public int damage;

    public GameObject expPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * speed;
    }

    public void OnHit()
    {
        GameObject e = Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(e, 0.3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.layer == 6)
        {
            OnHit();
        }
    }


}
