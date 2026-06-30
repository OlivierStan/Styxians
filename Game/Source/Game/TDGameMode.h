// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/GameMode.h"
#include "TDGameMode.generated.h"

/**
 * 
 */
UCLASS()
class GAME_API ATDGameMode : public AGameMode
{
	GENERATED_BODY()
	
public:
	ATDGameMode();

protected:
	virtual void BeginPlay() override;
};
