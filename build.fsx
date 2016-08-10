// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open System
open System.IO

let buildOne cmd =
    async {
        return cmd
    }

// Targets
Target "BuildAll" (fun _ ->
    !! "**/build.cmd"
    |> Seq.filter (fun it -> not <| it.Equals(Path.GetFullPath("./build.cmd"), StringComparison.OrdinalIgnoreCase))
    |> Seq.map (fun it -> Shell.AsyncExec(it, "", Path.GetDirectoryName(it)))
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.map (fun it -> if it = 0 then true else false)
    |> Array.fold (&&) true
    |> fun it -> if not it then failwith "One or more of the child builds failed"
)

// start build
RunTargetOrDefault "BuildAll"
