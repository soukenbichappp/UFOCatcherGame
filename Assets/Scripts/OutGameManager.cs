using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameManager : MonoBehaviour
{
    private static OutGameManager _instance;
    public static OutGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<OutGameManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private ParticleController _shuuchuusen;
    [SerializeField] private GameObject _cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shuuchuusen.Play();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _shuuchuusen.Play(Vector2.up * 10, cb: () =>
            {
                _shuuchuusen.Play(Vector2.left * 10, cb: () =>
                {
                    _shuuchuusen.Play(Vector2.down * 10, cb: () =>
                    {
                        _shuuchuusen.Play(Vector2.right * 10, cb: () =>
                        {                           
                            _shuuchuusen.Play(_cubePrefab.transform.position, cb: () => { });
                        });
                    });
                });
            });
        }
    }
}
