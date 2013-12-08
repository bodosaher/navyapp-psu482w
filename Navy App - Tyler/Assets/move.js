    #pragma strict
     
    var target : Transform;
    //public var speed : float = 10f;
    
    function Update ()
    {
    	transform.position.y = target.position.y + 1.6;
    	//transform.position.y = 81 + 5*Mathf.Sin(speed*Time.time);
    	transform.position.x = target.position.x - 1;
    	transform.position.z = target.position.z + 1.3;
    	
    	transform.rotation.x = -target.rotation.x;
    	transform.rotation.y = target.rotation.y;
    	transform.rotation.z = target.rotation.z;
    }