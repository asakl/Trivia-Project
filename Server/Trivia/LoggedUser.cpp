#include "LoggedUser.h"

/*
i dont think comments are necessary
*/

LoggedUser::LoggedUser()
{
	this->m_username = "unknown";
}

//C'tor
LoggedUser::LoggedUser(string name)
{
	this->m_username = name;
}

bool LoggedUser::operator==(LoggedUser other)
{
	return this->m_username == other.m_username;
}

//D'tor
LoggedUser::~LoggedUser()
{
	this->m_username.clear();
}

//getter
string LoggedUser::getUsername()
{
	return this->m_username;
}
