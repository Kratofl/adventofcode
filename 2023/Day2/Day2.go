package day2

import (
	"strconv"
	"strings"
)

func PartOne(input *[]string) int {
	maxRedCubes := 12
	maxGreenCubes := 13
	maxBlueCubes := 14
	var sum int

game:
	for _, line := range *input {
		gameSetsSeperated := strings.Split(line, ": ")
		game := gameSetsSeperated[0]
		gameId, _ := strconv.Atoi(strings.Split(game, " ")[1])

		sets := strings.Split(gameSetsSeperated[1], "; ")
		for _, set := range sets {
			trimedSet := strings.TrimSpace(set)
			cubes := strings.Split(trimedSet, ", ")

			for _, cube := range cubes {
				cubeInfo := strings.Split(cube, " ")
				amount, _ := strconv.Atoi(cubeInfo[0])
				color := cubeInfo[1]

				if (color == RED && amount > maxRedCubes) ||
					(color == GREEN && amount > maxGreenCubes) ||
					(color == BLUE && amount > maxBlueCubes) {
					continue game
				}
			}
		}
		sum += gameId
	}
	return sum
}

func PartTwo(input *[]string) int {
	var sum int

	for _, line := range *input {
		gameSetsSeperated := strings.Split(line, ": ")

		var minRed, minGreen, minBlue int

		sets := strings.Split(gameSetsSeperated[1], "; ")
		for _, set := range sets {
			trimedSet := strings.TrimSpace(set)
			cubes := strings.Split(trimedSet, ", ")

			for _, cube := range cubes {
				cubeInfo := strings.Split(cube, " ")
				amount, _ := strconv.Atoi(cubeInfo[0])
				color := cubeInfo[1]

				if color == RED && amount > minRed {
					minRed = amount
					continue
				}
				if color == GREEN && amount > minGreen {
					minGreen = amount
					continue
				}
				if color == BLUE && amount > minBlue {
					minBlue = amount
					continue
				}
			}
		}
		sum += minRed * minBlue * minGreen
	}

	return sum
}

const (
	RED   = "red"
	GREEN = "green"
	BLUE  = "blue"
)
