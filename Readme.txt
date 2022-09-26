This is a project made for "moving rovers around the surface of Mars" or "Mars Rovers Kata"
Some of the ideas that formed the basis for the implementation of this project: 

	1. Plateau and maps

	MapManager was conceived to implement the ability to work with several plateaus at the same time (that is why the idPlateau field was added to the Position class) 
	Each plateau is a rectangle, but by combining such rectangles we can get an arbitrary shaped plateau. As an example, imagine we have a plateau (0,0):(5,5) and we create a new one with borders (2,5):(12,15). Having determined the junction points of these areas, we are able to load new maps and move the rovers beyond the borders of the plateau if it has reached them (move the rover from position (5,5) to position (5,6)).
	In order not to sort through the lists of obstacles and rovers and each time(O(n)), checking the possibility of moving to a certain position is implemented using matrices (O(1)). (At the moment, each element of the matrix is either true if the position is free - or false if it is occupied. (So to understand if position (x, y) is available we just get matrix[x,y] value) However, in the future, elemental matrices can indicate not only the presence of an obstacle, but also the type of obstacle (pit, hill, another rover, etc). 
However, it is just an idea now. 

	2. Movement of rovers. 
	At each step, the rover checks the map and transmits information about its location. Thus, in the future, potentially robots are not required to move exclusively sequentially. Since at every moment the map of obstacles is relevant. 
	If during the movement the robot cannot execute some instruction (from the chain of instructions) due to an obstacle, then it stops. And reports that the command could not be successfully completed. Thus, the final point becomes the position occupied by the rover since the last successful execution of the instruction.

