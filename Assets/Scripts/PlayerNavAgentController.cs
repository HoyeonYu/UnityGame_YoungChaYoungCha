using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavAgentController : MonoBehaviour
{
    public Camera cam;

    Vector3 targetPosition;
    NavMeshAgent agent;
    float rotSpeed;
    float currentRotX, currentRotY;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentRotX = 0f;
        currentRotY = 0f;
        rotSpeed = 2.0f;
    }

    void Update()
    {
        if (!GameDirector.isPlayerFixed)
        {
            targetPosition = PlayerTargetPositionController.targetPos;
            agent.SetDestination(targetPosition);
            RotationControl();
        }
    }

    void RotationControl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        currentRotX -= rotX;
        currentRotX = Mathf.Clamp(currentRotX, -20f, 20f);

        currentRotY -= rotY;
        currentRotY = Mathf.Clamp(currentRotY, -80f, 80f);

        cam.transform.localEulerAngles = new Vector3(currentRotX, -currentRotY, 0f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bank")
        {
            GameObject director = GameObject.Find("GameDirector");

            if (!(director.GetComponent<GameDirector>().RealEstateCanvas.active ||
                director.GetComponent<GameDirector>().CoinCanvas.active ||
                director.GetComponent<GameDirector>().CoinDealCanvas.active))
            {
                director.GetComponent<GameDirector>().BankCanvas.SetActive(true);
                GameDirector.isPlayerFixed = true;
            }
        }
    }
}