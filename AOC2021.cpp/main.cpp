// AOC2021.cpp.cpp : Ce fichier contient la fonction 'main'. L'exécution du programme commence et se termine à cet endroit.
//

#include "Day1.h"
#include "Day2.h"
#include <iostream>

int main()
{
	std::cout << "December 1st (1):" << Day1::Resolve(1, "./data/day1.txt") << std::endl;
	std::cout << "December 1st (2):" << Day1::Resolve(2, "./data/day1.txt") << std::endl;

	std::cout << "December 2nd (1):" << Day2::Resolve(1, "./data/day2.txt") << std::endl;
	std::cout << "December 2nd (2):" << Day2::Resolve(2, "./data/day2.txt") << std::endl;
}