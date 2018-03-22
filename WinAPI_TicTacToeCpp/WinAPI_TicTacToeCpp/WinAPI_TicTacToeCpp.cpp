// WinAPI_TicTacToeCpp.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "WinAPI_TicTacToeCpp.h"
#include <windowsx.h>

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name



// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_WINAPITICTACTOECPP, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_WINAPITICTACTOECPP));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_WINAPITICTACTOECPP));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    //wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
	wcex.hbrBackground  = (HBRUSH)GetStockObject(GRAY_BRUSH); // перекрашуем задний фончик шоб не мулял
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_WINAPITICTACTOECPP);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//

// My Globall Variables
const int CELL_SIZE = 100; // CELL_SIZE
HBRUSH hBrush1, hBrush2;
int playerTurn = 1; // flag

// Мало ли что там с экранами...
BOOL GetGameBoardRect(HWND hwnd, RECT * pRect) 
{
	RECT rc;
	
	if (GetClientRect(hwnd, &rc))
	{
		int width = rc.right - rc.left;
		int height = rc.bottom - rc.top;


		pRect->left = (width - CELL_SIZE * 3) / 2;
		pRect->top = (height - CELL_SIZE * 3) / 2;

		pRect->right = pRect->left + CELL_SIZE * 3;
		pRect->bottom = pRect->top + CELL_SIZE * 3;
		return TRUE;
	}
	
	// если мы обложались
	SetRectEmpty(pRect);
	return FALSE;
}

// рисуем линию
void DrawLine(HDC hdc, int x1, int y1, int x2, int y2)
{
	MoveToEx(hdc, x1, y1, NULL);
	LineTo(hdc, x2, y2);
}

// в какой клетке прилетело WM_LBUTTONDOWN
int GetCellNumberFromPoint(HWND hwnd, int x, int y) 
{
	POINT pt = {x, y};
	RECT rc;

	if (GetGameBoardRect(hwnd, &rc))
	{
		if (PtInRect(&rc, pt))
		{
			//user clicked inside game board
			//Normalize (0 to 3*CELL_SIZE)
			x = pt.x - rc.left;
			y = pt.y - rc.top;

			int column = x / CELL_SIZE;
			int row = y / CELL_SIZE;

			//convert to index (0 to 8)
			return column + row * 3;
		}

	}
	return -1; // outside the playing field and we were f.cking wasted
}


BOOL GetCellRect(HWND hWnd,int index, RECT * pRectCell)
{
	RECT rcBoard;
	
	SetRectEmpty(pRectCell);
	if (index < 0 || index > 8)
		return FALSE;
	
	if (GetGameBoardRect(hWnd, &rcBoard))
	{
		//Convert index from 0 to 8 into x,y pair
		int y = index / 3; //Row number
		int x = index % 3; //Column number
		int offset = 1; // отступ чтоб не цеплять линии

		pRectCell->left = rcBoard.left + x * CELL_SIZE + offset;
		pRectCell->top = rcBoard.top + y * CELL_SIZE + offset;
		pRectCell->right = pRectCell->left + CELL_SIZE - offset;
		pRectCell->bottom = pRectCell->top + CELL_SIZE - offset;

		return TRUE;
	}
	
	return FALSE;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
	case WM_CREATE:
	{
		hBrush1 = CreateSolidBrush(RGB(255, 10, 10)); //Red
		hBrush2 = CreateSolidBrush(RGB(10, 10, 255)); //Blue
	}
	break;
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
	case WM_LBUTTONDOWN:
		{
		// need include <windowsx.h>
			int xPos = GET_X_LPARAM(lParam);
			int yPos = GET_Y_LPARAM(lParam);

			int index = GetCellNumberFromPoint(hWnd, xPos, yPos);
			
			HDC hdc = GetDC(hWnd);
			if (NULL != hdc)
			{
				//WCHAR temp[100];

				//wsprintf(temp, L"Index=%d", index); // WM_LBUTTONDOWN in index cell
				//TextOut(hdc, xPos, yPos, temp, lstrlen(temp));
				
				
				//Get cell dimension from it's index
				if (index != -1)
				{
					RECT rcCell;
					if (GetCellRect(hWnd, index, &rcCell))
					{
						FillRect(hdc, &rcCell, (playerTurn == 2) ? hBrush2 : hBrush1);
					}
					playerTurn = (playerTurn == 1) ? 2 : 1;
				}
				ReleaseDC(hWnd, hdc);
			}
		}
		break;

	case WM_GETMINMAXINFO:
	{
		//For stop resize minimaize hwnd
		MINMAXINFO * pMinMax = (MINMAXINFO*)lParam;

		pMinMax->ptMinTrackSize.x = CELL_SIZE * 5;
		pMinMax->ptMinTrackSize.y = CELL_SIZE * 5;

	}
    case WM_PAINT:
        {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            // TODO: Add any drawing code that uses hdc here...
			RECT rc;
			
			// вставляем нашу ф-ю
			if (GetGameBoardRect(hWnd, &rc))
			{
				FillRect(hdc, &rc,(HBRUSH)GetStockObject(WHITE_BRUSH)); // Because Rectangle Boarder by Default - is DARK
				//Rectangle(hdc, rc.left, rc.top, rc.right, rc.bottom); 
			}
			
			for (int i = 0; i < 4; ++i)
			{
				//Draw vertical lines
				DrawLine(hdc, rc.left + CELL_SIZE * i, rc.top, rc.left + CELL_SIZE * i, rc.bottom);
				//Draw Horizontal lines
				DrawLine(hdc, rc.left, rc.top + CELL_SIZE * i, rc.right, rc.top + CELL_SIZE * i);
			}

			EndPaint(hWnd, &ps);            
        }
        break;
    case WM_DESTROY:
		DeleteObject(hBrush1);
		DeleteObject(hBrush2);
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
