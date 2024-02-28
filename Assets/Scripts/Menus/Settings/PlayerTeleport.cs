using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
	private GameObject currentTeleporter;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && currentTeleporter != null)
		{
			base.transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Teleporter"))
		{
			currentTeleporter = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Teleporter") && collision.gameObject == currentTeleporter)
		{
			currentTeleporter = null;
		}
	}
}
