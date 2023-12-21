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

#2. Missions 
    I've created a new folder called "MissionsPackage", which uses it's own Assembly Definition and all the scripts there have they same namespace. This is to simplify the process of using this system in future games.
    All the logic there is extendable, through protected and virtual methods mostly, and some interfaces.
    The specific missions logic for this game, is located in "3_Scripts/Missions".
    The entry point of the system is the MissionManager. 
    There is a TowerMissionsManager that is in charge to connect it to the other parts of the games, using the Singleton pattern. It also checks if the system should be enabled or disabled through the RemoteConfig bool.
    The Mission contains some logic that can be overriden depending on the game. It also contains the MissionData with all the configuration.
    To make things easier to develop there is also a MissionDataSO, which is a ScriptableObject to fill all the missions information, and then this is converted to a MissionData, to be able to serialize it properly.
    In the real world, this MissionDataSO wouldn't exist, and all this data should be obtained from a server.
    The MissionData contains some fields like the Type or the Reward.Type which started being Enums, but I switched them to strings so the system can be easily extended. Those strings are then defined in the ScriptableObject and a static class with strings, in each project.
    The Missions are created using factories, to enable each project to create child classes however they want. This is done through interfaces and the MissionsCreator class.
    The MissionLibrary is another ScriptableObject to simplify obtaining a list of missions.
    I had to install the Newtonsoft Json package, to be able to store the missions progress between sessions in runtime. This is because the complexity of the inheritance used in Mission class. This is done in MissionsStorage class.
    
    
    
