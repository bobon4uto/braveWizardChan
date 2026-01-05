# braveWizardChan
a mod for Treasure 'n Trio that makes WizardChan brave  
## Installation
### finding game folder
First, find the game folder (where exe file is)  
For steam it can be found by 
1. pressing the `gear icon` in game launch window (called `manage`)
2. Pressing `properties` in drop-down menu
3. `Installed files` in newely opened window
4. `Browse...`  
### Download BepInEx
Download BepInEx from their [release page](https://github.com/BepInEx/BepInEx/releases) (Assuming win64 - [BepInEx_win_x64_5.4.23.4.zip](https://github.com/BepInEx/BepInEx/releases/download/v5.4.23.4/BepInEx_win_x64_5.4.23.4.zip))  
### Installation of BepInEx
Unzip files into game directory **(just open the zip archive and drag and drop everything)**  
the game folder should look something like this:
- `Treasure 'n Trio`
  - `BepInEx`
    - `core`
  - `Treasure 'n Trio.exe`  
  - other stuff...
### Check if BepInEx is working
Run the game once, you dont have to play anything, just start the game, wait for the game to load the title screen and exit. (skipping intro cutscene is fine)  
BepInEx will generate all the necessary files automatically, now open the `BepInEx` folder inside the game folder and you will see new folders besides `core` and new `LogOutput.log` file. If anything is wrong, it will be in that file, also you can enable console in `config/BepInEx.cfg` and the logging will happen in a console window that will appear with the game launch.
```toml
[Logging.Console]

## Enables showing a console for log output.
# Setting type: Boolean
# Default value: false
Enabled = true
```
### Download the mod
Download `braveWizardChan.zip` from this repo [release page](https://github.com/bobon4uto/braveWizardChan/releases/tag/mod1.0.0) ([direct link to file](https://github.com/bobon4uto/braveWizardChan/releases/download/mod1.0.0/braveWizardChan.zip))
### Install the mod
unzip `BepInEx` folder from `braveWizardChan.zip` to the *game folder* **(open the zip, drag and drop)**  
notice, that this BepInEx will be merged with an existing one. Zip file is structured specifically to enable this trick. If you want to explicitly install the mod, create `BepInEx/plugins` folder in the game directory, and copy `braveChanWizard` folder from `braveChanWizard.zip/BepInEx/plugins` to new folder.
### Play the mod, duh
Do note that brave WizardChan is op, many puzzles just break with her being able to teleport near monsters.
## Building
### Requirements
You will need:
- [dotnet](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-5.0.17-windows-x64-installer) (it will pull BepInEx libs from nupkgs and do the compilation)
- [BepInEx](#download-bepinex)  installed in the game folder
- AN Already [installed mod](#download-the-mod) (You actually don't need the mod itself, but specific DLL)
- OR [MonoMod](https://github.com/MonoMod/MonoMod/releases/tag/v22.07.31.01)

It will be a bit more complicated with MonoMod, but you will be able to compile/make mods for different versions of the game (in fact, for any unity mono game)
### Building process with an already instlled mod
If your steam installation is not on C drive, or if the game is not in the steam at all, you will have to change this in braveWizardChan.csproj

change:
```xml
<!--  Assuming normal steam installation.  -->
    <GameName>Treasure 'n Trio</GameName>
    <GameFolder>C:\Program Files (x86)\Steam\steamapps\common\$(GameName)</GameFolder>
```
to:
```xml
<!--  if the game is in F:/some/folder. (don't touch GameName, it should 
match exe and (gamename)_data folder)  -->
    <GameName>Treasure 'n Trio</GameName>
    <GameFolder>F:/some/folder</GameFolder>
```
Then, run `dotnet build` inside project folder (from VS code terminal, or normal one), it will compile and replace old version with newly compiled.  
It might stall if Internet is bad or the service is blocked, I had to use VPN to compile.
### Building process with MonoMod
install MonoMod from their [release page](https://github.com/MonoMod/MonoMod/releases/tag/v22.07.31.01) (I was using [MonoMod-22.07.31.01-net452.zip](https://github.com/MonoMod/MonoMod/releases/download/v22.07.31.01/MonoMod-22.07.31.01-net452.zip), I do not know whats the difference and which one is appropriate, but netstandart20 just didnt work on my machine).
Unzip installed folder anywhere and open it, open it in terminal (right click - `open terminal/console` for newer windows, click on pathname and write `cmd` then press enter for older ones)

Run this command (Note that this assumes normal steam path. you can find this `Assembly-CSharp.dll` file inside `Treasure 'n Trio_data/managed` folder of your istallation and drag and drop it into terminal to paste the full path)
```powershell
.\MonoMod.RuntimeDetour.HookGen.exe "C:\Program Files (x86)\Steam\steamapps\common\Treasure 'n Trio\Treasure 'n Trio_Data\Managed\Assembly-CSharp.dll"
```
If its cmd you don't have to put .\ before exe name. More on HookGen usage [here](https://github.com/MonoMod/MonoMod/blob/master/README-RuntimeDetour.md#using-hookgen).
This will generate `MMHOOK_Assembly-CSharp.dll` inside `Treasure 'n Trio_data/managed` folder,  
create `BepInEx/plugins/braveWizardChan` folder, move `MMHOOK_Assembly-CSharp.dll` to `BepInEx/plugins/braveWizardChan` folder. 

 Now you can follow [Building process with an already instlled mod](#building-process-with-an-already-instlled-mod)   
 *(why markdown is so weird? What do you mean I have to write it all with `-` instead of space and no capital letters??)*

## Helpful recourses

[Tools for modding (from BepInEx docs)](https://docs.bepinex.dev/articles/dev_guide/dev_tools.html)  
[Templates for Dotnet BepInEx project](https://github.com/BepInEx/BepInEx.Templates)
