using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps {
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField] private PowerUpConfiguration _powerUpConfiguration;
        private PowerUpFactory _powerUpFactory;

        public void Awake()
        {
            _powerUpFactory = new PowerUpFactory(Instantiate(_powerUpConfiguration));
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.F)) 
            {
                _powerUpFactory.Create("Speed");
            } 
            else if (Input.GetKey(KeyCode.G))
            {
                _powerUpFactory.Create("Drunk");
            }
        }
    }


}