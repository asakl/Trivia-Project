#pragma once
#pragma comment(lib, "Ws2_32.lib")

#include "pch.h"
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "IdataBase.h"
#include "Helper.h"

#include <WinSock2.h>
#include <Windows.h>
#include <thread>

using std::thread;



class Communicator
{


public:
	Communicator();
	Communicator(IDatabase* db);
	~Communicator();

	void bindAndListen();
	void handleRequests(SOCKET client_socket);

	
	

private:
	map<SOCKET, IRequestHandler*> m_clients;
	RequestHandlerFactory* m_handlerFactory;
	SOCKET serverSocket;
	IDatabase* db;

	void startThreadForNewClient();

	IRequestHandler* sortRequest(Request r);

};

