# PoolManager
Unity C# PoolManager system


## How it works

### Setup
* You need to have a EmptyGameObject with the PoolManager on it
* You need to Config the PoolManager in each scene you want to use it with the PoolDataSender on a EmptyGameObject
* Your Prefabs need to have a script who inherite from PooledObject Script.
* #### The PoolManager Init itself during the Awake() call, so never call the PoolManager.Instance in a Awake Call unless it has been loaded in the previous Scene.

### PoolDataSender
Used to initialize the PoolManager. You use it on every scene that you need the PoolManager.
Place it on an EmptyGameObject add attach the script to it. Then set it up!


### PooledObject
This is the BaseScript to define if a GameObject can be used inside a PoolManager
Why? So it can have a stronger structure on what's going on with the Objects in the Pool and easier to control them.

So first, create your own PooledObject Script

```csharp
  public class YourCustomPooledObject : PooledObject
  {
   //Then do your object logic, if you want it to disappear on a CollisionHit, or after X Time, etc.
  }
```
#### REALLY IMPORTANT THAT YOU DONT DESTROY A POOLEDOBJECT, WHEN YOU ARE DONE WITH IT YOU JUST USE
```csharp
gameObject.SetActive(false);
```

### PoolManager
To get a PooledObject, you just need to use:
```csharp
//It returns a GameObject if you want to work with it for some reason
PoolManager.Instance.UseObjectFromPool(ThePrefab, TheSpawnLocation, TheSpawnRotation);
```

Or if you want to use and Get the Script of the PooledObject
```csharp
//It returns TheScript of the PooledObject
PoolManager.Instance.UseObjectFromPool<TheScriptName>(ThePrefab, TheSpawnLocation, TheSpawnRotation);
```


## Lisence
MIT - do whatever you want.
