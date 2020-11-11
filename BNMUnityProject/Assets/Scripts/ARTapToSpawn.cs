using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToSpawn : MonoBehaviour
{
	[SerializeField] private GameObject prefabToSpawn;
	[Tooltip("Pixel delta forr which spawned object scale will be incremented by 1.")]
	[SerializeField] private float pixelDelta;

	private GameObject spawnObject;
	private ARRaycastManager arRaycastManager;
	private Vector2 touchPosition;

	bool isPinchingLastFrame = false;
	float pinchDistAtStart = 0.0f;
	Vector3 scaleAtStart = Vector3.zero;

	List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
		arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
	{
		SpawnMoveUpdate();
		PinchScalingUpdate();
    }

	private bool TryGetTouchPosition(out Vector2 _touchPosition)
	{
		if (Input.touchCount == 1)
		{
			_touchPosition = Input.GetTouch(0).position;
			return true;
		}

		_touchPosition = default;
		return false;
	}

	private void SpawnMoveUpdate()
	{
		if (TryGetTouchPosition(out Vector2 touchPosition))
		{
			if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
			{
				Pose hitPose = hits[0].pose;

				if (spawnObject == null)
				{
					spawnObject = Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
				}
				else
				{
					spawnObject.transform.position = hitPose.position;
				}
			}
		}
	}

	private void PinchScalingUpdate()
	{
		if (spawnObject != null)
		{
			if (Input.touchCount == 2)
			{
				float pinchDist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

				if (isPinchingLastFrame)
				{
					float pinchDelta = pinchDist - pinchDistAtStart; // in pixel unit

					Vector3 newScale = scaleAtStart + Vector3.one * (pinchDelta / pixelDelta);

					// clamp
					if (newScale.x < 0.1f)
					{
						newScale = Vector3.one * 0.1f;
					}
					else if (newScale.x > 1.5f)
					{
						newScale = Vector3.one * 1.5f;
					}

					spawnObject.transform.localScale = newScale;
				}
				else
				{
					pinchDistAtStart = pinchDist;
					scaleAtStart = spawnObject.transform.localScale;
				}
			}

			isPinchingLastFrame = Input.touchCount == 2;
		}
	}
}
