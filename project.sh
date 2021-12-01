#!/bin/bash

create () {
    source=$1
    target=$2

    mkdir $target &&
    cp $source/* $target/ &&
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
        create 'AoC.Template' $2
        ;;
    copy)
        create $2 $3
        ;;
    remove)
        delete $2
        ;;
    *)
        echo "Invalid option"
        ;;
esac
