#pragma once

#include "pch.h"

class Question
{
public:
	Question();
	Question(Question&);
	
	int question_id;
	std::string question;
	std::string correct_ans;
	std::string ans2;
	std::string ans3;
	std::string ans4;
};

