#pragma once

#include "pch.h"
#include "json.hpp"
#include "Helper.h"
#include "ResponseStructures.h"

using nlohmann::json;

#define STATUS "status"
#define ROOMS "rooms"
#define PLAYERS "players"
#define HIGHSCORES "highscores"
#define ANSWER_TIMEOUT "answerTimeout"
#define HAS_GAME_BEGUN "hasGameBegun"
#define ANSWER_COUNT "answerCount"
#define MESSAGE "message"
static class JsonResponsePacketSerializer
{
public:
	static vector<Byte> serializerResponse(ErrorResponse);
	static vector<Byte> serializerResponse(LoginResponse);
	static vector<Byte> serializerResponse(SignupResponse);
	static vector<Byte> serializerResponse(LogoutResponse);
	static vector<Byte> serializerResponse(GetRoomsResponse);
	static vector<Byte> serializerResponse(JoinRoomResponse);
	static vector<Byte> serializerResponse(CreateRoomResponse);
	static vector<Byte> serializerResponse(HighscoreResponse);
	
	static vector<Byte> serializerResponse(GetPlayersInRoomResponse);
	static vector<Byte> serializerResponse(CloseRoomResponse);
	static vector<Byte> serializerResponse(StartGameResponse);
	static vector<Byte> serializerResponse(GetRoomStateResponse);
	static vector<Byte> serializerResponse(LeaveRoomResponse); 

};
