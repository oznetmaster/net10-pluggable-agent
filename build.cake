// Load the recipe
#load nuget:?package=NUnit.Cake.Recipe&version=2.0.0-beta.5
// Comment out above line and uncomment below for local tests of recipe changes
//#load ../NUnit.Cake.Recipe/recipe/*.cake

BuildSettings.Initialize
(
    context: Context,
    title: "Net10PluggableAgent",
    solutionFile: "net10-pluggable-agent.slnx",
    unitTests: "**/*.tests.exe",
    githubOwner: "NUnit",
    githubRepository: "net10-pluggable-agent",
    exemptFiles: new[] { "ProcessUtils.cs" }
);

var PackageTests = new PackageTest[] {
    new PackageTest(1, "Net6PackageTest")
    {
        Description = "Run mock-assembly.dll targeting .NET 6.0",
        Arguments = "testdata/net6.0/mock-assembly.dll",
        ExpectedResult = new ExpectedResult("Failed")
        {
            Total = 35, Passed = 21, Failed = 5, Warnings = 1, Inconclusive = 1, Skipped = 7,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("mock-assembly.dll") }
        }
    },
    new PackageTest(1, "Net7PackageTest")
    {
        Description = "Run mock-assembly.dll targeting .NET 7.0",
        Arguments = "testdata/net7.0/mock-assembly.dll",
        ExpectedResult = new ExpectedResult("Failed")
        {
            Total = 35, Passed = 21, Failed = 5, Warnings = 1, Inconclusive = 1, Skipped = 7,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("mock-assembly.dll") }
        }
    },
    new PackageTest(1, "Net8PackageTest")
    {
        Description = "Run mock-assembly.dll targeting .NET 8.0",
        Arguments = "testdata/net8.0/mock-assembly.dll",
        ExpectedResult = new ExpectedResult("Failed")
        {
            Total = 35, Passed = 21, Failed = 5, Warnings = 1, Inconclusive = 1, Skipped = 7,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("mock-assembly.dll") }
        }
    },
    new PackageTest(1, "Net9PackageTest")
    {
        Description = "Run mock-assembly.dll targeting .NET 9.0",
        Arguments = "testdata/net9.0/mock-assembly.dll",
        ExpectedResult = new ExpectedResult("Failed")
        {
            Total = 35, Passed = 21, Failed = 5, Warnings = 1, Inconclusive = 1, Skipped = 7,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("mock-assembly.dll") }
        }
    },
    new PackageTest(1, "Net10PackageTest")
    {
        Description = "Run mock-assembly.dll targeting .NET 10.0",
        Arguments = "testdata/net10.0/mock-assembly.dll --trace:Off",
        ExpectedResult = new ExpectedResult("Failed")
        {
            Total = 35, Passed = 21, Failed = 5, Warnings = 1, Inconclusive = 1, Skipped = 7,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("mock-assembly.dll") }
        }
    },
    new PackageTest(1, "AspNetCore60Test")
    {
        Description = "Run test using AspNetCore targeting .NET 6.0",
        Arguments = "testdata/net6.0/aspnetcore-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("aspnetcore-test.dll") }
        }
    },
    new PackageTest(1, "AspNetCore80Test")
    {
        Description = "Run test using AspNetCore targeting .NET 8.0",
        Arguments = "testdata/net8.0/aspnetcore-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("aspnetcore-test.dll") }
        }
    },
    new PackageTest(1, "AspNetCore90Test")
    {
        Description = "Run test using AspNetCore targeting .NET 9.0",
        Arguments = "testdata/net9.0/aspnetcore-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("aspnetcore-test.dll") }
        }
    },
    new PackageTest(1, "Net60WindowsFormsTest")
    {
        Description = "Run test using windows forms under .NET 6.0",
        Arguments = "testdata/net6.0-windows/windows-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("windows-test.dll") }
        }
    },
    new PackageTest(1, "Net80WindowsFormsTest")
    {
        Description = "Run test using windows forms under .NET 8.0",
        Arguments = "testdata/net8.0-windows/windows-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("windows-test.dll") }
        }
    },
    new PackageTest(1, "Net90WindowsFormsTest")
    {
        Description = "Run test using windows forms under .NET 9.0",
        Arguments = "testdata/net9.0-windows/windows-test.dll",
        ExpectedResult = new ExpectedResult("Passed")
        {
            Total = 2, Passed = 2, Failed = 0, Warnings = 0, Inconclusive = 0, Skipped = 0,
            Assemblies = new ExpectedAssemblyResult[] { new ExpectedAssemblyResult("windows-test.dll") }
        }
    }
};

BuildSettings.Packages.Add(new NuGetPackage(
    id: "NUnit.Extension.Net10PluggableAgent",
    source: BuildSettings.NuGetDirectory + "Net10PluggableAgent.nuspec",
    checks: new PackageCheck[]
    {
        HasFiles("LICENSE.txt", "README.md", "nunit_256.png"),
        HasDirectory("tools/agent").WithFiles(
            "nunit-agent-net10.dll", "nunit.engine.api.dll", "nunit.common.dll", 
            "nunit.extensibility.api.dll", "nunit.extensibility.dll", "nunit.agent.core.dll",
            "TestCentric.Metadata.dll", "Microsoft.Extensions.DependencyModel.dll"),
        HasDirectory("tools/net462").WithFiles(
            "nunit-agent-launcher-net10.dll", "nunit.engine.api.dll"),
        HasDirectory("tools/net8.0").WithFiles(
            "nunit-agent-launcher-net10.dll", "nunit.engine.api.dll")
    },
    testRunner: new AgentRunner(BuildSettings.NuGetTestDirectory + "NUnit.Extension.Net10PluggableAgent." + BuildSettings.PackageVersion + "/tools/agent/nunit-agent-net10.dll"),
    tests: PackageTests
    ));

BuildSettings.Packages.Add(new ChocolateyPackage(
    "nunit-extension-net10-pluggable-agent",
    source: BuildSettings.ChocolateyDirectory + "net10-pluggable-agent.nuspec",
    checks: new PackageCheck[]
    {
        HasDirectory("tools").WithFiles(
            "LICENSE.txt", "README.md", "nunit_256.png", "VERIFICATION.txt"),
        HasDirectory("tools/agent").WithFiles(
            "nunit-agent-net10.dll", "nunit.engine.api.dll", "nunit.common.dll",
            "nunit.extensibility.api.dll", "nunit.extensibility.dll", "nunit.agent.core.dll",
            "TestCentric.Metadata.dll", "Microsoft.Extensions.DependencyModel.dll"),
        HasDirectory("tools/net462").WithFiles(
            "nunit-agent-launcher-net10.dll", "nunit.engine.api.dll"),
        HasDirectory("tools/net8.0").WithFiles(
            "nunit-agent-launcher-net10.dll", "nunit.engine.api.dll")
    },
    testRunner: new AgentRunner(BuildSettings.ChocolateyTestDirectory + "nunit-extension-net10-pluggable-agent." + BuildSettings.PackageVersion + "/tools/agent/nunit-agent-net10.dll"),
    tests: PackageTests));

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

Build.Run();
