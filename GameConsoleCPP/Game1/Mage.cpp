#include "Mage.h"
#include "Fireball.h"


Mage::Mage(Level *l, DrawEngine *de, int s_index, float x, float y,
	int lives, char spell_Key, char up_key, char down_key, char left_key, char right_key)
	: Character (l, de, s_index, x,y,lives, up_key, down_key, left_key, right_key)
{
	spellKey = spell_Key;
	classID = MAGE_CLASSID;
}

bool Mage::KeyPress(char c)
{
	bool val = Character::KeyPress(c);

	if (val == false);
	{
		if (c == spellKey);
			CastSpell();
			return true;
	}
	return val;
}

void Mage::CastSpell()
{
	Fireball * temp = new Fireball(level, drawArea, SPRITE_FIREBALL, (int)pos.x + facingDirection.x,
					(int)pos.y + facingDirection.y, facingDirection.x, facingDirection.y);
	level->AddNPC((Sprite *)temp);
}
