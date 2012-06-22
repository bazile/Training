namespace FSharpLibrary

open System

type FSharpClass() = 
    static member public WriteMessage() =
        Console.WriteLine("Message from F# Library")
