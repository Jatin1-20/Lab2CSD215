// For more information see https://aka.ms/fsharp-console-apps
// Print a greeting message
printfn "Hello from F#"

// options for cuisine
type Cuisine =
    | Korean
    | Turkish

// options for movie types
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// different activities a person can engage in
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float  // distance in km and fuel charge per km

let calculateBudget (activity : Activity) =
    match activity with
    | BoardGame | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks | IMAXWithSnacks | DBOXWithSnacks -> 12.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (distance, fuelChargePerKm) -> float distance * fuelChargePerKm

let budgetForMovie = calculateBudget (Movie IMAX)
let budgetForRestaurant = calculateBudget (Restaurant Turkish)
let budgetForLongDrive = calculateBudget (LongDrive (100, 0.05))  // 100km long drive with fuel charge of 0.05 CAD/km

printfn "Budget for watching an IMAX movie: %.2f CAD" budgetForMovie
printfn "Budget for dining at a Turkish restaurant per couple: %.2f CAD" budgetForRestaurant
printfn "Budget for a 100km long drive: %.2f CAD" budgetForLongDrive
