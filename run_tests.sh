#!/bin/sh
dotnet clean
dotnet restore
dotnet tool restore
dotnet fantomas .
dotnet build
dotnet test
