using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiJointTracker : MonoBehaviour
{
	//	public Vector3 TopLeft;
	//	public Vector3 TopRight;
	//	public Vector3 BottomRight;
	//	public Vector3 BottomLeft;


	public KinectWrapper.NuiSkeletonPositionIndex rightHand = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	public GameObject rightHandTracker;

	public KinectWrapper.NuiSkeletonPositionIndex leftHand = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
	public GameObject lefttHandTracker;

	

	public float smoothFactor = 5f;


	private float distanceToCamera =0f;


	void Start()
	{
		if (rightHandTracker)
		{
			distanceToCamera = (rightHandTracker.transform.position - Camera.main.transform.position).magnitude;
		}
		if (lefttHandTracker)
		{
			distanceToCamera = (lefttHandTracker.transform.position - Camera.main.transform.position).magnitude;
		}
		
	}

	void Update()
	{
		KinectManager manager = KinectManager.Instance;

		if (manager && manager.IsInitialized())
		{


			//			Vector3 vRight = BottomRight - BottomLeft;
			//			Vector3 vUp = TopLeft - BottomLeft;

			int iRightIndex = (int)rightHand;
			int iLeftIndex = (int)leftHand;
			

			if (manager.IsUserDetected())
			{
				uint userId = manager.GetPlayer1ID();

				if (manager.IsJointTracked(userId, iRightIndex))
				{
					Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iRightIndex);

					if (posJoint != Vector3.zero)
					{
						// 3d position to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);

						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos(posDepth);

						float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
						float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;

						//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
						//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
						//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));



						if (rightHandTracker)
						{
							Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
							rightHandTracker.transform.position = Vector3.Lerp(rightHandTracker.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);

						}
					}
				}

				if (manager.IsJointTracked(userId, iLeftIndex))
				{
					Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iLeftIndex);

					if (posJoint != Vector3.zero)
					{
						// 3d position to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);

						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos(posDepth);

						float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
						float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;

						//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
						//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
						//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));



						if (lefttHandTracker)
						{
							Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
							lefttHandTracker.transform.position = Vector3.Lerp(lefttHandTracker.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);

						}
					}
				}

				

			}

		}
	}
}
