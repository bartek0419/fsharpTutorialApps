open Suave

let scoreHandler (input: string) : WebPart =
    match Bowling.bowling.bowlingScore input with
    | Some x -> Successful.OK (x.ToString())
    | None -> RequestErrors.BAD_REQUEST("ERROR")

startWebServer defaultConfig (Filters.pathScan "/%s" scoreHandler)