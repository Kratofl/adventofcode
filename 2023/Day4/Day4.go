package day4

import (
	"strconv"
	"strings"
)

func PartOne(input *[]string) int {
	var sum int
	for _, line := range *input {
		cardSum := 0
		numbers := strings.Split(line, ": ")[1]
		splittedNumbers := strings.Split(numbers, " | ")
		winningNumbers := convStringToIntArray(removeEmptyEntries(strings.Split(splittedNumbers[0], " ")))
		myNumbers := convStringToIntArray(removeEmptyEntries(strings.Split(splittedNumbers[1], " ")))

		for _, winningNumber := range winningNumbers {
			for _, myNumber := range myNumbers {
				if winningNumber == myNumber {

					if cardSum == 0 {
						cardSum = 1
						break
					}
					cardSum *= 2
				}
			}
		}
		sum += cardSum
	}
	return sum
}

func PartTwo(input []string) int {
	totalCards := make([]int, len(input))

	for i := range input {
		totalCards[i] = 1
	}

	for lineIdx, line := range input {
		cardSum := 0
		numbers := strings.Split(line, ": ")[1]
		splittedNumbers := strings.Split(numbers, " | ")
		winningNumbers := convStringToIntArray(removeEmptyEntries(strings.Split(splittedNumbers[0], " ")))
		myNumbers := convStringToIntArray(removeEmptyEntries(strings.Split(splittedNumbers[1], " ")))

		for _, winningNumber := range winningNumbers {
			for _, myNumber := range myNumbers {
				if winningNumber == myNumber {
					cardSum += 1
				}
			}
		}

		for i := lineIdx + 1; i < lineIdx+cardSum+1; i++ {
			totalCards[i] += totalCards[lineIdx]
		}
	}

	var sum int
	for _, c := range totalCards {
		sum += c
	}
	return sum
}

func removeEmptyEntries(array []string) []string {
	var r []string
	for _, str := range array {
		if str != "" {
			r = append(r, str)
		}
	}
	return r
}
func convStringToIntArray(stringArray []string) []int {
	intArray := make([]int, len(stringArray))
	for i, str := range stringArray {
		value, _ := strconv.Atoi(str)
		intArray[i] = value
	}
	return intArray
}
