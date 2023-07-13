using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using StarterAssets;

public class MPRespawner : NetworkBehaviour
{
    [Server]
    private void OnTriggerExit(Collider other)
    {
        NetworkManager.singleton.StopHost();
    }
}
