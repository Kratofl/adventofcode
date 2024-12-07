package day3

import (
	"regexp"
	"strconv"

	"github.com/kratofl/adventofcode/2024/filereader"
)

func PartOne() int {
	lines, _ := filereader.ReadFile("day3/input.csv")

	var result int
	for _, line := range lines {
		r := regexp.MustCompile(`mul\(\d+,\d+\)`)

		cmds := r.FindAllString(line, -1)
		for _, cmd := range cmds {
			nums := extractNumbers(cmd)
			result += nums[0] * nums[1]
		}
	}

	return result
}

func PartTwo() int {
	lines, _ := filereader.ReadFile("day3/input.csv")

	var result int
	enabled := true
	for _, line := range lines {
		r := regexp.MustCompile(`mul\(\d+,\d+\)|don't|do`)

		cmds := r.FindAllString(line, -1)
		for _, cmd := range cmds {
			if cmd == "" {
				continue
			}

			if cmd == "don't" {
				enabled = false
				continue
			} else if cmd == "do" {
				enabled = true
				continue
			}

			if enabled {
				nums := extractNumbers(cmd)
				result += nums[0] * nums[1]
			}
		}
	}

	return result
}

func extractNumbers(s string) []int {
	pattern := regexp.MustCompile(`\d+`)
	numberStrings := pattern.FindAllString(s, -1)
	numbers := make([]int, len(numberStrings))
	for i, numberString := range numberStrings {
		number, err := strconv.Atoi(numberString)
		if err != nil {
			panic(err)
		}
		numbers[i] = number
	}
	return numbers
}
