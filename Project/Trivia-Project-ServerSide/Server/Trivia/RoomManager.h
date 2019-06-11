#pragma once

#include <map>
#include "Room.h"

using std::map;

class RoomManager
{
public:
	unsigned int createRoom(RoomData,LoggedUser);
	void deleteRoom(unsigned int);
	bool addUserToRoom(LoggedUser, unsigned int);
	unsigned int getRoomState(unsigned int);
	vector<RoomData> getRoomsData();
	const Room getRoom(unsigned int);


private:
	map<unsigned int, Room> m_rooms;

	int nextID;
};