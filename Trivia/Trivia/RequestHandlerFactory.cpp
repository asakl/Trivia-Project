#include "RequestHandlerFactory.h"

/*
i dont think comments are necessary
*/

//C'tors
RequestHandlerFactory::RequestHandlerFactory()
{
	this->m_loginManager = nullptr;
}
RequestHandlerFactory::RequestHandlerFactory(IDatabase* db)
{
	this->m_loginManager = new LoginManager(*db);
	this->m_roomManager = new RoomManager();
}

//D'tor
RequestHandlerFactory::~RequestHandlerFactory()
{
	delete(this->m_loginManager);
}

//create Login Request Handler
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(this->m_loginManager);
}

//Creates a MenuRequestHandler
MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler()
{
	return new MenuRequestHandler(*this->m_roomManager);
}
