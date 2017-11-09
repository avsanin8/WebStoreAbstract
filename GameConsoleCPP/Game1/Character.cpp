#include "Character.h"

Character::Character(Level *lev, DrawEngine *de, int s_index, float x, float y,
	int lives, char u, char d, char l, char r)
	: Sprite (lev, de, s_index, x, y, lives) // сложный конструктор
{
	upKey = u;
	downKey = d;
	leftKey = l;
	rightKey = r;


	classID = CHARACTER_CLASSID; // 
}

bool Character::KeyPress(char c)
{
	if (c == upKey)
	{
		return Move(0, -1);
	}
	else if (c == downKey)
	{
		return Move(0, 1);
	}
	else if (c == leftKey)
	{
		return Move(-1, 0);
	}
	else if (c == rightKey)
	{
		return Move(1, 0);
	}

	return false;
}

void Character::AddLives(int num)
{
	Sprite::AddLives(num);
	
	if (Sprite::IsAlive())
	{
		pos.x = 1;
		pos.y = 1;
		Move(0, 0);
	}
}
