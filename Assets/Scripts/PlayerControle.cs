using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// Sara McHattie
// Galaxy Ball - player controls script

public class PlayerControle : MonoBehaviour
{
    // variables
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    // In game text
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Audio 
    public AudioSource backgroundMusic;
    public AudioClip pickupSoundClip;
    public AudioSource pickupSound;
    public AudioSource victoryMusic;
    public AudioClip victoryMusicClip;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        // Audio initialization
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        pickupSound = GetComponent<AudioSource>();
        victoryMusic = gameObject.AddComponent<AudioSource>();
        victoryMusic.clip = victoryMusicClip;

        if (pickupSound != null)
        {
            pickupSound.Stop(); 
        }

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 16)
        {
            winTextObject.SetActive(true);
            backgroundMusic.Stop(); // Stop background music
            victoryMusic.Play();   // Play victory music
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // as player comes in contact with Pickup objects, count increases and pickupSound is triggered
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            if (pickupSound != null && pickupSoundClip != null)
            {
                pickupSound.PlayOneShot(pickupSoundClip);
            }
        }

    }

}
