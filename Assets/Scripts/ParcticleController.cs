using System.Collections;
using UnityEngine;

public class ParcticleController : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        yield return new WaitForSeconds(particle.main.duration);
        Destroy(gameObject);
    }
}
