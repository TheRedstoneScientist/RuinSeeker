# RuinSeeker

To create and access the git (after installing git)

Open Command Prompt
cd C:/Enter/Folder/Name/You/Want/This/In
git clone https://github.com/TheRedstoneScientist/RuinSeeker

Before you start a work session:
cd C:/Enter/The/Folder/Everything/Is/In
git fetch
git pull

When you are ready to save changes
cd C:/Enter/The/Folder/Everything/Is/In
git add -all
git commit -m “Write down your message that describes your changes”
git push

To discard changes:
cd C:/Enter/The/Folder/Everything/Is/In
git stash

Any other operations like branches and pull requests we’ll deal with later.

NOTE: DO NOT PUSH CHANGES MADE DIRECTLY TO THE UNITY SCENE UNLESS YOU ARE THE ONLY ONE WORKING ON IT.
It is fine to edit and commit changes to assets like scripts but changes to game objects and components need to be made while only one person is working on it.
