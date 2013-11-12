    #pragma strict
     
    var target : Transform;
    //public var speed : float = 10f;
    
    function Update ()
    {
    	transform.position.y = 120 + target.position.y;
    	//transform.position.y = 81 + 5*Mathf.Sin(speed*Time.time);
    	transform.position.x = target.position.x - 85;
    	transform.position.z = target.position.z - 36;
    }