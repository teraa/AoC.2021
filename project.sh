#!/bin/bash

add () {
    target=$1

    dotnet new aoc2021 -n $target
    dotnet sln add $target
}

copy () {
    source=$1
    target=$2

    mkdir $target &&
    find $source/ -maxdepth 1 -type f -exec cp -t $target/ {} + &&
    mv $target/$source.csproj $target/$target.csproj &&
    sed -ri "s/$source/$target/" $target/* &&
    dotnet sln add $target
}

delete () {
    target=$1

    dotnet sln remove $target
    rm -r $target
}

if [ "$#" -lt 1 ]; then
    echo "Usage: $0 <add|copy|remove> ..."
    exit 1
fi

case "$1" in
    add)
        add $2
        ;;
    copy)
        copy $2 $3
        ;;
    remove)
        delete $2
        ;;
    *)
        echo "Invalid option"
        ;;
esac
