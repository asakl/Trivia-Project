#pragma once


#include <string>

using std::string;

typedef struct RoomData
{
	unsigned int id;
	string name;
	string maxPlayers;
	unsigned int timePerQuestion;
	unsigned int isActive;

} RoomData;
