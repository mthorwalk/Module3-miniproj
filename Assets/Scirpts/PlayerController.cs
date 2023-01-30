using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timer;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public Button resetButton;
    public float[] winTimes = new float[5];

    private Rigidbody rb;
    private int count;
    private float time = 15.0f;
    private float movementX;
    private float movementY;
    private bool timeStop = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        setCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 13 && time != 0)
        {
            timeStop = true;
            winTextObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            for (int i = 0; i < 5; i++) {
                if (time > winTimes[i]) {
                    winTimes[i] = time;
                    break;
                }
            }
        }
    }

    void Update()
    {
        TimerSet();

        if (time <= 0)
        {
            time = 0;
            timeStop = true;
            resetButton.gameObject.SetActive(true);
            loseTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            setCountText();
        }
    }

    void TimerSet()
    {
        if (!timeStop)
        {
            time = time - Time.deltaTime;

            timer.text = time.ToString("0.00");
        }
        
    }
}
