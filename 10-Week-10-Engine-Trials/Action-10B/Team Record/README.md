# CS077 / Action 10B / Three Hello World Investigations

Current phase: independent study with teams and tools.

Put these in your repository.
Console/
Editable console project: .csproj, Program.cs, Greeting.cs.

WPF/
Editable WPF project: .csproj, App files, MainWindow.xaml, MainWindow.xaml.cs, Greeting.cs.

EngineTrial/
Editable engine project/scene/script and needed assets/settings, including attempted work.

README.md
Lecture + Console + XAML + Engine notes: prediction, attempt, result, explanation, evidence paths and sources; whiteboard/Discord peer record and verified AI check.

Evidence/
Lecture/whiteboard evidence, console output, running WPF window, engine scene/object/script and result or error screenshots; cs077-10b-receipt.txt.

Team record / only if grouped
Lead name, members/contributions and task list with Task | Owner | Status. Keep it in README.md.

## Lecture investigation notes

>All programming languages do the same things just in different ways. It may be beneficial to use another language.
>Work order, A0 -> B0 -> A1 -> B1 and so on.
>Functions Need to be specified with their scope and whether or not they return something.

## Console investigation notes

Prediction: "Hello, World, Ari!"
What I tried: Created a C# Console App named HelloConsole in Visual Studio, added Greeting.cs, replace Program.cs code and attempted to build/run.
Result / error: CS8370 Feature 'top-level statements' is not available in C# 7.3. Please use language version 9.0 or greater.
What it means / next step: The project was creating targeting an older .NET Framework which does not support C# 9 top-level statements. Next step: Create a new Console App selecting .NET 9.0.
Evidence file/link: 10B Error Screenshot (https://github.com/saines007/CS077-Fall-2026-Team/blob/main/10-Week-10-Engine-Trials/Action-10B/Evidence/Screenshots/CS077_10B_Error_Screenshot.png)

## XAML / WPF investigation notes

XAML does: Defines and formats the visual layout, controls, and appearance of a Windows application UI. It separates visual design from program code while connecting UI elements to C# through names and event handlers.
C# code-behind does: Handles program logic, user interactions, and event responses like button clicks. It dynamically updates XAML controls at runtime and bridges the visual UI with underlying business objects
Prediction: The C# application will perform its intended function or display the expected UI/console output based on the project template selected.
What I tried: Configured the C# project in Visual Studio, added the necessary source files/XAML markup, and attempted to build/run the application.
Result / error: CS0105 The using directive for 'System.Windows' appeared previously in this namespace
What it means / next step: The namespace System.Windows has been imported more than once in the same file. To resolve the warning, open MainWindow.xaml.cs and delete the duplicate using System.Windows; line at line 2.
Evidence file/link: CS0105 Warning Screenshot (https://github.com/saines007/CS077-Fall-2026-Team/blob/main/10-Week-10-Engine-Trials/Action-10B/Evidence/Screenshots/CS077_10B_WPF_Error_Screenshot.png)

## Engine investigation notes

I predicted I would encounter an error and I did.
Initially I was confused because I needed a Greeting.cs which I did not have because I skipped steps 2 and 3 because Luisa was doing them. Once she created those I was able to add it to the Unity and it ran without errors. 
Recorded Error:
Assets\Scripts\HelloWorld.cs(2,7): error CS0246: The type or namespace name 'HelloInvestigation' could not be found (are you missing a using directive or an assembly reference?). The result was when I pressed play the message was displayed in the console.


## Working arrangement
Group
Lead: Kevin
Members / contributions: Luisa - Worked on "Hello World" in visual studio for the console part of the requirement and XAML -R2,R3.
Kevin - Collaborated with Vinh for White Board requirement -R1.
Pascual - Set up the GitHub repository and organized structure -R1,R5.
Roman - Worked on the engine component of the requirement -R4. 
Vinh - Collaborated with Kevin for White Board requirement R1.
Task | Owner | Status:
WB      | Kevin    | Done
WB      | Vinh     | Done
GitHub  | Pascual  | Done
Console | Luisa    | Done
XAML    | Luisa    | Done
Engine  | Roman    | Done
Submit  | Everyone | Done



## My handoff
GitHub: https://github.com/saines007/CS077-Fall-2026-Team/tree/main/10-Week-10-Engine-Trials/Action-10B
Required: Console/, WPF/, EngineTrial/, Evidence/ and cs077-10b-receipt.txt.
Canvas: https://sbccd.instructure.com/courses/66799/assignments/1913573
This record does not verify submission or grading.
