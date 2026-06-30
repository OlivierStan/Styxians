// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "CameraPawn.generated.h"

class UCameraComponent;
class USpringArmComponent;

UCLASS()
class GAME_API ACameraPawn : public APawn
{
    GENERATED_BODY()

public:
    ACameraPawn();

    void DebugTestGridClick();

protected:
    virtual void BeginPlay() override;

    UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Camera")
    USceneComponent* SceneRoot;

    UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Camera")
    USpringArmComponent* SpringArm;

    UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Camera")
    UCameraComponent* Camera;


    UPROPERTY(EditAnywhere, Category = "Camera")
    float ArmLength = 1800.f;


    UPROPERTY(EditAnywhere, Category = "Camera")
    float PitchAngle = -55.f;
};
