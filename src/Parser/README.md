# Parsers


## Config File Parser
The objective of the config file parser is that it can be inherited from by any class and its functions can be used. The constructor takes in a file path and a new Config file can be generated from the config file at this path. A similar function is provided with the save method. It takes in a file path, and it will write all of the data about the object to the file path in the config format. 

### Example:
```c#

class Gamemode : CFGObject
{

    public string name = "New Gamemode";
    public int playerCount = 20;
    public bool bots = true;

    public Gamemode(string path) : base(path) { }

}

```
*This class, Gamemode, stores information about possible gamemodes allowed in the game. The constructor needs to be defined and needs to call the base class, but besides that, there is no other template code. From there, the developer can run the below code to generate new config files or read existing ones.*

```c#
// Read and Create Config File
Gamemode deathmatch = new Gamemode("./deathmatch.cfg");

// Save Config File
deathmath.Save("./deathmatch.cfg");

```
