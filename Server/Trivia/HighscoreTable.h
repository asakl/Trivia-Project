#pragma once

#include "IDatabase.h"
#include <string>
#include <vector>

using std::string;
using std::vector;


class HighscoreTable
{
public:
	HighscoreTable();
	HighscoreTable(IDatabase* db);
	
	vector<string> getHighscores() { return vector<string>(); };

	~HighscoreTable();
	
	

private:
	IDatabase *db;
};

