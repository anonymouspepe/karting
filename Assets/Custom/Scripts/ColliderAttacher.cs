using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class ColliderAttacher : MonoBehaviour
{
    public Transform Trees;
    public Transform Hills;
    public Transform Clouds;
    public Transform Stones;
    public Transform Tracks;

    // Start is called before the first frame update
    void Start()
    {
        AttachToEnvironment(Trees);
        Debug.Log("ColliderTest: Trees Done");
        AttachToEnvironment(Hills);
        Debug.Log("ColliderTest: Hills Done");
        AttachToEnvironment(Clouds);
        Debug.Log("ColliderTest: Clouds Done");
        AttachToEnvironment(Stones);
        Debug.Log("ColliderTest: Stones Done");
        AttachToTracks();
    }

    void AttachToEnvironment(Transform container)
    {
        for (int i = 0; i < container.childCount; i++)
        {
            // Get the child Transform
            Transform childTransform = container.GetChild(i);

            // Get the child GameObject
            GameObject childnode = childTransform.gameObject;

            if (childnode.name.Contains("TreeRound"))
            {
                childnode = childTransform.GetChild(0).gameObject;
            }

            Rigidbody rb = childnode.AddComponent<Rigidbody>();
            rb.useGravity = false;

            MeshCollider collider = childnode.AddComponent<MeshCollider>();
            collider.convex = true;
            collider.isTrigger = true;

            NRGrabbableObject grabbable = childnode.AddComponent<NRGrabbableObject>();
            grabbable.AttachedColliders[0] = collider;
        }
    }

    void AttachToTracks()
    {
        for (int i = 0; i < Tracks.childCount; i++)
        {
            GameObject track = Tracks.GetChild(i).gameObject;
            Debug.Log("ColliderTest: " + track.name);
            if (track.name.Contains("ModularTrack"))
            {
                Rigidbody rb = track.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;

                MeshRenderer meshRenderer = track.GetComponent<MeshRenderer>();

                BoxCollider collider = track.AddComponent<BoxCollider>();
                collider.isTrigger = true;
                collider.size = new Vector3(meshRenderer.bounds.size.x, meshRenderer.bounds.size.y + 1, meshRenderer.bounds.size.z);

                NRGrabbableObject grabbable = track.AddComponent<NRGrabbableObject>();
                grabbable.AttachedColliders[0] = collider;
            }
        }
    }
}