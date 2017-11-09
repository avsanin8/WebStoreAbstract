#include "Enemy.h"
#include "Level.h"
#include "Character.h"

#include <math.h>
#include <stdlib.h>

Enemy::Enemy(Level *lev, DrawEngine *de, int s_index, float x, float y, 
	int i_lives):Sprite(lev,de,s_index,x,y, i_lives)
{
	goal = 0;
	classID = ENEMY_CLASSID;
}


bool Enemy::Move(float x, float y)
{
	int xPos = (int)(pos.x + x);
	int yPos = (int)(pos.y + y);
	
	if (IsValidLevelMove(xPos, yPos))
	{
		//make sure we don't run into any other enemies
		list <Sprite *>::iterator Iter;
		
		for (Iter = level->npc.begin(); Iter != level->npc.end(); Iter++)
		{
			if ((*Iter) != this && (int)(*Iter)->GetX() == xPos && (int)(*Iter)->GetY() == yPos)
			{
				return false;
			}
		}

		//erase sprite
		Erase(pos.x, pos.y);

		pos.x += x;
		pos.y += y;

		facingDirection.x = x;
		facingDirection.y = y;

		//draw sprite
		Draw(pos.x, pos.y);

		if ((int)goal->GetX() == xPos && (int)goal->GetY() == yPos)
			goal->AddLives(-1);

		return true;
	}

	return false;
}

void Enemy::IdleUpdate()
{
	if (goal)
		SimulateAI();
}
void Enemy::AddGoal(Character *g)
{
	goal = g;
}

void Enemy::SimulateAI()
{
	vector goal_pos = goal->GetPosition();
	vector direction;

	direction.x = goal_pos.x - pos.x;
	direction.y = goal_pos.y - pos.y;

	float magnitude = sqrt(direction.x * direction.x + direction.y * direction.y);

	direction.x = direction.x / (magnitude * 5);
	direction.y = direction.y / (magnitude * 5);

	if (!Move(direction.x, direction.y))
	{
		while (!Move(float(rand() % 3-1), float(rand() % 3-1)))
		{
			// wherefore?
		}
	}
}