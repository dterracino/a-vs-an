﻿#r @"WikipediaAvsAnTrieExtractor\bin\Release\WikipediaAvsAnTrieExtractor.exe"
#r @"WikipediaAvsAnTrieExtractor\bin\Release\AvsAn.dll"
#r @"WikipediaAvsAnTrieExtractor\bin\Release\ExpressionToCodeLib.dll"

open System.IO
open System
open System.Text
open WikipediaAvsAnTrieExtractor
open AvsAnLib
open AvsAnLib.Internals
open ExpressionToCodeLib

let rawDictPath = @"E:\avsan.log"

let newLookup =
    File.ReadAllText(rawDictPath, Encoding.UTF8)
    |> NodeDeserializer.DeserializeDense
    |> (fun n -> n.Simplify(5).UnmarkUnsure(3))

newLookup
    |> NodeSerializer.SerializeDense
    |> ObjectToCode.PlainObjectToCode
    |> printfn "%s"

newLookup
    |> NodeSerializer.SerializeDenseNoStats
    |> ObjectToCode.PlainObjectToCode
    |> printfn "%s"
