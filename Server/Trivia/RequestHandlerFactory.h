#pragma once

#include "pch.h"
#include "Question.h"
#include "RoomManager.h"
#include "LoginManager.h"
#include "HighscoreTable.h"
#include "MenuRequestHandler.h"
#include "LoginRequestHandler.h"
#include "RoomAdminRequestHandler.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RoomAdminRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory();
	RequestHandlerFactory(IDatabase* db);
	~RequestHandlerFactory();

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler();
	RoomAdminRequestHandler* createRoomAdminRequestHandler(Request r);
	HighscoreTable* createHighScoreHendler();

private:
	LoginManager* m_loginManager;
	LoginRequestHandler* globalLoginRquestHandler;
	RoomManager* m_roomManager;
	HighscoreTable m_highscoreTable;
};

