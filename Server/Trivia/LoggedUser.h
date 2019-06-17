#pragma once
#include <iostream>
#include <string>

using std::string;

class LoggedUser
{

public:
	LoggedUser();
	LoggedUser(string name);
	string getUsername();
	

	bool operator==(LoggedUser other);

	~LoggedUser();
private:
	string m_username;

};

