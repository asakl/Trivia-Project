#pragma once
#include <iostream>
#include <string>

using std::string;

class LoggedUser
{
	string m_username;

public:
	LoggedUser(string name = "unknown");
	string getUsername();

	~LoggedUser();
};

