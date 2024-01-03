using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Moving Things")]
    [SerializeField] float moveSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [Header("Controls")]
    [SerializeField] KeyCode altKey;
    [SerializeField] float deltaHeight;
    [SerializeField] float deltaSpeed;
    [Header("UI")]
    [SerializeField] Image speedFiller;
    [SerializeField] Image heightFiller;
    [SerializeField] TMP_Text speedText;
    [SerializeField] TMP_Text heightText;


    public bool allowedToMove = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (allowedToMove)
        {
            Move();
            ChangeSpeed();
            if (!Input.GetKey(altKey))
            {
                ChangeHeight();
            }
        }
    }

    void LateUpdate()
    {
        CheckPosition();
        CheckSpeed();
        UpdateUI();
    }

    private void UpdateUI()
    {
        float percentHeight = (transform.position.y - minHeight) / (maxHeight - minHeight);
        float percentSpeed = (moveSpeed - minSpeed) / (maxSpeed - minSpeed);

        heightFiller.fillAmount = percentHeight;
        speedFiller.fillAmount = percentSpeed;

        heightText.text = "Zoom: " + transform.position.y.ToString();
        speedText.text = "Speed: " + moveSpeed;
    }

    private void ChangeSpeed()
    {
        if (Input.GetKey(altKey))
        {
            if (Input.mouseScrollDelta.y >= 0)
            {
                moveSpeed += deltaSpeed;
            }
            if (Input.mouseScrollDelta.y <= 0)
            {
                moveSpeed -= deltaSpeed;
            }
        }
    }

    private void ChangeHeight()
    {
        if (Input.mouseScrollDelta.y >= 0)
        {
            Vector3 v3 = transform.position;
            v3.y -= deltaHeight;
            transform.position = v3;
        }
        if (Input.mouseScrollDelta.y <= 0)
        {
            Vector3 v3 = transform.position;
            v3.y += deltaHeight;
            transform.position = v3;
        }
    }

    private void Move()
    {
        Vector3 v3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        v3 = v3 * Time.deltaTime * moveSpeed;

        transform.position += v3;
    }

    private void CheckPosition()
    {
        // Checks X
        if (transform.position.x >= maxDistance)
        {
            Vector3 v3 = transform.position;
            v3.x = maxDistance;
            transform.position = v3;
        }
        if (transform.position.x <= -maxDistance)
        {
            Vector3 v3 = transform.position;
            v3.x = -maxDistance;
            transform.position = v3;
        }
        // Checks Z
        if (transform.position.z >= maxDistance)
        {
            Vector3 v3 = transform.position;
            v3.z = maxDistance;
            transform.position = v3;
        }
        if (transform.position.z <= -maxDistance)
        {
            Vector3 v3 = transform.position;
            v3.z = -maxDistance;
            transform.position = v3;
        }
        // Checks Y
        if (transform.position.y >= maxHeight)
        {
            Vector3 v3 = transform.position;
            v3.y = maxHeight;
            transform.position = v3;
        }
        if (transform.position.y <= minHeight)
        {
            Vector3 v3 = transform.position;
            v3.y = minHeight;
            transform.position = v3;
        }
    }

    private void CheckSpeed()
    {
        if (moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }
        if (moveSpeed < minSpeed)
        {
            moveSpeed = minSpeed;
        }
    }
}
