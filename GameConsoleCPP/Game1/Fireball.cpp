#include "Fireball.h"

Fireball::Fireball(Level *lev, DrawEngine *de, int s_index, float x, float y,
	float xDir, float yDir, int i_lives) : Sprite
		(lev, de, s_index, x, y, i_lives)
{
	facingDirection.x = xDir;
	facingDirection.y = yDir;

	classID = FIREBALL_CLASSID;
}

void Fireball::IdleUpdate()
{
	if (Sprite::Move(facingDirection.x, facingDirection.y))
	{
		list <Sprite *>::iterator Iter;

		for (Iter = level->npc.begin(); Iter != level->npc.end(); Iter++)
		{
			if ((*Iter)->classID != classID && (int)(*Iter)->GetX() == (int)pos.x && (int)(*Iter)->GetY() == (int)pos.y)
			{
				(*Iter)->AddLives(-1);
				AddLives(-1);
			}
		}
	}
	else
	{
		AddLives(-1);
	}
}