#pragma once
#include "DrawEngine.h"
#include <list>

using std::list;

enum
{
	SPRITE_PLAYER,
	SPRITE_ENEMY,
	SPRITE_FIREBALL
};

enum 
{
	TILE_EMPTY,
	TILE_WALL
};



class Sprite;
class Character; // ��������� ������, ������ ��� ��� �����

class Level
{
public:
	Level(DrawEngine *de, int width = 30, int height = 20);
	~Level();

	void AddPlayer(Character *p);
	void UpDate();
	void Draw();
	bool KeyPress(char c);

	void AddEnemies(int num);
	void AddNPC(Sprite *spr);
	 
	friend class Sprite;

	list <Sprite *> npc;
	list <Sprite *>::iterator Iter;

protected:
	void CreateLevel();

	

private:
	int width;
	int height;

	char **level; // ���������� ������ � Sprite friend class ;

	Character *player;
	DrawEngine *drawArea;
};