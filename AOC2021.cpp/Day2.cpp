#include "Day2.h"
#include <map>
#include <vector>
#include <string>
#include <fstream>
#include <sstream>
#include <iostream>

struct kvpair
{
	std::string key;
	int value;
};

int day2_1(std::vector<struct kvpair> _data);
int day2_2(std::vector<struct kvpair> _data);

int Day2::Resolve(int _part, std::string _filename)
{
	std::vector<struct kvpair> data;
	{
		std::ifstream file(_filename);
		std::stringstream stringstreamBuffer;
		std::string stringBuffer;
		size_t pos;

		stringstreamBuffer << file.rdbuf();
		stringBuffer = stringstreamBuffer.str();

		while ((pos = stringBuffer.find('\n')) != std::string::npos)
		{
			data.push_back({
				stringBuffer.substr(0, stringBuffer.find(' ')),
				std::stoi(stringBuffer.substr(stringBuffer.find(' '), pos))
				});
			stringBuffer.erase(0, pos + 1);
		}
	}

	switch (_part)
	{
	case 1:
		return day2_1(data);
	case 2:
		return day2_2(data);
	default:
		return -1;
	}
}

int day2_1(std::vector<struct kvpair> _data)
{
	int depth = 0;
	int horizontalPosition = 0;
	for (size_t i = 0; i < _data.size(); i++)
	{
		if (_data[i].key._Equal("forward"))
		{
			horizontalPosition += _data[i].value;
		}
		else if (_data[i].key._Equal("up"))
		{
			depth -= _data[i].value;
		}
		else if (_data[i].key._Equal("down"))
		{
			depth += _data[i].value;
		}
	}
	return depth * horizontalPosition;
}

int day2_2(std::vector<struct kvpair> _data)
{
	int depth = 0;
	int horizontalPosition = 0;
	int aim = 0;
	for (size_t i = 0; i < _data.size(); i++)
	{
		if (_data[i].key._Equal("forward"))
		{
			horizontalPosition += _data[i].value;
			depth += aim * _data[i].value;
		}
		else if (_data[i].key._Equal("up"))
		{
			aim -= _data[i].value;
		}
		else if (_data[i].key._Equal("down"))
		{
			aim += _data[i].value;
		}
	}
	return depth * horizontalPosition;
}
