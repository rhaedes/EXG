# Sitecore.Speak.Components.Web.Publish

## To get started
Install:

1. Node.js

NodeJs is installed along with NPM, the Node Package Manager.
Once node and npm is installed, you need to install some node modules:

1. Install gulp globally `npm install gulp -g`

Note: If you want to run this tool without Visual Studio integration,
you can also run `npm install`, then you have the basics set up to be
able to run the tool.

## Visual studio integration
The project file is of type .njsproj, so to be able to read that type
you need to install to install the [**Node.js Tools**](https://nodejstools.codeplex.com/releases/view/612573) extension by
Microsoft.

Once installed you need to download the dependencies from NPM. In the
project open npm > dev > select all missing modules > right click >
Install missing packages. Once done installing you will be prompted
'Path Too Long Warning'. Select 'Do nothing, but warn me next time it
happens'.

To run tasks directly from Visual Studio install the
**Task Runner Explorer** extenstion by Mads Kristensen (Microsoft).

Installing these two extensions will automatically start the watch
tool when you open the solution.

## Commands
Here is a list of useful commands that you might want to use.

I will here list the command you would write in the cmd prompt to run
the given task.

`gulp`: Will run `sync` and `watch` tasks.

`gulp watch`: Start watching files from your csproj file. Will deploy
files that changes to your local Sitecore instance.

`gulp sync`: Will run `clean` and `deploy`.

`gulp clean`: Will remove all files from the cleanlist specified in
the gulpsettings.json file.

`gulp deploy`: Will copy all files defined in .csproj file to your
Sitecore instance.

`gulp install`: Will reinstall Sitecore instance.

`gulp build`: Will run the build on CI for your current branch.

## Settings
### gulpsettings.json
The tool will automatically look for a file called gulpsettings.json
and will not work if it is not present.

Two settings are available:

1. projectsettings
1. cleanlist

`projectsettings` should have a reference to a project file that describes
where your project and instance folders are located. If you are using TDS
for your project you can point it to a .scproj file and use that directly.

It will automatically look for a .user file with the same name as your
projectsettings file. If it is present it will use those settings over the
default ones.

Example of projectsettings file:

```
<Project>
  <PropertyGroup>
    <SourceWebPhysicalPath>..\Sitecore.Speak.Components.Web</SourceWebPhysicalPath>
    <SourceWebVirtualPath>/Sitecore.Speak.Components.Web.csproj</SourceWebVirtualPath>
    <SitecoreDeployFolder>C:\inetpub\wwwroot\speak\Website</SitecoreDeployFolder>
  </PropertyGroup>
</Project>
```

`cleanlist` is an array of files, directories or globs that belongs to your
project. Only list files that you have complete control over. `clean` task
will use this list to remove files from your instance.