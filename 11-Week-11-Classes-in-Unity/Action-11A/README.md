# Action 11A requirements / 10 points
1. Explanations (You will have to explain task w/ screenshot)
2. AI template prompt with complete explanations as needed (If you get stuck)
3. If you need a visual guide of what is needed click folder /Guide
4. Clean up README.md once we are done
5. WB notes

1) Translation class and observed movement:

2 points. Rotation class and observed turning: 
2 points. Color class and observed startup tint: 
2 points. Explanation of class/instance, field/property, and Unity lifecycle using your scene: 
3 points. Accessible GitHub repository URL submitted in Canvas the same day: 1 point.

Explain using your own scene
Identify one class definition and two instances of it. Which data belongs to each instance?
[Needs to be explained]

Point to a field, property, getter, setter, and method in your scripts. Explain what each does.
[Needs to be explained]

Trace a frame from Update → Speed getter → Translate → changed Transform → rendered image.
[Needs to be explained]

Explain why the first color class does not react immediately to Tint edits during Play.
[Needs to be explained]

Explain why three components on a GameObject are composition, and where inheritance appears in the code.
[Needs to be explained]

Keep the three .cs files, your saved Unity scene, and brief before/after observations with your existing project work. A useful observation includes the starting value, your prediction, the actual result, and the line that caused it. Commit the three scripts and your saved scene with their Unity .meta files to your existing project repository. Include brief README observations and screenshots showing the three behaviors and the combined object; reuse evidence from the tests above. Push, check instructor access, and submit the GitHub repository URL to Action 11A in Canvas before lab ends the same day. Keep Library, Temp, Logs, and other generated Unity folders out of Git. If setup blocks your run, record the exact error and ask the instructor during class about an approved evidence alternative.
[Needs to be verified]

Ready to explain? Ask a partner to choose a speed, rotation rate, or tint. Predict the result, run the scene, then point to the class and engine call responsible. Use the result to find any part you still need to study.
[Needs to be explained]


2) Action 11A – Classes in Unity (Answers the above ^^ if needed, use as template or copy paste if it is the same as your observation)
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

3) Click link below to follow visual guide if you are having trouble on what we need to turn in
https://github.com/saines007/CS077-Fall-2026-Team/tree/main/11-Week-11-Classes-in-Unity/Action-11A/Guide

4) Clean up

5) Lecture notes (can use for Wednesday):
   f(x) loop: prefabs
   obj -> class -> {vars, f(x), code} -> more code
   Create a class that moves (actions), different classes, all those classes on a particular object
   Color, Translate, Rotate, (jump etc)
   Update() telling you its updating every frame
   Start() telling you its only updating at startup
   
   Unity
   -----
   C#
   -----
   VS
   -----
   .NET

   Properties, unity makes a user interface for us to see
   3D Temp -> Add Cube -> (make script) Add script -> (test) run app
   
