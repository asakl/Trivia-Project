#pragma once

#include <map>
#include "Room.h"

using std::map;

class RoomManager
{
public:
	RoomManager();
	unsigned int createRoom(RoomData,LoggedUser);
	bool deleteRoom(unsigned int);
	bool addUserToRoom(LoggedUser, unsigned int);
	unsigned int getRoomState(unsigned int);
	vector<RoomData> getRoomsData();
	Room* getRoom(unsigned int);


private:
	static map<unsigned int, Room> m_rooms;

	int nextID;
};