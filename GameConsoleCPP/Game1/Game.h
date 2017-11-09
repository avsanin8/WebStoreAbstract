#pragma once
#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <Windows.h>
#include "DrawEngine.h"
#include "Character.h"
#include "Level.h"
#include "Mage.h"

using namespace std;

class Game
{
public:
	bool Run();
	Game();
	~Game();

protected:
	bool GetInput(char &c);
	void TimerUpdate();

private:
	Level *level;
	Mage *player;

	double frameCount;
	double startTime;
	double lastTime;
	
	int posX;

	DrawEngine drawArea;
};


