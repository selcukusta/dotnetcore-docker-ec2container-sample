#!/bin/bash
dotnet restore ../src/NetCoreSampleApp.Test
dotnet build ../src/NetCoreSampleApp.Test
dotnet test ../src/NetCoreSampleApp.Test
