//
// F# program to analyze Divvy daily ride data.
//
// Mohmed Hira
// U. of Illinois, Chicago
// CS 341, Spring 2019
// Project #04
//
#light

module project04

//
// ParseLine and ParseInput
//
// Given a sequence of strings representing Divvy data, 
// parses the strings and returns a list of lists.  Each
// sub-list denotes one bike ride.  Example:
//
//   [ [176;74;1252;21;595;1986;1]; ... ]
//
// The values are station id (from), station id (to), bike
// id, starting hour (0..23), trip duration (secs), birth
// year (0=>not specified), and gender (0=>not specified, 
// 1=>identifies as male, 2=>identifies as female).
//
let ParseLine (line:string) = 
  let tokens = line.Split(',')
  let ints = Array.map System.Int32.Parse tokens
  Array.toList ints

let rec ParseInput lines = 
  let rides = Seq.map ParseLine lines
  Seq.toList rides  

let rec _nM a L = 
    match L with
    | [] -> 0
    | []::[] -> 0
    | hd::tl when hd.[6] = a -> 1 + _nM a tl
    | _::tl -> 0 + _nM a tl

let rec aAge a L = 
    match L with
    | [] -> []
    | []::[] -> []
    | hd::tl ->if hd.[5] = a then aAge a tl else (System.DateTime.Now.Year-hd.[5]) :: aAge a tl

let rec ageLen L =
    match L with
    | [] -> 0
    | hd::tl -> 1 + ageLen tl

let rec ageSum L =
    match L with
    | [] -> 0
    | hd::tl -> hd + ageSum tl

let rec durL L =
    match L with 
    | [] -> []
    | []::[] -> []
    | hd::tl -> hd.[4] :: durL tl

let rec lenDur le a L =
    match L with 
    | [] -> 0
    | hd::tl -> if le < hd then 
                    if a >= hd then 1 + lenDur le a tl 
                    else 0 + lenDur le a tl 
                else 0 + lenDur le a tl

let rec lenD L =
    match L with 
    | [] -> 0
    | hd::tl -> 1 + lenD tl

let rec rideL L =
    match L with
    | [] -> []
    | []::[] -> []
    | hd::tl -> hd.[3]::rideL tl

let rec hourRide h L =
    match L with
    | [] -> 0
    | hd::tl when hd = h -> 1 + hourRide h tl
    | _::tl -> 0 + hourRide h tl

let rec pS a =
    if(a = 0) then 
        printf "" 
    else
        printf "*"  
        pS(a-1) 

let countAndPrint h L =
    let nu = hourRide h L
    let nuS = nu/10
    printf " %A: " h 
    pS nuS
    printfn "%A" nu
        
    

[<EntryPoint>]
let main argv =
  //
  // input file name, then input divvy ride data and build
  // a list of lists:
  //
  printf "filename> "
  let filename = System.Console.ReadLine()
  let contents = System.IO.File.ReadLines(filename)
  let ridedata = ParseInput contents

  //printfn "%A" ridedata
  let N = List.length ridedata

  printfn ""
  printfn "# of riders: %A" N
  printfn ""
  
  let numM = _nM 1 ridedata
  let numF = _nM 2 ridedata
  let pNumM = (float(numM) / float(N))*100.0
  let pNumF = (float(numF) / float(N))*100.0


  printfn "%% of riders identifying as male: %A (%A%%)" numM pNumM
  printfn "%% of riders identifying as female: %A (%A%%)" numF pNumF
  printfn ""

  let aList = aAge 0 ridedata
  let aLen = ageLen aList
  let aSum = ageSum aList

  if(aLen = 0) then
    printfn "Average age: %A" 0.0
  else
    printfn "Average age: %A" (float(aSum)/float(aLen))

  //printfn "Average age: %A" avgAge
  printfn ""

  let dList = durL ridedata
  let durDiv = lenD dList

  let loL = lenDur 0 1800 dList
  let ploL = (float(loL)/float(durDiv))*100.0

  let moL = lenDur 1800 3600 dList
  let pmoL = (float(moL)/float(durDiv))*100.0

  let mmoL = lenDur 3600 7200 dList
  let pmmoL = (float(mmoL)/float(durDiv))*100.0

  let hoL = lenDur 7200 86400 dList
  let phoL = (float(hoL)/float(durDiv))*100.0

  printfn "** Ride Durations:"
  printfn " 0..30 mins: %A (%A%%)" loL ploL
  printfn " 30..60 mins: %A (%A%%)" moL pmoL
  printfn " 60..120 mins: %A (%A%%)" mmoL pmmoL
  printfn " > 2 hours: %A (%A%%)" hoL phoL

  printfn ""
  let rideLi = rideL ridedata
  printfn "** Ride Start Time Histogram:"
  List.map (fun v -> countAndPrint v rideLi)[0..23]

  0 