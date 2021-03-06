using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    // Variables
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip crashAudio; // Reference for crash sound
    [SerializeField] AudioClip successAudio; // Reference for success sound, after serializing field just drag the audio.

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    // References
    AudioSource rocket ;

    // States
    bool isTransitioning = false; // True when bumped into sth.

    private void Start() {
        rocket = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) {

        if(!isTransitioning){
            switch(other.gameObject.tag){
                case "Finish":
                    Debug.Log("Finish");
                    isTransitioning = true;
                    StartSuccessSequence();
                    break;

                case "Friendly":
                    Debug.Log("Friendly");
                    break;

                case "Fuel":
                    Debug.Log("You fueled up !");
                    break;

                default:
                    Debug.Log("You crushed !");
                    // When crushed stop the rocket then Reload the level with 1 sec of delay
                    isTransitioning = true;
                    StartCrushSequence();
                    break;
            }
        }


    }

    private void StartSuccessSequence()
    {
        rocket.Stop();
        GetComponent<Movement>().enabled = false;
        successParticle.Play();
        rocket.PlayOneShot(successAudio);
        Invoke("LevelUp",delay);
    }

    void StartCrushSequence(){
        rocket.Stop();
        GetComponent<Movement>().enabled = false;
        crashParticle.Play();
        rocket.PlayOneShot(crashAudio);
        Invoke("ReloadLevel",delay);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        isTransitioning = false;
    }

    void LevelUp(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        isTransitioning = false;
    }
}
