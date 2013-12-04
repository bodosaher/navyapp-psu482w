    #pragma strict
     
    var target : Transform;
    //public var speed : float = 10f;
    
    function Update ()
    {
    	print(target.position.x + "\n");
    	print(target.position.y + "\n");
    	print(target.position.z + "\n");
    	transform.position.y =  target.position.y;
    	//transform.position.y = 81 + 5*Mathf.Sin(speed*Time.time);
    	transform.position.x = target.position.x;
    	transform.position.z = target.position.z;
    }