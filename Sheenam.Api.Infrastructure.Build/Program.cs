﻿//===========================================================
//Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==========================================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var aDotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "Sheenam Build Pipeline",

    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        },

        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Dictionary<string, Job>
    {
        {
            "Build",
            new Job
            {
                RunsOn = BuildMachines.Windows2022,

                Steps = new List<GithubTask>
                {
                    new CheckoutTaskV2
                    {
                        Name = "Checking Out Code"
                    },

                    new SetupDotNetTaskV1
                    {
                        Name = "Seting Up .NET",

                        TargetDotNetVersion = new TargetDotNetVersion
                        {
                            DotNetVersion = "6.0.100-rc.1.21463.6",
                            IncludePrerelease = true
                        }
                    },

                    new RestoreTask
                    {
                        Name = "Restoring Nurget Packages"
                    },

                    new DotNetBuildTask
                    {
                        Name = "Building Project"
                    },

                    new TestTask
                    {
                        Name = "Running Tests"
                    }
                }
            }
        }
    }
};

string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
string directoryPath = Path.GetDirectoryName(buildScriptPath);

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

aDotNetClient.SerializeAndWriteToFile(githubPipeline, path: buildScriptPath);