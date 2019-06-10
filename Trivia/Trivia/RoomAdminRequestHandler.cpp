#include "RoomAdminRequestHandler.h"



RoomAdminRequestHandler::RoomAdminRequestHandler(Room& room,RoomManager* rm)
{
	this->m_room = room;
	this->m_roomManager = rm;
}

bool RoomAdminRequestHandler::isRequestRelevant(Request req)
{
	return CLOSE_ROOM_REQUEST == req.id || START_GAME_REQUEST == req.id || GET_ROOM_STATE_REQUEST == req.id || LEAVE_ROOM_REQUEST == req.id;
}

RequestResult RoomAdminRequestHandler::closeRoom(Request r)
{
	RequestResult result;
	CloseRoomResponse resp = { 0,0 };
	
	resp.status = TRIVIA_OK;

	//Delete the room from the map of rooms.
	try
	{
		this->m_roomManager->deleteRoom(this->m_room.getRoomData().id);
	}
	catch (...)
	{
		
		//deleteRoom will throw exception if the room doesnt exist, and the requet is invalid.
		resp.status = ERROR_RESPONSE_ID;
	}
	
	//Serialize the respone to bytes.	
	result.response = JsonResponsePacketSerializer::serializerResponse(resp);
	//Adds the response status and the response length to msg.
	result.msg += to_string(resp.status) + to_string(resp.responseLength);

	return result;
}
