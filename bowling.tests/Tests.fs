module bowling.tests.tests

open Xunit
open FsUnit.Xunit
    
[<Fact>]
let ``12 strikes in row`` () =
    let expected = Some 300
    let actual = Bowling.bowling.bowlingScore "XXXXXXXXXXXX"
    actual |> should equal expected

[<Fact>]
let ``9-`` () =
    let expected = Some 90
    let actual = Bowling.bowling.bowlingScore "9-9-9-9-9-9-9-9-9-9-"
    actual |> should equal expected

[<Fact>]
let ``5/`` () =
    let expected = Some 150
    let actual = Bowling.bowling.bowlingScore "5/5/5/5/5/5/5/5/5/5/5"
    actual |> should equal expected

[<Fact>]
let ``X9`` () =
    let expected = Some 187
    let actual = Bowling.bowling.bowlingScore "X9/5/72XXX9-8/9/X"
    actual |> should equal expected