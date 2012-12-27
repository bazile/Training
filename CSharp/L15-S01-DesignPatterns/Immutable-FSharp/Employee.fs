// Learn more about F# at http://fsharp.net
// See also http://fsharpforfunandprofit.com/

namespace Belhard.DesignPatterns

//module Employee

open System

type public Employee(aFirtstName:string, aLastName:string, aDateHired:DateTime) =
    member this.FirstName = aFirtstName
    member this.LastName = aLastName
    member this.DateHired = aDateHired
