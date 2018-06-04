 #load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "SecureBootstrap",
                            repositoryOwner: "gavin@phoenixdesign.co.nz",
                            repositoryName: "securebootstrap",
                            shouldPostToMicrosoftTeams: true,
                            shouldRunGitVersion: true
                            );

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Task("Init")
	.Does(() => {
		Information("Init");
    });

BuildParameters.Tasks.CleanTask
    .Does(() => {
    });

BuildParameters.Tasks.RestoreTask.Task.Actions.Clear();
BuildParameters.Tasks.RestoreTask
    .Does(() => {
    });

BuildParameters.Tasks.PackageTask.Task.Actions.Clear();
BuildParameters.Tasks.PackageTask
    .Does(() => {
    });

BuildParameters.Tasks.BuildTask.Task.Actions.Clear();
BuildParameters.Tasks.BuildTask
    .Does(() => {
    });

Task("Publish")
	.Does(() => {
	});



// Simplified...
Build.Run();
