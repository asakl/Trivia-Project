#include "Question.h"



Question::Question() 
{
}

Question::Question(Question& other)
{
	this->question_id = other.question_id;
	this->question = other.question;
	this->correct_ans = other.correct_ans;
	this->ans2 = other.ans2;
	this->ans3 = other.ans3;
	this->ans4 = other.ans4;
}



