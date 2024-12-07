package day1

import (
	"slices"
	"strconv"
	"strings"

	"github.com/kratofl/adventofcode/2024/filereader"
)

func PartOne() int {
	fileContent, _ := filereader.ReadFile("day1/input.csv")

	var leftList []int
	var rightList []int
	for _, line := range fileContent {
		split := strings.Split(line, "   ")
		firstNumber, _ := strconv.Atoi(split[0])
		secondNumber, _ := strconv.Atoi(split[1])

		leftList = append(leftList, firstNumber)
		rightList = append(rightList, secondNumber)
	}
	slices.Sort(leftList)
	slices.Sort(rightList)

	var result int
	for idx, number := range leftList {
		distance := number - rightList[idx]
		if distance < 0 {
			distance *= -1
		}
		result += distance
	}

	return result
}

func PartTwo() int {
	fileContent, _ := filereader.ReadFile("day1/input.csv")

	var leftList []int
	var rightList []int
	for _, line := range fileContent {
		split := strings.Split(line, "   ")
		firstNumber, _ := strconv.Atoi(split[0])
		secondNumber, _ := strconv.Atoi(split[1])

		leftList = append(leftList, firstNumber)
		rightList = append(rightList, secondNumber)
	}

	var result int
	for _, l := range leftList {
		var count int
		for _, r := range rightList {
			if l == r {
				count += 1
			}
		}
		result += l * count
	}

	return result
}
