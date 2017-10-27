#include "Sprite.h"

Sprite::Sprite(Level *l, DrawEngine *de, int s_index, float x, float y, int i_lives)
{
	drawArea = de;

	pos.x = x;
	pos.y = y;

	spriteIndex = s_index;

	numLives = i_lives;

	facingDirection.x = 1;
	facingDirection.y = 0;
	
	classID = SPRITE_CLASSID; // что это и зачем?

	level = l;
}

Sprite::~Sprite()
{
	// eraase the dying sprite
	Erase(pos.x, pos.y);
}

vector Sprite::GetPosition()
{
	return pos;
}

float Sprite::GetX()
{
	return pos.x;
}

float Sprite::GetY()
{
	return pos.y;
}

void Sprite::AddLives(int num)
{
	numLives += num;
}

int Sprite::GetLives()
{
	return numLives;
}

bool Sprite::IsAlive()
{
	return (numLives > 0);
}

bool Sprite::Move(float x, float y) // почему не void?
{
	int xPos = (int)(pos.x + x);
	int yPos = (int)(pos.y + y);

	if (IsValidLevelMove(xPos, yPos))
	{
		//erase sprite
		Erase(pos.x, pos.y);

		pos.x += x;
		pos.y += y;

		facingDirection.x = x;
		facingDirection.y = y;

		//draw sprite
		Draw(pos.x, pos.y);
		return true;
	}

	return false;
}


void Sprite::Draw(float x, float y)
{
	drawArea->DrawSprite(spriteIndex, (int)x, (int)y);
}

void Sprite::Erase(float x, float y)
{
	drawArea->EraseSprite((int)x, (int)y);
}

bool Sprite::IsValidLevelMove(int xPos, int yPos)
{
	if (level->level[xPos][yPos] != TILE_WALL)
		return true;

	return false;
}

