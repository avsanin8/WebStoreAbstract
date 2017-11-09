#include "Level.h"
#include "Character.h"
#include "Enemy.h"
#include <stdlib.h>

Level::Level(DrawEngine *de, int w, int h)
{
	drawArea = de;

	width = w;
	height = h;

	player = 0;

	//create memory for our level
	level = new char *[width];

	for (int x = 0; x < width; x++)
		level[x] = new char[height];
	
	//create the level
	CreateLevel();

	drawArea->SetMap(level);
}

Level::~Level()
{
	for (int x = 0; x < width; x++)
		delete[] level[x];

	delete[] level;
}

void Level::CreateLevel()
{
	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			int random = rand() % 100;

			if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
			{
				level[x][y] = TILE_WALL;
			}
			else
			{
				if (random < 90 || (x < 3 && y < 3 ))
					level[x][y] = TILE_EMPTY;
				else
					level[x][y] = TILE_WALL;
			}
		}
	}
}

void Level::Draw()
{
	drawArea->DrawBackground();
}

void Level::AddPlayer(Character *p)
{
	player = p;
}

bool Level::KeyPress(char c)
{
	if (player)
		if (player->KeyPress(c))
			return true;

	return false;
}

void Level::UpDate()
{
	//simulate AI
	for (Iter = npc.begin(); Iter != npc.end(); Iter++)
	{
		delete (*Iter); //ERROR Expression: _CrtlsValidHeapPointer(blok)
						//Expression: is_block_type_valid(header->_block_use)
						//Source information is missing from the debug information for this module

		//(*iter)->IdleUpdate();

		//if ((*iter)->IsAlive() == false)
		//{
		//	Sprite *temp = *iter;
		//	
		//	iter--;
		//	
		//	npc.remove(temp);
		//	delete temp;
		//}
	}
}

void Level::AddEnemies(int num)
{
	int i = num;

	while (i>0)
	{
		int xPos = int((float(rand() % 100) / 100) * (width - 2) + 1);
		int yPos = int((float(rand() % 100) / 100) * (height - 2) + 1);

		if (level[xPos][yPos] != TILE_WALL)
		{
			Enemy *temp = new Enemy(this, drawArea, SPRITE_ENEMY, (float)xPos, (float)yPos);
			
			temp->AddGoal(player);

			AddNPC((Sprite *)temp); // Непонятное приведение к Sprite
			i--;
		}
	}
}

void Level::AddNPC(Sprite *spr)
{
	npc.push_back(spr);
}