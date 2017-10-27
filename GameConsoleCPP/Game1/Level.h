#pragma once
#include "DrawEngine.h"


enum 
{
	TILE_EMPTY,
	TILE_WALL
};


//#include "Character.h"
class Character; // непонятно почему, если уже есть класс

class Level
{
public:
	Level(DrawEngine *de, int width = 30, int height = 20);
	~Level();

	void AddPlayer(Character *p);
	void UpDate();
	void Draw();
	bool KeyPress(char c);

	friend class Sprite;


protected:
	void CreateLevel();

	

private:
	int width;
	int height;

	char **level; // private or protected or public?

	Character *player;
	DrawEngine *drawArea;
};