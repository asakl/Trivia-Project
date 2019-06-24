#include "Game.h"

void Game::removeUser(string username)
{
	LoggedUser toFind(username);

	auto it = this->m_players.find(toFind);

	if (it != this->m_players.end())
	{
		this->m_players.erase(it);
	}
}
