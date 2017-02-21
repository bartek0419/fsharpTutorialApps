module Bowling.bowling

let (|Pins|_|) char =
    let zero = System.Convert.ToInt32 '0'
    if System.Char.IsDigit char then
        Some (System.Convert.ToInt32 char - zero)
    else if char = '-' then
        Some 0
    else
        None

let rec parseScore (chars: list<char>) : list<Option<int>> =
    match chars with
    | [] -> []
    | 'X' :: rest -> Some 10 :: parseScore rest
    | Pins x :: '/' :: rest -> Some x :: Some (10 - x) :: parseScore rest
    | Pins x :: rest -> Some x :: parseScore rest
    | _ :: rest -> None :: parseScore rest

let countScore (scores: list<int>) : int =
    let rec count frame scores =
        match scores with 
        | [] -> 0
        | 10 :: (b1 :: b2 :: _ as next) ->
            10 + b1 + b2 + (if frame = 10 then 0 else count (frame+1) next)
        | r1 :: r2 :: (b1 :: _ as next) when r1 + r2 = 10 ->
            10 + b1 +      (if frame = 10 then 0 else count (frame+1) next)
        | r1 :: r2 :: next ->
            r1 + r2 + count (frame+1) next

    count 1 scores

let sequence (optionals: list<option<'a>>) : option<list<'a>> =
    let rec sequence' acc optionals =
        match optionals, acc with
        | [],_ -> 
            Option.map List.rev acc
        | Some h :: t, Some acc -> 
            sequence' (Some (h :: acc)) t
        | _ -> 
            None

    sequence' (Some []) optionals

let bowlingScore (score: string) : Option<int> =
    score.ToCharArray()
    |> Array.toList
    |> parseScore
    |> sequence
    |> Option.map countScore

let TryGetBowlingScore(score: string, result : byref<int>) : bool = 
    match bowlingScore score with
    | Some x -> 
        result <- x
        true
    | None -> false