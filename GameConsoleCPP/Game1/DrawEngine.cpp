#include "DrawEngine.h"

DrawEngine::DrawEngine(int xSize, int ySize)
{
	screenWidth = xSize;
	screenHeight = ySize;

	//set cursor visibility to false
	CursorVisibility(false);

	map = 0;
}

DrawEngine::~DrawEngine()
{
	//set cursor visibility to true
	CursorVisibility(true);

	GotoXY(0, screenHeight);
}

int DrawEngine::CreateSprite(int index, char c)
{
	if (index>=0 && index < 16)
	{
		spriteImage[index] = c;
		return index;
	}

	return -1;
}

void DrawEngine::DeleteSprite(int index)
{
	// in this implamentation we don't need it
}

void DrawEngine::DrawSprite(int index, int posX, int posY)
{	
	// go to the correct location
	GotoXY(posX, posY);
	// draw the sprite with cout
	cout << spriteImage[index];
}

void DrawEngine::EraseSprite(int posX, int posY)
{
	GotoXY(posX, posY);
	cout << ' ';
}

void DrawEngine::SetMap( char **data)
{
	map = data;
}

void DrawEngine::CreateBackgroundTile(int index, char c)
{
	if (index >= 0 && index < 16)
	{
		tileImage[index] = c;
	}
}

void DrawEngine::DrawBackground()
{
	if (map)
	{
		for (int y = 0; y < screenHeight; y++)
		{
			GotoXY(0, y);

			for (int x = 0; x < screenWidth; x++)
			{
				cout << tileImage[map[x][y]]; // oh cool
			}
		}
	}
}

void DrawEngine::GotoXY(int posX, int posY)
{
	HANDLE output_handle;
	COORD pos;

	pos.X = posX;
	pos.Y = posY;

	output_handle = GetStdHandle(STD_OUTPUT_HANDLE);

	SetConsoleCursorPosition(output_handle, pos);
}

void DrawEngine::CursorVisibility(bool visibility)
{
	HANDLE output_handle;
	CONSOLE_CURSOR_INFO cciInfo;

	cciInfo.dwSize = 1;
	cciInfo.bVisible = visibility;
	output_handle = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorInfo(output_handle, &cciInfo);
}
