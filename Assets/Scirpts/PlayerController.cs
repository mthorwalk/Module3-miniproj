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
    public TextMeshProUGUI leaderboardTextObject;
    public Button resetButton;
    public static float[] winTimes = new float[5];

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
                    for (int j = 4; j > i; j--) {
                        winTimes[j] = winTimes[j-1];
                    }
                    winTimes[i] = time;
                    break;
                }
            }
            displayLeaderboard();
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
            displayLeaderboard();
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
    private void displayLeaderboard() 
    {
        string firstScore = winTimes[0].ToString("0.00");
        string secondScore = winTimes[1].ToString("0.00");
        string thirdScore = winTimes[2].ToString("0.00");
        string fourthScore = winTimes[3].ToString("0.00");
        string fifthScore = winTimes[4].ToString("0.00");

        leaderboardTextObject.text = "1. " + firstScore + "\n" + "2. " + secondScore + "\n" + "3. " + thirdScore + "\n" + 
                                     "4. " + fourthScore + "\n" + "5. " + fifthScore + "\n";
    }
}
