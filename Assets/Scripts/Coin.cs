using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent myEvent;
    [SerializeField] private ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CreateParticle();
            myEvent.Invoke();
        }
    }

    public void CreateParticle()
    {
        particle.transform.position = transform.position;
        particle.Play();
    }
}
