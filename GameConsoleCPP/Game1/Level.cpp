#include "Level.h"
#include "Character.h"

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
}