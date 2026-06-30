// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Subsystems/WorldSubsystem.h"
#include "GridManagerSubsystem.generated.h"

UENUM(BlueprintType)
enum class EGridCellState : uint8
{
    Empty,
    Buildable,
    Path,
    OccupiedByTower
};

USTRUCT(BlueprintType)
struct FGridCellData
{
    GENERATED_BODY()

    UPROPERTY(BlueprintReadOnly)
    EGridCellState State = EGridCellState::Buildable;
};

/**
 * 
 */
UCLASS()
class GAME_API UGridManagerSubsystem : public UWorldSubsystem
{
	GENERATED_BODY()
	
public:

    UFUNCTION(BlueprintCallable, Category = "Grid")
    void InitializeGrid(int InGridWidth, int InGridHeight, float InCellSize, FVector InGridOrigin);

    UFUNCTION(BlueprintCallable, Category = "Grid")
    FVector GridToWorld(FIntPoint Cell) const;

    UFUNCTION(BlueprintCallable, Category = "Grid")
    FIntPoint WorldToGrid(FVector WorldLocation) const;

    UFUNCTION(BlueprintCallable, Category = "Grid")
    bool IsValidCell(FIntPoint Cell) const;

    UFUNCTION(BlueprintCallable, Category = "Grid")
    EGridCellState GetCellState(FIntPoint Cell) const;

    UFUNCTION(BlueprintCallable, Category = "Grid")
    void SetCellState(FIntPoint Cell, EGridCellState NewState);

    UFUNCTION(BlueprintCallable, Category = "Grid")
    float GetCellSize() const { return CellSize; }

private:
    TMap<FIntPoint, FGridCellData> Cells;

    int GridWidth = 0;
    int GridHeight = 0;
    float CellSize = 100.f;
    FVector GridOrigin = FVector::ZeroVector;
};
