#pragma once
#include <iostream>
#include <string>

using std::string;

class LoggedUser
{

public:
	LoggedUser(string name = "unknown");
	string getUsername();
	

	bool operator==(LoggedUser other);

	~LoggedUser();
private:
	string m_username;

};

