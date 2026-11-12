Action 11A – Classes in Unity
Project Description

This project demonstrates three C# classes in Unity that control object movement, rotation, and color.

Scripts
TranslateObject.cs: Moves an object along the world X axis using its Speed property and Update().
RotateObject.cs: Rotates an object around its local Y axis using DegreesPerSecond and Update().
ChangeObjectColor.cs: Changes an object's material color using its Tint property and Start().
Observations
Movement

Starting position: X = -3
Speed: 1 unit/second
Prediction: The cube would move approximately 3 units to the right in 3 seconds.
Actual result: The cube moved to approximately X = 0.

Rotation

Rotation speed: 90 degrees/second
Prediction: The cube would rotate approximately 90 degrees in one second.
Actual result: The cube rotated around its Y axis.

Color

Starting tint: Cyan
Prediction: The cube would display the selected tint when Play mode started.
Actual result: The cube changed to the selected color.

CombinedCube

I attached all three scripts to one GameObject. The cube moved, rotated, and displayed its selected startup color.

C# Concepts
Class: A definition that describes an object's data and behavior.
Instance: An individual component created from a class.
Field: A variable that stores data.
Property: Provides access to a field through get and set.
Method: A block of code that performs an action.
Inheritance: Each script inherits from MonoBehaviour.
Composition: Multiple components are attached to the same GameObject.
Unity Lifecycle

Start() runs once when the component starts. Update() runs repeatedly each frame. The movement and rotation scripts use Time.deltaTime to calculate changes based on elapsed time.
