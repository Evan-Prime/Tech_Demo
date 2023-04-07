using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    Bomb : MonoBehaviour
{

    public float duration = 5f;
    public float radius = 3f;
    public float explosionDuration = 0.25f;
    public GameObject explosionModel;
    public AudioClip explosionClip;

    private float explosionTimer;
    private bool exploded;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        explosionTimer = duration;
        explosionModel.transform.localScale = Vector3.one * radius;
        explosionModel.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0f && exploded == false)
        {
            exploded = true;
            Collider[] hitObjects = Physics.OverlapSphere (transform.position, radius);
            foreach (Collider collider in hitObjects)
            {
                if (collider.GetComponent<Enemy> () != null)
                {
                    collider.GetComponent<Enemy>().Hit ();
                }
            }

            StartCoroutine(Explode ());
        }
    }

    private IEnumerator Explode ()
    {
        explosionModel.SetActive(true);
        audioManager.PlayAudio(explosionClip);
        yield return new WaitForSeconds (explosionDuration);
        
        Destroy(gameObject);
    }
}
