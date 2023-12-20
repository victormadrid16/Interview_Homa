#1. Optimization 
● Unity UI assets optimization.
    To reduce the drawcalls, I've added a sprite atlas for the UI elements.
    I've also removed the raycast target in the elements that don't need it. To avoid merge conflicts with the scene in the future, I've created a prefab with all UI elements, using nested prefabs.
    This could be further optimize adding a texture atlas also for the 3D elements. This could be done to elemets that share the same shader, to use the same material, like the particles.
● Add a pooling system for the barrels 
