using System.Collections;
using UnityEngine;

public class ParcticleController : MonoBehaviour
{
    private ParticleSystem particleSystem;
    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(gameObject);
    }
}
