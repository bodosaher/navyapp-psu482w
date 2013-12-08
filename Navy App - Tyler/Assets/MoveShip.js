    #pragma strict
     
    var target : Transform;
    //public var speed : float = 10f;
    
    function Update ()
    {
    	transform.position.y = target.position.y;
    	transform.position.x = target.position.x;
    	transform.position.z = target.position.z;
    	transform.rotation.x = target.rotation.x;
    	transform.rotation.y = target.rotation.y+ 180;
    	transform.rotation.z = target.rotation.z;
    	
    	//transform.position.x = transform.parent.position.x;
    	//transform.position.y = transform.parent.position.y;
    	//transform.position.z = transform.parent.position.z;
    	
    	//transform.rotation.x = transform.parent.rotation.x;
    	//transform.rotation.y = transform.parent.rotation.y;
    	//transform.rotation.z = transform.parent.rotation.z;
    }