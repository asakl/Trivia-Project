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
	SqliteDatabase* db = new SqliteDatabase();


	LoginManager* lm = new LoginManager(*(IDatabase*)db);
	LoggedUser t("asa");

	lm->login("asa", "asa1");
	lm->logout(t);


	return 0;
}
