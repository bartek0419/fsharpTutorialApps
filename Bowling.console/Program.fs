// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    argv |> Array.iter (fun x -> printfn "%A" (Bowling.bowling.bowlingScore x))
    0 // return an integer exit code
