// Fill out your copyright notice in the Description page of Project Settings.


#include "TDGameMode.h"
#include "CameraPawn.h"

#include "GridManagerSubsystem.h"

ATDGameMode::ATDGameMode()
{
	DefaultPawnClass = ACameraPawn::StaticClass();
}

void ATDGameMode::BeginPlay()
{
    Super::BeginPlay();
    if (UGridManagerSubsystem* Grid = GetWorld()->GetSubsystem<UGridManagerSubsystem>())
    {
        Grid->InitializeGrid(20, 20, 100.f, FVector::ZeroVector);
    }
}
