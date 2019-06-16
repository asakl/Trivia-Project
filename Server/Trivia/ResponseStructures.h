#pragma once

#include "pch.h"
#include "RoomData.h"


struct LoginResponse
{
	unsigned int status;
	unsigned int responseLength;
};

struct SignupResponse
{
	unsigned int status;
	unsigned int responseLength;
};

struct ErrorResponse
{
	string message;
	unsigned int responseLength;
};


typedef struct LogoutResponse
{
	unsigned int status;
}LogoutResponse;


typedef struct GetRoomsResponse
{
	unsigned int status;
	vector<RoomData> rooms;
	unsigned int responseLength;
}GetRoomsResponse;

typedef struct GetPlayersInRoomResponse
{
	unsigned int status;
	vector<string> players;
	unsigned int responseLength;
}GetPlayersInRoomResponse;



typedef struct HighscoreResponse
{
	unsigned int status;
	vector<string> highscores;
	unsigned int responseLength;
}HighscoreResponse;


typedef struct JoinRoomResponse
{
	unsigned int status;
	unsigned int responseLength;
}JoinRoomResponse;


typedef struct CreateRoomResponse
{
	unsigned int status;
	unsigned int id;
}CreateRoomResponse;



typedef struct CloseRoomResponse
{
	unsigned int status;
	unsigned int responseLength;
}CloseRoomResponse;


typedef struct StartGameResponse
{
	unsigned int status;
	unsigned int responseLength;
}StartGameResponse;


typedef struct GetRoomStateResponse
{
	unsigned int status;

	bool hasGameBegun;
	vector<string> players;
	unsigned int questionCount;
	unsigned int answerTimeout;
	
	unsigned int responseLength;


}GetRoomStateResponse;

typedef struct LeaveRoomResponse
{
	unsigned int status;
	unsigned int responseLength;
}LeaveRoomResponse;



