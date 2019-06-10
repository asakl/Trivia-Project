#pragma once
#include "LoggedUser.h"
#include "IDatabase.h"
#include "pch.h"

class LoginManager
{

public:
	LoginManager();
	LoginManager(IDatabase& db);
	~LoginManager();

	void signup(string name, string pass, string email);
	void login(string username, string password);
	void logout();
	bool doesUserExiste(string user);

private:
	IDatabase * m_database;
	vector<LoggedUser> m_loggedUsers;

	void setDatabase(IDatabase* db);


};

