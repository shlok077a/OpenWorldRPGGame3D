using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Ray ray;
    private RaycastHit hit;

    private Animator anim;

    private float x;
    private float z;
    private float VelocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currPos;

    public LayerMask moveLayer;

    public static bool canMove = true;
    public static bool moving = false;
    public GameObject freeCam;
    public GameObject staticCam;
    private bool freeCamActive = true;
    
    public GameObject spawnPoint;
    private WaitForSeconds approchEnemy = new WaitForSeconds(0.2f);

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
        freeCam.SetActive(true);
        staticCam.SetActive(false);
        SaveScript.spawnPoint = spawnPoint;

    }

    void Update()
    {
        // Calculate Velocity Speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        VelocitySpeed = x + z;

        // Get Mouse Position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;
        
        // Player Movement
        if (Input.GetMouseButtonDown(0))
        {
            if (canMove == true)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {
                    if (hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        nav.isStopped = false;
                        SaveScript.theTarget = hit.transform.gameObject;
                        nav.destination = hit.point;
                        StartCoroutine(MoveTo());
                    }else
                    {
                        SaveScript.theTarget = null;
                        nav.destination = hit.point;
                        nav.isStopped = false;
                    }
                }
            }
        }
        
        // Control Player Animations
        if (VelocitySpeed != 0)
        {
            anim.SetBool("Running", true);
            moving = true;
        }
        if (VelocitySpeed == 0)
        {
            anim.SetBool("Running", false);
            moving = false;
        }

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(freeCamActive == true)
            {
                freeCam.SetActive(false);
                staticCam.SetActive(true);
                freeCamActive = false;
            }
            else if (freeCamActive == false)
            {
                freeCam.SetActive(true);
                staticCam.SetActive(false);
                freeCamActive = true;
            }
        }
    }

    IEnumerator MoveTo()
    {
        yield return approchEnemy;
        nav.isStopped = true;
    }
}
