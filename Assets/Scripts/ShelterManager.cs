using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Arcade3DShooter
{
    public class ShelterManager : MonoSingleton<ShelterManager>
    {
        [SerializeField] List<Shelter> shelterList;

        public List<Shelter> Shelters { get { return shelterList; } }
        

        public void RestartAllShelters()
        {
            foreach (Shelter shelter in Shelters) {
                shelter.RestartAllEnemies();
            }
        }
    }
}