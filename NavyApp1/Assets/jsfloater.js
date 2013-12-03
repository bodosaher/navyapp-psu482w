#pragma strict
public var speed : float = 1f;
var water : Transform;

function Update () 
{
	//transform.position.x = -45 + 5*Mathf.Sin(speed*Time.time);
	//transform.position.y = -45 + 5*Mathf.Sin(speed*Time.time);
	//transform.position.z = -45 + 5*Mathf.Sin(speed*Time.time);
	if(transform.position.y < (water.position.y - 57))
	{
		rigidbody.AddRelativeForce(Vector3.forward * speed * 10);
	}
	
	if(transform.position.y > (water.position.y - 57))
	{
		rigidbody.AddRelativeForce(Vector3.back * speed * 10);
	}
}
