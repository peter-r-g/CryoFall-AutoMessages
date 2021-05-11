# CryoFall Auto Messages
This server-side only mod allows you to send automatic messages to all players in the server through their chat window.
## Installation
1. Download the latest mpk at the [releases](https://github.com/peter-r-g/CryoFall-AutoMessages/releases/latest) page.
2. Place the mpk within your servers Core directory.
3. Navigate to your servers Data directory and add the following line to the ModsConfig.xml: `<mod>AutoMessages_VERSION</mod>` where VERSION is the version specified in the release.

## Configuration
All configuration has to be done through code currently as I cannot find any methods in the game to store this information externally. To configure this you need to open the mpk file with any archive program ([WinRAR](https://www.win-rar.com/), [7Zip](https://www.7-zip.org/), etc) and navigate to Scripts/AutoMessages/AutoMessagesSettings.cs. Within that file you will find all the options you can edit with explanations alongside them.

## Contributing
Feel free! All I ask is that you follow the conventions set by Microsoft.
* [General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions?redirectedfrom=MSDN)
* [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

## Media
![image](https://user-images.githubusercontent.com/11802285/117887737-2bc73b80-b27f-11eb-95d2-13bd4eeed611.png)
