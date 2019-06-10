#pragma once

#include "pch.h"
#include "Question.h"
#include "RoomManager.h"
#include "LoginManager.h"
#include "HighscoreTable.h"
#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"


class LoginRequestHandler;
class MenuRequestHandler;


class RequestHandlerFactory
{
public:
	RequestHandlerFactory();
	RequestHandlerFactory(IDatabase* db);
	~RequestHandlerFactory();
	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler();
private:
	LoginManager* m_loginManager;

	RoomManager* m_roomManager;
	HighscoreTable m_highscoreTable;
};

