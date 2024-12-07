package day5

import (
	"regexp"
	"strconv"
	"strings"
)

func PartOne(input *[]string) int {
	var sum int
	var seeds []int
	//var locations []int
	//firstMap := false
	for lineIdx, line := range *input {
		r := regexp.MustCompile(`\d+`)
		numbers := convStringToIntArray(r.FindAllString(line, -1))
		if lineIdx == 0 {
			seeds = append(seeds, numbers...)
			continue
		}

		if line == "" {
			continue
		}

		if strings.HasPrefix(line, "seed") {
			//firstMap = true
			continue
		}
		if len(numbers) == 0 {
			//firstMap = false
			continue
		}

		seedRanges := getSeedRanges(numbers)
		for i := 0; i < len(seedRanges); i++ {
			for j := 0; j < len(seedRanges[i]); j++ {
				for _, number := range numbers {
					if seedRanges[i] == number {

					}
				}
			}
		}
	}

	return sum
}

func PartTwo(input *[]string) int {
	var sum int

	return sum
}

func getSeedRanges(numbers []int) map[int]int {
	var seedRanges = make(map[int]int)
	for numberIdx := 0; numberIdx < len(numbers)-1; numberIdx++ {
		number := numbers[numberIdx]
		numbersRange := numbers[len(numbers)-1]

		for i := number; i < number+numbersRange; i++ {
			if len(seedRanges) < numbersRange {
				seedRanges[i] = 0
			}
		}
	}
	return seedRanges
}
func convStringToIntArray(stringArray []string) []int {
	intArray := make([]int, len(stringArray))
	for i, str := range stringArray {
		value, _ := strconv.Atoi(str)
		intArray[i] = value
	}
	return intArray
}
