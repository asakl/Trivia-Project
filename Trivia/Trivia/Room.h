#pragma once


#include "RoomData.h"
#include "LoggedUser.h"
#include <vector>

using std::vector;



class Room
{
public:
	Room() {};
	Room(RoomData metadata);
	bool addUser(const LoggedUser);
	void removeUser(const string username);
	const RoomData getRoomData() const;
	vector<LoggedUser> getAllUsers() const;

private:
	RoomData m_metadata;
	vector<LoggedUser> m_users;

};

