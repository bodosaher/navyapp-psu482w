#pragma strict

//public var moveSpeed : float = 10f;
//public var turnSpeed : float = 50f;

public var speed : float = 1f;
//public var amplitude : float = 0.5f;

//function Start () 
//{
	//var rb = GetComponent.<Rigidbody>();
	//rb.AddForce(Vector3.up * 10f);	
//}


function Update () 
{
	//gameObject.rigidbody.transform.up();
	//var y0:float = transform.position.y;
	//transform.position.x = -45 + 5*Mathf.Sin(speed*Time.time);
	transform.position.y = -45 + 5*Mathf.Sin(speed*Time.time);
	//transform.position.z = -45 + 5*Mathf.Sin(speed*Time.time);
	//transform.position.z += 1;
	//transform.position.y += 40 * Time.deltaTime;
}

/*
var floatup;

function Start(){
  floatup = false;
}

function Update(){
    if(floatup)
       floatingup();
    else if(!floatup)
       floatingdown();
    }
    
function floatingup(){
    transform.position.y += 1 * Time.deltaTime;
    yield WaitForSeconds(1);
    floatup = false;
}

function floatingdown(){
    transform.position.y -= 1 * Time.deltaTime;;
    yield WaitForSeconds(1);
    floatup = true;
}
*/