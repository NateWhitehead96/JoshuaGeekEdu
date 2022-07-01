using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] public int length; // how long the line is
    [SerializeField] public LineRenderer lineRend; // access to the line renderer
    [SerializeField] public Vector3[] segmentPoses; // the positions of each segement
    private Vector3[] segmentV;

    [SerializeField] public Transform targetDir; // a holder for what direction the line renderer should be
    [SerializeField] public float targetDist; // how far each segment is
    [SerializeField] public float smoothSpeed; // how fast the line moves
    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position; // the first segment position will be the target position
        for (int i = 1; i < segmentPoses.Length; i++) // loop through all segment positions
        {
            // each segment follows the last at whatever our smooth damping is
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses); // setting all the positions
    }
}
