// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

// Targets
Target "BuildAll" (fun _ -> ()
)

// start build
RunTargetOrDefault "BuildAll"
