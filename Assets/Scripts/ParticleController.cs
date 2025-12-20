using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Play(System.Action cb = null)
    {
        StartCoroutine(PlayParticleLocalZMove(0f, 100f, 0.5f, cb));
        _particleSystem.Play();
    }

    public void Play(Vector3 distanceFromCamera, System.Action cb = null)
    {
        _particleSystem.transform.localPosition = distanceFromCamera;
        Play(cb);
    }

    public void Play(Vector2 worldPosition, System.Action cb = null)
    {
        _particleSystem.transform.position = new Vector3(worldPosition.x, worldPosition.y, _camera.transform.position.z);
        Play(cb);
    }

    // Update is called once per frame
    void Update()
    {
        _particleSystem.transform.Rotate(Vector3.forward, Time.deltaTime * 2f);
    }

    private IEnumerator PlayParticleLocalZMove(float start, float end, float duration, System.Action cb = null)
    {
        float frame = 0f;
        while (frame < duration)
        {
           frame += Time.deltaTime;
            float per = frame / duration;

            _particleSystem.transform.position = new Vector3(
                _particleSystem.transform.position.x,
                _particleSystem.transform.position.y,
                Mathf.Lerp(start, end, per)
            );

            yield return null;

        }
        cb?.Invoke();
    }
}
