#include "LoginManager.h"

/*
i dont think comments are necessary
*/

//setter
void LoginManager::setDatabase(IDatabase * db)
{
	this->m_database = db;
}

//C'tors
LoginManager::LoginManager()
{
	this->m_database = nullptr;
}
LoginManager::LoginManager(IDatabase & db)
{
	this->m_database = &db;
}

//D'tor
LoginManager::~LoginManager()
{
	this->m_loggedUsers.clear();
}

//signup
void LoginManager::signup(string name, string pass, string email)
{
	this->m_database->signup(name, pass, email);
	this->login(name, pass);
}

//login
void LoginManager::login(string name, string pass)
{
	LoggedUser * user = this->m_database->login(name, pass);
	if (user == nullptr)
	{
		throw exception("error! username or password is incorrect");
	}
	this->m_loggedUsers.push_back(*user);
}

//logout
void LoginManager::logout()
{
	// TODO
}

//check if user exist
bool LoginManager::doesUserExiste(string user)
{
	return this->m_database->doesUserExiste(user);
}
