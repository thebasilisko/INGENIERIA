using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps {
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private string _id;
    
        public string Id => _id;
    }


}