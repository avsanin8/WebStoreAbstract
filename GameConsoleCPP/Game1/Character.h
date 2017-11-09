#pragma once
#include "Sprite.h"
class Character : public Sprite
{
public:
	Character(Level *l, DrawEngine *de, int s_index, float x = 1, float y = 1,
		int lives = 3, char up_key = 'w', char down_key = 's', char left_key = 'a', char right_key = 'd');
	
	virtual bool KeyPress(char c);

	virtual void AddLives(int num = 1);

protected:
	char upKey;
	char downKey;
	char leftKey;
	char rightKey;
};