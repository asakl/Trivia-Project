#include "Question.h"



Question::Question() 
{
}

Question::Question(Question& other)
{
	this->m_possibleAnswers = other.m_possibleAnswers;
	this->m_question = other.m_question;
}

string Question::getQuestion()
{
	return this->m_question;
}

vector<string> Question::getPossibleAnswers()
{
	return this->m_possibleAnswers;
}

string Question::getCorrentAnswer()
{
	return this->m_possibleAnswers.front();
}



