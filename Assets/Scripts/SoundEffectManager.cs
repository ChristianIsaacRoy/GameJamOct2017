using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour {

    public static SoundEffectManager instance;

    public AudioSource takeDamageSFX;
    public AudioSource swingSFX;
    public AudioSource dieSFX;
    public AudioSource getCandySFX;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayTakeDamage()
    {
        if (takeDamageSFX.isPlaying)
        {
            takeDamageSFX.Stop();
        }
        takeDamageSFX.Play();
    }

    public void PlaySwing()
    {
        if (swingSFX.isPlaying)
        {
            swingSFX.Stop();
        }
        swingSFX.Play();
    }

    public void PlayDie()
    {
        if (dieSFX.isPlaying)
        {
            dieSFX.Stop();
        }
        dieSFX.Play();
    }

    public void PlayGetCandy()
    {
        if (getCandySFX.isPlaying)
        {
            getCandySFX.Stop();
        }
        getCandySFX.Play();
    }

}
