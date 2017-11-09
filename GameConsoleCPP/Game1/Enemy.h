#pragma once

#include "Sprite.h"

class Enemy : public Sprite
{
public :
	Enemy(Level *lev, DrawEngine *de, int s_index, float x = 1, float y = 1, int i_lives = 1);

	void AddGoal(Character *g);
	bool Move(float x, float y);
	void IdleUpdate();

protected:
	void SimulateAI();
	Character *goal;
};
