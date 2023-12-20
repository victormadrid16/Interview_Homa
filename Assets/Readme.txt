#1. Optimization 
● Unity UI assets optimization.
    To reduce the drawcalls, I've added a sprite atlas for the UI elements.
    I've also removed the raycast target in the elements that don't need it. To avoid merge conflicts with the scene in the future, I've created a prefab with all UI elements, using nested prefabs.
    This could be further optimize adding a texture atlas also for the 3D elements. This could be done to elements that share the same shader, to use the same material, like the particles.
● Add a pooling system for the barrels 
    I've added a generic PoolManager class, that internally uses Unity's pooling system. This way, to create new Pools you only need to create a child class that inherits from PoolManager specifying the type. 
    In order to make the tiles pooleable, I've moved some logic from TowerTile and Explodingtile, so it uses Get/Release instead of Awake/Destroy.
    Then, the TowerTileFactory class is in charge to decide if use or not the pooling system, based on a RemoteConfig setting, following Single Responsibility principle.
    This class is a Singleton to be able to access it from Tower and also from TowerTile, following current's project architecture. If I would be able to choose, I would have use Dependency Injection instead of Singletons.
    After that I've tweaked the Tower script to use this new Factory and added some fixes to event subscription and checking for disabled gameobjects in some parts of the code.
    During this part, I realised there is an exception if you try to build the tower in the editor, but since this bug is included in the original project, I don't think the idea is to fix it.
    
    
