#pragma once

#include "pch.h"

class Question
{
	string m_question;
	vector<string> m_possibleAnswers;

public:
	Question();
	Question(Question&);
	
	string getQuestion();
	vector<string> getPossibleAnswers();
	string getCorrentAnswer();

};

