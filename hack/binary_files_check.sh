#!/bin/bash


function checkForBinaries() {
    binaryFilesCount=0
    for file in $(git diff --cached --name-only --diff-filter=d) ; do 
        binaryFlag=$(file --mime ${file} | grep binary)
        if [[ ! -z "${binaryFlag}" ]] ; then
            binaryFiles="${binaryFiles}\n$file"
            let binaryFilesCount+=1
        fi
    done

    if [[ ! -z "${binaryFiles}" && "${binaryFilesCount}" > 0 ]] ; then
        printf "\nFound below binary files: \n\t"
        printf "\033[33m${binaryFiles}\033[0m \n\n"
        printf "Please fix and continue. Fore more details look at .git/hooks/pre-commit\n"
        exit 1
    fi
}

checkForBinaries
