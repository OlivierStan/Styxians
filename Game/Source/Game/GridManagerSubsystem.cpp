// Fill out your copyright notice in the Description page of Project Settings.


#include "GridManagerSubsystem.h"

void UGridManagerSubsystem::InitializeGrid(int InGridWidth, int InGridHeight, float InCellSize, FVector InGridOrigin)
{
    GridWidth = InGridWidth;
    GridHeight = InGridHeight;
    CellSize = InCellSize;
    GridOrigin = InGridOrigin;

    Cells.Empty();
    for (int X = 0; X < GridWidth; ++X)
    {
        for (int Y = 0; Y < GridHeight; ++Y)
        {
            Cells.Add(FIntPoint(X, Y), FGridCellData());
        }
    }
}

FVector UGridManagerSubsystem::GridToWorld(FIntPoint Cell) const
{
    return GridOrigin + FVector(Cell.X * CellSize + CellSize * 0.5f,
        Cell.Y * CellSize + CellSize * 0.5f,
        0.f);
}

FIntPoint UGridManagerSubsystem::WorldToGrid(FVector WorldLocation) const
{
    const FVector Local = WorldLocation - GridOrigin;
    const int X = FMath::FloorToInt(Local.X / CellSize);
    const int Y = FMath::FloorToInt(Local.Y / CellSize);
    return FIntPoint(X, Y);
}

bool UGridManagerSubsystem::IsValidCell(FIntPoint Cell) const
{
    return Cell.X >= 0 && Cell.X < GridWidth && Cell.Y >= 0 && Cell.Y < GridHeight;
}

EGridCellState UGridManagerSubsystem::GetCellState(FIntPoint Cell) const
{
    if (const FGridCellData* Data = Cells.Find(Cell))
    {
        return Data->State;
    }
    return EGridCellState::Empty;
}

void UGridManagerSubsystem::SetCellState(FIntPoint Cell, EGridCellState NewState)
{
    if (FGridCellData* Data = Cells.Find(Cell))
    {
        Data->State = NewState;
    }
}