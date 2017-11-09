#pragma once
#include "Character.h"

class Mage : public Character
{
public:
	Mage(Level *l, DrawEngine *de, int s_index, float x = 1, float y = 1,
		int lives = 3, char spellKey = ' ', char up_key = 'w', char down_key = 's', char left_key = 'a', char right_key = 'd');

	bool KeyPress(char c);

protected:
	void CastSpell();

private:
	char spellKey;
};