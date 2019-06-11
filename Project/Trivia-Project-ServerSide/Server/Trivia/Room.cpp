#include "Room.h"


//Constructor
Room::Room(RoomData metadata)
{
	this->m_metadata = metadata;
}


/*
	add a user the the users list
*/
bool Room::addUser(const LoggedUser user)
{
	//Adds the user, only if there is place left.
	if (atoi(this->m_metadata.maxPlayers.c_str()) > (unsigned int)this->m_users.size())
	{
		this->m_users.push_back(user);
		return true; //Succeeded to add the user.
	}
	
	//Failed to add the  user.
	return false;
}

void Room::removeUser(const string username)
{
	//go over the vector with iterator.
	for (auto it = this->m_users.begin(); it != this->m_users.end(); it++)
	{
		//if username was found, delete it and exit the function.
		if (it->getUsername() == username)
		{
			this->m_users.erase(it);
			return;
		}
	}

}

const RoomData Room::getRoomData() const
{
	return this->m_metadata;
}

vector<LoggedUser> Room::getAllUsers() const 
{
	return this->m_users;
}
