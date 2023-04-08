#!/bin/sh
dotnet clean
dotnet restore
dotnet build
dotnet test
