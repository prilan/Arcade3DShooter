using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Assets.Scripts
{
    public class ShelterManager : MonoSingleton<ShelterManager>
    {
        [SerializeField] List<Shelter> shelterList;

        public List<Shelter> Shelters { get { return shelterList; } }
        
    }
}