#pragma once
#include "LoggedUser.h"
#include "Question.h"
#include "pch.h"

class IDatabase
{
public:
	virtual bool open() = 0;
	virtual void close() = 0;

	virtual void signup(string, string, string) = 0;
	virtual LoggedUser* login(string, string) = 0;
	virtual void logout(string, string) = 0;

	virtual map<LoggedUser, int> getHighscores() = 0;
	virtual bool doesUserExiste(const string) = 0;
	virtual list<Question> getQuestions(const int) = 0;
private:

};
