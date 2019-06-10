#include "LoggedUser.h"

/*
i dont think comments are necessary
*/

//C'tor
LoggedUser::LoggedUser(string name)
{
	this->m_username = name;
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
