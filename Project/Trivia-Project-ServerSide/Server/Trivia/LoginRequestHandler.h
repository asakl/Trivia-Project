#pragma once
#include "IRequestHandler.h"
#include "LoginManager.h"
#include "RequestHandlerFactory.h"
#include "RequestStructures.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "SqliteDatabase.h"
#include "ResponseStructures.h"
#include "pch.h"


class RequestHandlerFactory;

class LoginRequestHandler : public IRequestHandler
{
public:
	LoginRequestHandler() {};
	~LoginRequestHandler() {};
	LoginRequestHandler(IDatabase& db);
	LoginRequestHandler(LoginManager* man);

	bool isRequestRelevant(Request);
	RequestResult handleRequest(Request);

private:
	LoginManager *m_loginManager;
	
	RequestResult login(Request);
	RequestResult signup(Request);
};
