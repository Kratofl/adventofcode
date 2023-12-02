package main

import (
	"fmt"
	filereader "kratofl/aoc2023/Filereader"
	day1 "kratofl/aoc2023/day1"
)

func main() {
	fileContent, err := filereader.ReadFile("Day1/Input.csv")

	if err != nil {
		fmt.Println(err)
		return
	}
	fmt.Printf("Part One: %d\n", day1.PartOne(&fileContent))
	fmt.Printf("Part Two: %d\n", day1.PartTwo(&fileContent))
}
