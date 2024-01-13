using System;
using System.Transactions;
using Patterns.State.Interfaces;
using Patterns.State.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using IState = Patterns.State.Interfaces.IState;

namespace Patterns.State.Components
{
    public class SnowManController : MonoBehaviour, ISnowMan
    {
        public int viewingAngle;
        public float WanderSpeed;
        public float ChaseSpeed;
        public float RotateSpeed;

        private IState currentState;

        public Transform currentWaypoint;
        public Transform[] waypoints;

        private Animator animator;
        public Transform eyesTransform;

        private GameObject playerAtSight;

        [SerializeField] private int posX;
        [SerializeField] private int posZ;

        [SerializeField] private int auxPosX;
        [SerializeField] private int auxPosZ;

        [SerializeField] private int contador = 0;

        [SerializeField] private int segundoActual;
        [SerializeField] private int segundoAux;

        private Vector3 posicionInicial;

        private void Awake()
        {
            Assert.IsTrue(waypoints.Length > 0, "Waypoints must be greater than 1");
            if (currentWaypoint == null)
            {
                currentWaypoint = waypoints[0];
            }

            animator = gameObject.GetComponent<Animator>();
            
            SetState(new SearchingForWaypoint(this));


        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        #region Get & Set speeds
        public float GetRotateSpeed()
        {
            return RotateSpeed;
        }
        
        public float GetWanderSpeed()
        {
            return WanderSpeed;
        }

        public float GetChaseSpeed()
        {
            return ChaseSpeed;
        }

        public void SetCurrentSpeed(float speed)
        {
            animator.SetFloat("MoveSpeed", speed);
        }
        #endregion

        #region Get & set Waypoints
        public Transform[] GetWayPoints()
        {
            return waypoints;
        }
        
        public Transform GetCurrentWayPoint()
        {
            return currentWaypoint;
        }

        public void SetCurrentWayPoint(Transform waypoint)
        {
            this.currentWaypoint = waypoint;
        }
        #endregion

        #region Set y Get State, state pattern
        public IState GetState()
        {
            return currentState;
        }

        public void SetState(IState state)
        {
            // Exit old state
            if (currentState != null)
            {
                currentState.Exit();    
            }
            
            // Set current state and enter
            currentState = state;
            currentState.Enter();
        }

        private void Start()
        {
            posX = (int)transform.position.x;
            posZ = (int)transform.position.z;
            posicionInicial = transform.position;
        }

        private void Update()
        {
            currentState.Update();
            transform.position= new Vector3(transform.position.x,-1.07f, transform.position.z);

            segundoActual = System.DateTime.Now.Second;
            posX = (int)transform.position.x;
            posZ = (int)transform.position.z;


            if (segundoAux != segundoActual)
            {
                if (auxPosX == posX && auxPosZ == posZ)
                {
                    contador++;
                    if (contador >= 5)
                    {
                        transform.position = posicionInicial;
                    }
                }
                else
                {
                    contador = 0;
                }

                auxPosX = posX;
                auxPosZ = posZ;
                segundoAux = segundoActual;
            }
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdate();
        }
        #endregion
        
        #region Player at sight calculations
        public GameObject PlayerAtSight()
        {
            return playerAtSight;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerAtSight = PlayerIsOnSight(other.gameObject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerAtSight = PlayerIsOnSight(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerAtSight = null;
            }
        }

        private GameObject PlayerIsOnSight(GameObject player)
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, playerDirection);

            if (angle < viewingAngle / 2)
            {
                RaycastHit hit;

                Vector3 endPosition = player.transform.position;
                endPosition.y = eyesTransform.position.y;

                if (Physics.Linecast(eyesTransform.position, player.transform.position, out hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        return hit.collider.gameObject;
                    }
                }
            }

            return null;
        }

        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }
        }
        public void MoveTo(Transform target, float speed, float rotationSpeed)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            direction.y = 0;    // No direction in vertical axis
            Quaternion toTargetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toTargetRotation,
                rotationSpeed * Time.deltaTime);
            
            transform.Translate(0, 0, speed * Time.fixedDeltaTime, Space.Self);
        }


    }


}