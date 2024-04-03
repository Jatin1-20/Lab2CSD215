// Print a greeting message
printfn "Hello from F#"

type Coach = { Name: string; FormerPlayer: bool }

type Stats = { Wins: int; Losses: int }

type Team = { Name: string; Coach: Coach; Stats: Stats }

let coaches = [
    { Name = "sahil singh"; FormerPlayer = true }
    { Name = "Steve smith"; FormerPlayer = true }
    { Name = "kohli"; FormerPlayer = false }
    { Name = "Dhoni"; FormerPlayer = true }
    { Name = "Bumrah"; FormerPlayer = false }
]

let stats = [
    { Wins = 50; Losses = 32 }
    { Wins = 48; Losses = 34 }
    { Wins = 55; Losses = 27 }
    { Wins = 45; Losses = 37 }
    { Wins = 42; Losses = 40 }
]

let teams = List.zip3 
                ["Canada"; "India"; "USA"; "Bangladesh"; "London"]
                coaches
                stats
            |> List.map (fun (name, coach, stat) -> { Name = name; Coach = coach; Stats = stat })

let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

let successPercentages = 
    successfulTeams 
    |> List.map (fun team -> 
        let wins = float team.Stats.Wins
        let losses = float team.Stats.Losses
        let successPercentage = (wins / (wins + losses)) * 100.0
        (team.Name, successPercentage))

// Print results
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "- %s" team.Name)

printfn "\nSuccess Percentages:"
successPercentages |> List.iter (fun (teamName, percentage) -> printfn "- %s: %.2f%%" teamName percentage)
