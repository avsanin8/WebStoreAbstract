#pragma once
#include "DrawEngine.h"
#include "Level.h"

enum
{
	SPRITE_CLASSID,
	CHARACTER_CLASSID
};

struct vector
{
	float x;
	float y;
};

class Sprite
{
public:
	Sprite(Level *l, DrawEngine *de, int s_index, float x = 1, float y = 1, int i_lives = 1);
	~Sprite();

	vector GetPosition();
	float GetX();
	float GetY();

	virtual void AddLives(int num = 1);
	int GetLives();
	bool IsAlive();

	virtual bool Move(float x, float y);


protected:
	Level *level;

	DrawEngine *drawArea;
	vector pos;
	int spriteIndex;
	int numLives;

	int classID;
	vector facingDirection;

	void Draw(float x, float y);
	void Erase(float x, float y);

	bool IsValidLevelMove(int xPos, int yPos);

private:

};




