package main

import (
	"fmt"
	filereader "kratofl/aoc2023/Filereader"
	day5 "kratofl/aoc2023/day5"
)

func main() {
	fileContent, err := filereader.ReadFile("Day5/Input.csv")

	if err != nil {
		fmt.Println(err)
		return
	}
	fmt.Printf("Part One: %d\n", day5.PartOne(&fileContent))
	fmt.Printf("Part Two: %d\n", day5.PartTwo(&fileContent))
}
