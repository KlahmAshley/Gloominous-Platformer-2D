Zachary Lemieux (100971755)
gloominous 2D
player jumps through simple platforming levels with the intent to collect the scattered orbs around the map while avoiding various enemies hindering their progress.
test scene enemy firing once every hundredth of a second
Before:
<img width="1898" height="991" alt="image" src="https://github.com/user-attachments/assets/d6d7ec69-8e23-4371-867c-19e8fdb4148c" />
After:
<img width="1901" height="993" alt="image" src="https://github.com/user-attachments/assets/890be095-2093-4358-8539-eb8e306604ba" />
the thing impacting frame performance would probably have been the machine gun of death I created in the scene, but jokes aside I believe that in this case it is the repeated bullet calculations happening every shot.
the pattern I implemented was the factory, I made a scriptable object that separates the bullet creation from the player and instead inserts it into the object pool, this had a minimal but somewhat observable impact on performance, 
spikes were minutely lower and my memory usage dropped a consistent 1% when I enabled the new structure, though this could have been coincidence.
