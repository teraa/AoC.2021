#!/bin/bash

if [ "$#" -lt 1 ]; then
    echo "Usage: $0 <project> [expected_result...]"
    exit 1
fi

project=$1
expected=${@:2}
cd $1

result=$(dotnet run < input.txt)

if [ "$#" -eq 1 ]; then
    echo $result
else
    diff -w <(echo "$expected") <(echo "$result") && echo OK
fi
