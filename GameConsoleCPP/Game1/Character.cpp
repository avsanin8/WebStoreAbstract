#include "Character.h"

Character::Character(Level *lev, DrawEngine *de, int s_index, float x, float y,
	int lives, char u, char d, char l, char r)
	: Sprite (lev, de, s_index, x, y, lives) // ������� �����������
{
	upKey = u;
	downKey = d;
	leftKey = l;
	rightKey = r;


	classID = CHARACTER_CLASSID; // ����� enum
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