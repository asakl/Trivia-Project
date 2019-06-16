#include "pch.h"
#include "Server.h"
#include "SqliteDatabase.h"
#include "WSAInitializer.h"

int main()
{
	//init sock
	WSAInitializer wsa;

	try
	{
		//start the server
		SqliteDatabase * db = new SqliteDatabase();
		Server server((IDatabase*)db);
		server.run();
	}
	catch (...)
	{
		exit(1);
	}

	return 0;
}

int main2()
{
	RoomManager rm;
	LoggedUser admin("admin"), player1("p1");
	RoomData metadata;

	metadata.isActive = false;
	metadata.maxPlayers = 5;
	metadata.name = "Test";
	metadata.timePerQuestion = 20;


	metadata.id = rm.createRoom(metadata, admin);
	rm.addUserToRoom(player1,metadata.id);

	auto at = rm.getRoom(metadata.id).getAllUsers();
	vector<string> usernames;

	for (auto it = at.begin(); it != at.end(); it++)
	{
		usernames.push_back((*it).getUsername());
	}

	for (auto it = usernames.begin(); it != usernames.end(); it++)
	{
		cout << (*it) << endl;
	}

	system("pause");

	return 0;
}
