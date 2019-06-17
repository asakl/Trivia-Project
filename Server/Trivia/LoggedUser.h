#pragma once
#include <iostream>
#include <string>

using std::string;

class LoggedUser
{

public:
	LoggedUser();
	LoggedUser(string name);
	LoggedUser(const LoggedUser& other);
	string getUsername() const;
	

	bool operator==(LoggedUser other);

	~LoggedUser();
private:
	string m_username;

};

