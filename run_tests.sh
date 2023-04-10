#!/bin/sh

rm -rf report
mkdir report

dotnet clean
dotnet restore
dotnet tool restore
dotnet fantomas . --recurse --force
dotnet build
dotnet test
