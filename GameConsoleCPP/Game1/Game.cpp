#include "Game.h"


#define GAME_SPEED 33
// this is going to give us 30 fps

bool Game::Run()
{
	//SetConsoleCP(1221);
	//SetConsoleOutputCP(1221);

	level = new Level (&drawArea, 30, 20);

	drawArea.CreateBackgroundTile(TILE_EMPTY, ' ');
	drawArea.CreateBackgroundTile(TILE_WALL, 219);

	drawArea.CreateSprite(SPRITE_PLAYER, 1);
	drawArea.CreateSprite(SPRITE_ENEMY, '$');
	drawArea.CreateSprite(SPRITE_FIREBALL, '*');

	player = new Mage(level, &drawArea, 0); //почему изменили Character на Mage

	level->Draw();
	level->AddPlayer(player);
	level->AddEnemies(3);

	char key = ' ';

	frameCount = 0;
	startTime = timeGetTime();
	lastTime = 0;
	posX = 0;

	player->Move(0, 0);

	while (key != 'q')
	{
		while (!GetInput(key))
		{
			TimerUpdate();
			Sleep(GAME_SPEED);
			
		}

		level->KeyPress(key);

		
	}

	delete player;

	cout << frameCount / ((timeGetTime() - startTime)/ 1000) << " fps" << endl;
	cout << frameCount << endl;
	cout << "End the Game" << endl;
	
	return true;
}

bool Game::GetInput(char & c)
{
	if (_kbhit())
	{
		c = _getch();
		return true;
	}
	return false;
}

void Game::TimerUpdate()
{
	double deltaTime = timeGetTime() - lastTime;
	
	if (deltaTime==0)
		return;
	
	//player->Move(1, 1);

	//drawArea.eraseSprite(posX, 5);
	//posX = (posX + 1) % 80;
	//drawArea.drawSprite(0, posX, 5);

	level->UpDate();
	frameCount++;

	lastTime = timeGetTime();
}


Game::Game()
{
}


Game::~Game()
{
}