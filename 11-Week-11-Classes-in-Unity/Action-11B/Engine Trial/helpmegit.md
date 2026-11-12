HOW TO GITHUB FROM UNITY
  
  1.Clone the Existing Repository and Create Your Subfolder:Local Setup.Clone your shared repository locally using GitHub Desktop or your terminal. Inside your local repository folder, navigate to where you want the project and create a new empty subfolder for your Unity project (for example, Games/MyNewGame).Verification: The subfolder exists inside your local repository directory, and GitHub Desktop shows the repository as clean.
  
  2.Create the Unity Project Without a Nested Git Repo:Unity Hub.Open Unity Hub, click New Project, choose your Unity version and template (e.g., 3D Core), and set the Location to point directly to the empty subfolder you just created. Crucial: Ensure Unity Hub does not create a separate .git folder inside your project subfolder. Click Create Project, wait for Unity to open, and then immediately close Unity (this generates the necessary project files without letting Unity build the heavy Library folder yet).Verification: Inside your subfolder, you should see Assets/, Packages/, and ProjectSettings/, but no .git folder.
  
  3.Implement the Proper Unity .gitignore:Ignore Generated Files.Create a plain text file named .gitignore directly inside your Unity project subfolder. Paste the standard Unity ignore rules into it so Git ignores unnecessary build and cache files:Plaintext/[Ll]ibrary/

  /[Tt]emp/
  /[Oo]bj/
  /[Bb]uild/
  /[Bb]uilds/
  /[Ll]ogs/
  /[Uu]serSettings/
  /[Mm]emoryCaptures/
  /[Rr]ootPackages/
  .vs/
  .gradle/
  ExportedObj/
  .idea/
  *.csproj
  *.unityproj
  *.sln
  *.suo
  *.tmp
  *.user
  *.userprs
  *.pidb
  *.booproj
  *.svd
  *.pdb
  *.mdb
  *.opendb
  *.VC.db
  *.db

  Verification: Open GitHub Desktop. You should see Assets, Packages, ProjectSettings, and .gitignore listed as changes to commit, while Library and UserSettings are grayed out or completely absent.4.Configure Git LFS for Large Binary Assets:Track Heavy Files.Open your terminal, navigate to the root of your repository, and ensure Git LFS is initialized (git lfs install).Next, create a .gitattributes file directly inside your Unity project subfolder (or at the root of your repo) and add tracking rules for large Unity assets:Plaintext*.png filter=lfs diff=lfs merge=lfs -text
  
  *.psd filter=lfs diff=lfs merge=lfs -text
  *.jpg filter=lfs diff=lfs merge=lfs -text
  *.jpeg filter=lfs diff=lfs merge=lfs -text
  *.fbx filter=lfs diff=lfs merge=lfs -text
  *.obj filter=lfs diff=lfs merge=lfs -text
  *.wav filter=lfs diff=lfs merge=lfs -text
  *.mp3 filter=lfs diff=lfs merge=lfs -text
  *.ogg filter=lfs diff=lfs merge=lfs -text
  *.unitypackage filter=lfs diff=lfs merge=lfs -text
  *.pdf filter=lfs diff=lfs merge=lfs -text
  *.ttf filter=lfs diff=lfs merge=lfs -text
  *.otf filter=lfs diff=lfs merge=lfs -text
  Verification: Run git lfs track in your terminal to confirm the file extensions are successfully registered under LFS management.

  5.Commit and Push via GitHub Desktop:Final Upload.Return to GitHub Desktop. You will see your new project files, .gitignore, and .gitattributes ready. Enter a commit summary (e.g., "Add initial Unity project structure with LFS and gitignore"), click Commit to main, and then click Push origin.
  Verification: Go to your GitHub repository in your web browser, open the subfolder, and verify that Assets, Packages, and ProjectSettings uploaded successfully without any file size limit errors.
