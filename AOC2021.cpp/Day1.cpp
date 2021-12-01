#include "Day1.h"
#include <fstream>
#include <sstream>
#include <vector>
#include <iostream>
#include <numeric>

int Day1_1(std::vector<int> _dayData);
int Day1_2(std::vector<int> _dayData);

int Day1::Resolve(int _part, std::string _filename)
{
	std::vector<int> data;
	{
		std::ifstream file(_filename);
		std::stringstream stringstreamBuffer;
		std::string numberString;
		std::string stringBuffer;
		size_t pos;

		stringstreamBuffer << file.rdbuf();
		stringBuffer = stringstreamBuffer.str();

		while ((pos = stringBuffer.find('\n')) != std::string::npos)
		{
			data.push_back(std::stoi(stringBuffer.substr(0, pos)));
			stringBuffer.erase(0, pos + 1);
		}
		data.push_back(std::stoi(stringBuffer));
	}

	//std::stoi(buffer.str());

	switch (_part)
	{
	case 1:
		return Day1_1(data);
	case 2:
		return Day1_2(data);
	default:
		return -1;
	}
}

int Day1_1(std::vector<int> _dayData)
{
	int result = 0;
	int previous = _dayData[0];
	for (int current : _dayData)
	{
		if (current > previous)
		{
			result++;
		}
		previous = current;
	}
	return result;
}

int Day1_2(std::vector<int> _dayData)
{
	int result = 0;
	int previous = std::accumulate(_dayData.begin(), _dayData.begin() + 3, 0);
	for (int i = 0; i < _dayData.size(); i++)
	{
		int actual = i + 3 > _dayData.size() ? 0 : std::accumulate(_dayData.begin() + i, _dayData.begin() + i + 3, 0);
		if (actual > previous)
		{
			result++;
		}
		previous = actual;
	}
	return result;
}