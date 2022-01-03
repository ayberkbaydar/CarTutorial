using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject player;
    private Controller RR;
    private GameObject cameraConstraint;
    private GameObject cameraLookAt;
    public float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraConstraint = player.transform.Find("camera constraint").gameObject;
        cameraLookAt = player.transform.Find("camera lookAt").gameObject;
        RR = player.GetComponent<Controller>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Follow();

        speed = (RR.KPH >= 50) ? 20 : RR.KPH / 4;
    }
    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraConstraint.transform.position/* + new Vector3(0, 1.2f, 7)*/, Time.deltaTime * speed);
        gameObject.transform.LookAt(cameraLookAt.gameObject.transform.position);//bu iþlem sýkýntýlý tekrar bakýlacak.
    }
}
