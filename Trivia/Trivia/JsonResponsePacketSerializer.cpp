#include "JsonResponsePacketSerializer.h"

/*
the func serializer error res to vec of byts
input: res
ouput: vec of byts
*/
vector<Byte> JsonResponsePacketSerializer::serializerResponse(ErrorResponse response)
{
	vector<Byte> buffer;
	string asString = "";
	json j;

	
	//adds the data to the json object.
	j[STATUS] = to_string(ERROR_RESPONSE_ID);
	j[MESSAGE] = response.message;

	buffer = Helper::toBytes(j.dump());
	
	return buffer;
}

/*
the func serializer login res to vec of byts
input: res
ouput: vec of byts
*/
vector<Byte> JsonResponsePacketSerializer::serializerResponse(LoginResponse response)
{
	
	vector<Byte> buffer;
	string asString = "";
	json j;

	//adds the data to the json object.
	j[STATUS] = to_string(ERROR_RESPONSE_ID);

	buffer = Helper::toBytes(j.dump());

	
	return buffer;
}

/*
the func serializer login res to vector of bytes
input: res
ouput: vector of bytes
*/
vector<Byte> JsonResponsePacketSerializer::serializerResponse(SignupResponse response)
{
	vector<Byte> buffer;
	string asString = "";
	json j;



	//adds the data to the json object.
	j[STATUS] = to_string(ERROR_RESPONSE_ID);

	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(LogoutResponse response)
{
	vector<Byte> buffer;
	string asString = "";
	json j;



	//adds the data to the json object.
	j[STATUS] = to_string(response.status);
	
	
	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(GetRoomsResponse response)
{
	vector<Byte> buffer;
	string roomsString = "";
	json j,jsonRooms;

	

	//adds the data to the json object.
	j[STATUS] = to_string(response.status);
	//adds the json of rooms to the json of the response
	j[ROOMS] = Helper::vectorToJson(response.rooms).dump();


	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(JoinRoomResponse response)
{
	vector<Byte> buffer;
	
	json j;

	j[STATUS] = to_string(response.status);

	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(CreateRoomResponse response)
{
	vector<Byte> buffer;
	json j;

	j[STATUS] = to_string(response.status);

	buffer = Helper::toBytes(j.dump());



	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(HighscoreResponse response)
{
	vector<Byte> buffer;
	json j;

	//adds the status code to the json
	j[STATUS] = to_string(response.status);
	//adds the highscores to the json
	j[HIGHSCORES] = Helper::vectorToJson(response.highscores).dump();

	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(GetPlayersInRoomResponse response)
{
	vector<Byte> buffer;
	json j;


	//adds the status code to the json
	j[STATUS] = to_string(response.status);
	//adds the players vector to the json
	j[PLAYERS] = Helper::vectorToJson(response.players).dump();

	buffer = Helper::toBytes(j.dump());


	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(CloseRoomResponse response)
{
	vector<Byte> buffer;
	json j;
	
	j[STATUS] = to_string(response.status);

	buffer = Helper::toBytes(j.dump());

	response.responseLength = buffer.size();

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(StartGameResponse response)
{
	vector<Byte> buffer;
	json j;

	j[STATUS] = to_string(response.status);

	buffer = Helper::toBytes(j.dump());


	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(GetRoomStateResponse response)
{
	vector<Byte> buffer;
	json j;



	j[STATUS] = to_string(response.status);
	j[ANSWER_TIMEOUT] = to_string(response.answerTimeout);
	j[HAS_GAME_BEGUN] = to_string(response.hasGameBegun);
	j[PLAYERS] = Helper::vectorToJson(response.players).dump();
	j[ANSWER_COUNT] = to_string(response.questionCount);

	buffer = Helper::toBytes(j.dump());

	return buffer;
}

vector<Byte> JsonResponsePacketSerializer::serializerResponse(LeaveRoomResponse response)
{
	vector<Byte> buffer;
	json j;

	j[STATUS] = to_string(response.status);

	buffer = Helper::toBytes(j.dump());

	return buffer;
}





