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

	
	this->globalLoginRquestHandler = new LoginRequestHandler(this->m_loginManager);
}

//D'tor
RequestHandlerFactory::~RequestHandlerFactory()
{
	delete(this->m_loginManager);
}

//create Login Request Handler
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return this->globalLoginRquestHandler;
}

//Create a MenuRequestHandler
MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler()
{
	return new MenuRequestHandler(this->m_roomManager);
}

RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(Request req)
{
	unsigned int roomId = -1;

	if (req.id == CLOSE_ROOM_REQUEST)
		roomId = JsonRequestPacketDeserializer::deserializeCloseRoomRequest(req.buffer).roomId;
	else if (req.id == START_GAME_REQUEST)
		roomId = JsonRequestPacketDeserializer::deserializeStartGameRequest(req.buffer).roomId;

	return new RoomAdminRequestHandler(*this->m_roomManager->getRoom(roomId),this->m_roomManager);
}
