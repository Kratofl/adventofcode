package day2

import (
	"strconv"
	"strings"

	"github.com/kratofl/adventofcode/2024/filereader"
)

func PartOne() int {
	lines, _ := filereader.ReadFile("day2/input.csv")

	var safeCount int
	for _, line := range lines {
		nums := convertToIntArr(strings.Split(line, " "))
		if isSafe(nums) {
			safeCount += 1
		}
	}
	return safeCount
}

func PartTwo() int {
	lines, _ := filereader.ReadFile("day2/input.csv")

	var safeCount int
	for _, line := range lines {
		nums := convertToIntArr(strings.Split(line, " "))

		for i := 0; i <= len(nums); i++ {
			removeLevel := i > 0

			removedLevelNums := make([]int, len(nums))
			copy(removedLevelNums, nums)
			if removeLevel {
				removedLevelNums = remove(removedLevelNums, i-1)
			}
			if isSafe(removedLevelNums) {
				safeCount += 1
				break
			}
		}
	}
	return safeCount
}
func remove(s []int, i int) []int {
	return append(s[:i], s[i+1:]...)
}

func isSafe(nums []int) bool {
	safe := true
	increase := nums[0] < nums[1]
	for i, num := range nums {
		if i == len(nums)-1 {
			break
		}

		nextNum := nums[i+1]
		if (increase && num > nextNum) ||
			(!increase && num < nextNum) ||
			num == nextNum {
			safe = false
			break
		}

		diff := num - nextNum
		if !(diff != 0 && diff >= -3 && diff <= 3) {
			safe = false
		}
	}

	return safe
}

func convertToIntArr(t []string) []int {
	var t2 []int
	for _, i := range t {
		j, err := strconv.Atoi(i)
		if err != nil {
			panic(err)
		}
		t2 = append(t2, j)
	}
	return t2
}
