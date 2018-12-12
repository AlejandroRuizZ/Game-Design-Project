using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	public Transform player;

	/**
	 * This camera will only follow the player on the X axis.
	 * Can you figure out how to make it follow the player on the Y axis, too?
	 */
	private void Update()
	{
		Vector3 myPosition = transform.position;
		Vector3 playerPosition = player.position;
		transform.position = new Vector3(playerPosition.x, myPosition.y, myPosition.z);
	}
}
