using PowerUps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace PowerUps
{
    public class PowerUpFactory 
    {
       private readonly PowerUpConfiguration _powerUpConfiguration;

        public PowerUpFactory(PowerUpConfiguration powerUpConfiguration) {
            _powerUpConfiguration = powerUpConfiguration;
        }

        public PowerUp Create(string id) 
        {
            var powerUp = _powerUpConfiguration.GetPowerUpPrefabById(id);
            return Object.Instantiate(powerUp);      

        }
    }
}