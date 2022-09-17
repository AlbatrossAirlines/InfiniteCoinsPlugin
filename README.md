# Infinite Coins Plugin
### Description
BepInEx plugin that gets rid of the cooldown on coin tosses.

### Installation
1. Install [BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) and run Ultrakill
   for a few seconds to generate the plugins folder
2. Download the latest [release](https://github.com/AlbatrossAirlines/InfiniteCoinsPlugin/releases)
3. Unzip and place the plugin's dll into the plugins folder

### Build Steps
Requires the [.NET SDK](https://dotnet.microsoft.com/en-us/download) 
1. Grab the `Assembly-CSharp.dll` file from your copy of Ultrakill (under `ULTRAKILL_Data\Managed`) and
   place it into a directory called `lib` in the root of the repo.
2. Run `dotnet build` and grab the built dll from `bin`.