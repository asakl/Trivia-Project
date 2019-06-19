#pragma once
#include "Question.h"
#include "pch.h"
#include "LoggedUser.h"

typedef struct GameData
{
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
}GameData;

class Game
{
public:
	
private:
	vector<Question> m_questions;
	map<LoggedUser, GameData> m_players;

};

