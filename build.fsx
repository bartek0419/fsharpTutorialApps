#r @"packages/Build/FAKE/tools/FakeLib.dll"

open Fake

Target "Build" (fun _ ->
    MSBuildRelease "bin" "Build" ["bowling.sln"]
    |> Log "Build output"
)

open Fake.Testing // for testing helper functions

Target "Tests" (fun _ ->
    ["bin/bowling.tests.dll"]
    |> xUnit2 (fun xunitParams -> 
        { xunitParams with ToolPath = @"packages/Build/xunit.runner.console/" 
                                    + @"tools/xunit.console.exe" }
    )
)

// Targets above    

"Build"
    ==> "Tests"

RunTargetOrDefault "Tests"
