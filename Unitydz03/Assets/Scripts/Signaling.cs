using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(SignalingOn());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(SignalingOff());
        }
    }

    private IEnumerator SignalingOn()
    {
        _audioSource.Play();

        for (int i = 0; i < 10; i++)
        {
            _audioSource.volume += 0.1f;

            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator SignalingOff()
    {
        for (int i = 0; i < 10; i++)
        {
            _audioSource.volume -= 0.1f;

            yield return new WaitForSeconds(0.2f);
        }

        _audioSource.Stop();
    }
}
