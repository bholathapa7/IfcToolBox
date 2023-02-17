<p align="center">
  <img width="128" align="center" src="./Assets/IfcToolbox_Applogo.png">
</p>
<h1 align="center">
  IFC Toolbox
</h1>
<p align="center">
  Simple tools for processing IFC files.
</p>
<p align="center">
  <a style="text-decoration:none" href="https://www.microsoft.com/en-us/p/ifc-toolbox/9n77phd2h471#activetab=pivot:overviewtab">
    <img src="https://img.shields.io/badge/Microsoft%20Store-Download-blue" alt="Store link" />
  </a>
  <a style="text-decoration:none" href="https://github.com/youshengCode/IfcToolbox/releases">
    <img src="https://img.shields.io/badge/Latest%20Version-1.2.1.0-brightgreen" alt="Version" />
  </a>
  <a style="text-decoration:none" href="https://bimmars.com">
    <img src="https://img.shields.io/badge/More%20Info-BIM Mars-red" alt="More" />
  </a>
</p>




## How to Run this file in Linux

To run this file in Linux, you need to install dotnet-sdk-6.0 which can be found in (https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)
- wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
- sudo dpkg -i packages-microsoft-prod.deb
- rm packages-microsoft-prod.deb

- sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0

Running above command install both runtime and sdk, if it doesn't, install runtime also.

Check dotnet version with command: dotnet --version
If it's showing dotnet sdk-6.0, then you are good to go.

if not showing then you need to remove previous sdk installed with command line:
- sudo apt remove dotnet*
- sudo apt remove aspnetcore*
- sudo rm /etc/apt/sources.list.d/microsoft-prod.list
- sudo apt update
- sudo apt install dotnet-sdk-6.0

Then repeat the same process again from first

# To Run the dotnet project:
- You need to build first with command: dotnet build
- Then you need to set permission for IfcConvert CLI:  sudo chmod +x IfcToolbox.Core/Convert/Resources/IfcConvert
- Run the project with: dotnet run --project IfcToolBox.Examples <put ifc file full path here>
 E.g: dotnet run --project IfcToolbox.Examples/ home/angelswing/Desktop/projects/angelswing/Building.ifc
 
- A new folder gets created in the same path you providing the args for the ifc file with splitted ifc files and converted to .obj files
