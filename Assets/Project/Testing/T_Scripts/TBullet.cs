using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBullet : MonoBehaviour
{

    public float shootingForce = 10f;
    public Vector3 shootingDirection;
    public GameObject explosionPrefab;

    public float lifetime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(shootingDirection * shootingForce);
    }

    private void Awake()
    {
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy (gameObject);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "TriggerExplosion")
        {
            GameObject explosionObject = Instantiate(explosionPrefab);
            explosionObject.transform.position = transform.position;
        }
    }
}
